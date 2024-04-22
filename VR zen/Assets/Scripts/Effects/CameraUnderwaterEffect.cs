using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraUnderwaterEfftec : MonoBehaviour
{

    public Shader shader;
    public Color depthColor = new Color(0, 0.42f, 0.87f);
    public float depthStart = -12;
    public float depthEnd = 90;
    
    Camera cam;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //Make our camera send depth information (i.e. how far a pixel from the screen) to the shader as well
        cam.depthTextureMode = DepthTextureMode.Depth;

        if (shader)material = new Material(shader);
    }

    //Automatically finds and assigns inspector variables so the script can be immediately used when attached to a gameobject;

    private void Reset(){
        //Look fot the shader we created
        Shader[] shaders = Resources.FindObjectsOfTypeAll<Shader>();
        foreach(Shader s in shaders){
            if (s.name.Contains(this.GetType().Name)){
                shader = s;
                return;
            }
        }
        
    }

    //This is where image effect is applied
    private void OnRenderImage(RenderTexture source, RenderTexture destination){
        if(material){
            //Here we pass the info to our material
            material.SetColor("_DepthColor", depthColor);
            material.SetFloat("_DepthStart", depthStart);
            material.SetFloat("_DepthEnd", depthEnd);
            
            Graphics.Blit(source, destination, material);
        }else{
            Graphics.Blit(source, destination);
        }
    }
}
