using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyTimeMax : MonoBehaviour
{

    // Start is called before the first frame update
    private static GameObject instance;
    //public GameObject TimeMax;
    private float _timeMax;
    private void Awake() {
        //TimeMax = GameObject.Find("timeMax");
        
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = this.gameObject;
            Debug.Log("instance");
        }
        else {
            Destroy(instance);
            Debug.Log("Destroy");
        }
    }
    public void setTimeMax(float p) {
        _timeMax = p;
    }
    public float getTimeMax() {
        return _timeMax;
    }
}
