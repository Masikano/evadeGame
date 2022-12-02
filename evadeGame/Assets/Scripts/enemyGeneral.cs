using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyGeneral : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float Speed;  
    public int userSeed;
    private int _seed;
    private bool _started;
    private Rigidbody2D[] _rbEnemies;
    //public Joystick Joystick;
    public bool RandomSeed;
    [SerializeField]
    private GameObject TimeCurrent;
    //public GameObject TimeMax;
    private Text _timeCurrent;
    //private Text _timeMax;

    private float _timeSinceLevelLoad;

    //private void Awake() {
    //    DontDestroyOnLoad(TimeMax);
    //}
    private void Start() {
        _started = false;
        TimeCurrent = GameObject.Find("timeCurrent");
        _timeCurrent = TimeCurrent.GetComponent<Text>();
        //_timeMax = TimeMax.GetComponent<Text>();
        //_seed = (int)Random.value;
        if (RandomSeed) {
            _seed = (int)Time.frameCount;
            Debug.Log("randomSeed");
        }
        else {
            _seed = userSeed;
            Debug.Log("userSeed");
        }
        Random.InitState(_seed);

        Shuffle(Prefabs);
        Vector3[] posVectors3 = new Vector3[Prefabs.Length];
        _rbEnemies = new Rigidbody2D[Prefabs.Length];
        Prefabs[0].transform.position = new Vector3(Random.Range(1, 2), Random.Range(-1, 1), 0);
        Prefabs[1].transform.position = new Vector3(Random.Range(1, 2), Random.Range(2, 4), 0);
        Prefabs[2].transform.position = new Vector3(Random.Range(-2, -1), Random.Range(2, 4), 0);
        Prefabs[3].transform.position = new Vector3(Random.Range(-2, -1), Random.Range(-1, 1), 0);
        Prefabs[4].transform.position = new Vector3(Random.Range(-2, 2), -2, 0);
        
        
        

        for (int i = 0; i < Prefabs.Length; i++) {
            //need to add movement
            
            //Prefabs[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1, Speed), Random.Range(1, Speed)), ForceMode2D.Force);
            var newEnemy = Instantiate(Prefabs[i], Prefabs[i].transform.position, Quaternion.identity);


            _rbEnemies[i] = newEnemy.GetComponent<Rigidbody2D>();
            //newEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1, Speed), Random.Range(1, Speed)), ForceMode2D.Impulse);
            newEnemy.transform.parent = gameObject.transform;
            
        }


    }

    private void Update() {
        if(!_started && playerController.instance.GetPlayerPosition() != Vector2.zero) {
            for(int i = 0; i < _rbEnemies.Length; i++) {
                var tempX = Random.Range(-Speed, Speed);
                var tempY = Random.Range(-Speed, Speed);
                if(Mathf.Abs(tempX) < 1) {
                    if(tempX < 0) {
                        tempX--;
                    }
                    else {
                        tempX++;
                    }
                }
                if (Mathf.Abs(tempY) < 1) {
                    if (tempY < 0) {
                        tempY--;
                    }
                    else {
                        tempY++;
                    }
                }                
                _rbEnemies[i].AddForce(new Vector2(tempX, tempY), ForceMode2D.Impulse);
            }
            _timeSinceLevelLoad = Time.timeSinceLevelLoad;

            _started = true;
            //float test = enumerable
        }
        if (_started) {
            _timeCurrent.text = (Time.timeSinceLevelLoad - _timeSinceLevelLoad).ToString("0.##");
        }
    }
    private void Shuffle(GameObject[] prefArray) {
        for (int i = prefArray.Length - 1; i >= 1; i--) {
            int j = Random.Range(0, i);
            GameObject temp = prefArray[j];
            prefArray[j] = prefArray[i];
            prefArray[i] = temp;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision) {
    //    if(collision.gameObject.tag == "player") {
    //        if(float.Parse(_timeMax.text) < (Time.timeSinceLevelLoad - _timeSinceLevelLoad)) {
    //            _timeMax.text = (Time.timeSinceLevelLoad - _timeSinceLevelLoad).ToString();
    //        }
    //    }
    //}
}

