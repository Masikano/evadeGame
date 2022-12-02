using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public static playerController instance;
    public float speed;
    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    [SerializeField]
    //private Joystick _joystick;
    
    public GameObject TimeCurrent;
    
    public GameObject TimeMax;

    private Vector2 _screenPos;
    private Vector2 _cameraPos;
    private Vector2 _playerPos;

    private Text _timeCurrent;
    private Text _timeMax;
    private float _timeSinceLevelLoad;

    // Start is called before the first frame update

    //private GameObject _dontDestroyObject;
    private void Awake()
    {
        instance = this;
    }
    private void Start() {
        //TimeCurrent = GameObject.Find("timeCurrent");
        //TimeMax = GameObject.Find("timeMax");
        //_dontDestroyObject = GameObject.Find("dontDestroyObject");

        _rb = GetComponent<Rigidbody2D>();
        _timeCurrent = TimeCurrent.GetComponent<Text>();
        _timeMax = TimeMax.GetComponent<Text>();
        _timeSinceLevelLoad = Time.timeSinceLevelLoad;

        LoadTimeMax();
        _playerPos = transform.position;

        //_dontDestroyObject.GetComponent
    }
    private void Update() {
        //Vector2 moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        //_moveVelocity = moveInput * Speed;
        //transform.Translate(new Vector2(_joystick.Horizontal, _joystick.Vertical) * Speed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            _screenPos = Input.mousePosition;
            //screenPos.z = transform.position.z;
            //screenPos.y = transform.position.y;
            _cameraPos = Camera.main.ScreenToWorldPoint(_screenPos);
            _playerPos = new Vector2(_cameraPos.x, _cameraPos.y);
        }
    }
    private void FixedUpdate() {
        //_rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
        //Debug.Log("fixedUpdate Log");
        if (_playerPos.x < 2.5 && _playerPos.x > -2.5)
        {
            if(_playerPos.y < 4.5 && _playerPos.y > -2.5)
            {
                transform.position = _playerPos;

            }

        }
    }
    public Vector2 GetPlayerPosition()
    {
        return _playerPos;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "border") {
            //rb.MovePosition(rb.position - moveVelocity * Time.fixedDeltaTime);
            //Application.LoadLevel(Application.loadedLevel);
            //
            Debug.Log("left border collision");
            
        }
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "border") {
            Debug.Log("ERROR??? - " + _timeMax.text);
            if(float.Parse(_timeMax.text) < float.Parse(_timeCurrent.text)) {
                //_timeMax.text = (Time.timeSinceLevelLoad - _timeSinceLevelLoad).ToString();
                _timeMax.text = _timeCurrent.text;
                SaveTimeMax();
            }
            SaveTimeCurrent();
            //DontDestroyOnLoad(TimeMax);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);            
        }
    }

    private void SaveTimeMax() {
        PlayerPrefs.SetString("savedTimeMax", _timeMax.text);
       
    }
    private void SaveTimeCurrent() {
        PlayerPrefs.SetString("savedTimeCurrent", _timeCurrent.text);
    }
    private void LoadTimeMax() {
        if (PlayerPrefs.HasKey("savedTimeMax")) {
            Debug.Log("LoadTimeMax() savedTimeMax = " + PlayerPrefs.GetString("savedTimeMax"));

            _timeMax.text = PlayerPrefs.GetString("savedTimeMax");
            _timeCurrent.text = PlayerPrefs.GetString("savedTimeCurrent");

            Debug.Log("_timeMax.text = " + _timeMax.text);
            Debug.Log("_timeCurrent.text = " + _timeCurrent.text);
        }
        else {
            _timeMax.text = "0";
            _timeCurrent.text = "0";
        }
    }
    
}
    
