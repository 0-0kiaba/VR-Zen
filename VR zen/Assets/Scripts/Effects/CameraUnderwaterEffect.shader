Shader "Hidden/CameraUnderwaterEffect"
{
    Properties
    {
        [HideInspector] _MainTex ("Texture", 2D) = "white" {}
        [HideInspector] _DepthStart ("Depth Start Distance", float) = 1
        [HideInspector] _DepthEnd ("Depth End Distance", float) = 300
        [HideInspector] _DepthColor ("Depth Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        // Disable backface culling (Cull off),
        // depth buffer updating during rendering (ZWrite Off),
        // Always draw a pixel regardless of depth (ZTest Always)
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _CameraDepthTexture, _MainTex;
            float _DepthStart, _DepthEnd;
            fixed4 _DepthColor;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 screenPos: TEXTCOORD1;
            };

            //We add an extra screenPos attribute to the vertext data, and compute the screen position of each vertex in the vert() function below
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                o.uv = v.uv;
                return o;
            }

            //Ran on every pixel scene by the camera
            //Because of this, it is responsible fot applying the post-processing effect onto the image
            //that the camera recieves
            fixed4 frag (v2f i) : SV_Target
            {
                //We sample the pixel in I.screenPos from _CameraDepthTexture, then convert it to linear depth (stored non-linearly), that is clamped between 0 and 1
                float depth = LinearEyeDepth(tex2D(_CameraDepthTexture, i.screenPos.xy));
                //clip the depth between 0 and 1 again, where 1 is if the pixel is further than _DepthEnd, and 0 is if the pixel is nearer than _DepthStart
                depth = saturate((depth - _DepthStart) / _DepthEnd);

                //scale the intensity of the depth color based on the depth by lerping between the original pixel color and our color based on the
                //depthValue of the pixel
                fixed4 col = tex2D(_MainTex, i.screenPos);
                return lerp(col, _DepthColor, depth);
            }
            ENDCG
        }
    }
}
