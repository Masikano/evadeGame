using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenScale : MonoBehaviour
{
    public float sceneWidth;
    // Start is called before the first frame update
    void Start()
    {
        float ratio = (float) Screen.height / Screen.width;
        float ortSize = sceneWidth * ratio / 200f;
        Camera.main.orthographicSize = ortSize;
        
    }

    
}
