using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;   
    
    void Start()
    {
        transform.position = new Vector3(0, 10, 0);
        transform.localScale = Vector3.one * 5.0f;
        
        Material material = Renderer.material;
        
        material.color = new Color(5.0f, 1.3f, 8.9f, 0.1f);
    }
    
    void Update()
    {
        transform.Rotate(5.0f * Time.deltaTime, 5.0f, 5.0f);
    }
}
