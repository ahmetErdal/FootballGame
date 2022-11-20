using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FootController : MonoBehaviour
{
    public static FootController instance;
    private void Awake()
    {
        instance = this;
    }
    private Camera cam;
   
    
    [SerializeField] private Transform footTransform;
    [HideInInspector] public int bounceCount = 0;
    [HideInInspector] public float touchTimeBall;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI touchTimeText;
    public Vector3 worldPosition;
    public Vector3 screenPosition;
    public Vector3 oldPos;
    public float HInput;
    [HideInInspector] public bool isPlay;
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        GetTheInput();
        FootCont();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("ball")&& Mathf.Abs(HInput)>=1)
        {
            bounceCount++;
            countText.text ="Count: "+LevelManagers.instace.needTouchBall+"/"+ bounceCount.ToString();
            HInput=Mathf.Clamp(HInput, -7, 7);
            BallForce.instance.AddForceToBall(Mathf.Abs(HInput));
            LevelManagers.instace.CompleteCheckLevel();
        }
       
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag=="ball")
        {
            touchTimeBall += Time.deltaTime;
            touchTimeBall = (float)System.Math.Round(touchTimeBall, 2);
            touchTimeText.text = "Touch: " +LevelManagers.instace.needTimeStals+"/"+ touchTimeBall.ToString();
            LevelManagers.instace.CompleteCheckLevel();
        }
    }
    void GetTheInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPos = Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            HInput = Input.mousePosition.y - oldPos.y;
            oldPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            HInput = 0;
        }
    }
    void FootCont()
    {
        if (Input.GetMouseButton(0)&&isPlay)
        {
            screenPosition = Input.mousePosition;
            screenPosition.z = cam.nearClipPlane + 1;
            worldPosition = cam.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0;
            footTransform.position = worldPosition;
        }
    }
}
