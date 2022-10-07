using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Global : MonoBehaviour
{
    public static int door_num = 0;
    public GameObject target;
    public GameObject temp_key;

    public GameObject door7;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject key6;
    public GameObject key11;
    public GameObject key12;
    public GameObject key13;
    public GameObject key14;
    public GameObject key15;
    public GameObject key16;

    public Camera cam;
    public float defaultFov = 90;
    private CinemachineBrain cinemc;
    public float zoomMultiplier = 4;
    public float zoomDuration = 2;

    public Transform key_lock;
    public Vector3 offset;
    public Vector3 offset1;
    public Vector3 offset2;
    Vector3 camera_position;

    public float smoothSpeed = 0.01f;
    

    Animator m_Animator;

    float m_Timer;
    public static int key_flag=0;
    public int zoom_flag=0;
    public static int temp_door_num;
    int[] door_status = {0,0,0,0,0,0}; // 0:close, 1:open
    
    // Start is called before the first frame update
    void Start()
    {
        cinemc = cam.GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Timer == 0 && door_num !=0){
            if(door_num > 10){
                temp_door_num = door_num-10;
                target = GameObject.Find("door" + temp_door_num);
            }
            else{
                temp_door_num = door_num;
                target = GameObject.Find("door" + temp_door_num);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.K) && door_num !=0 && m_Timer == 0 && door_num <10){
            
            key1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
            key4.SetActive(true);
            key5.SetActive(true);
            key6.SetActive(true);


            temp_key = GameObject.Find("key" + door_num);
            m_Animator = temp_key.GetComponent<Animator>();

            if(door_status[temp_door_num-1] == 0){
                camera_position = cam.transform.position;
                cinemc.enabled = false;
                zoom_flag=1;

                temp_key.SetActive(true);
                m_Animator.SetBool ("play_flag", true);
            }
            if(door_status[temp_door_num-1] == 1)
                key_flag = 1;
        }
        if (Input.GetKeyDown(KeyCode.K) && door_num !=0 && m_Timer == 0 && door_num >10){

            key11.SetActive(true);
            key12.SetActive(true);
            key13.SetActive(true);
            key14.SetActive(true);
            key15.SetActive(true);
            key16.SetActive(true);

            temp_key = GameObject.Find("key" + door_num);
            m_Animator = temp_key.GetComponent<Animator>();

            if(door_status[temp_door_num-1] == 0){
                camera_position = cam.transform.position;
                cinemc.enabled = false;
                zoom_flag=1;

                temp_key.SetActive(true);
                m_Animator.SetBool ("play_flag_1", true);
            }
            if(door_status[temp_door_num-1] == 1)
                key_flag = 1;
        }
        if(key_flag == 1){
                if(door_status[temp_door_num-1] == 0)
                    OpenDoor(target);
                else
                    CloseDoor(target);
        }
        if(zoom_flag == 1){
            SmoothFollow();
            ZoomCamera(30);
        }
    }
    void OpenDoor(GameObject door){
        
        m_Timer += Time.deltaTime;
        if(m_Timer < 1){
            float degreesPerSecond = 90;
            door.transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
            if(temp_door_num == 6)
                door7.transform.Rotate(new Vector3(0, -degreesPerSecond, 0) * Time.deltaTime);
        }
        else{
            door_status[temp_door_num-1] = 1;
            key_flag = 0;
            m_Timer = 0;
        }
    }
    void CloseDoor(GameObject door){
        
        m_Timer += Time.deltaTime;
        if(m_Timer < 1){
            float degreesPerSecond = 90;
            door.transform.Rotate(new Vector3(0, -degreesPerSecond, 0) * Time.deltaTime);
            if(temp_door_num == 6)
                door7.transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        }
        else{
            door_status[temp_door_num-1] = 0;
            key_flag = 0;
            m_Timer = 0;
        }
    }
    void ZoomCamera(float target)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
    public void SmoothFollow()
    {
        key_lock = target.transform.GetChild(1);
        Vector3 targetPos;
        if(door_num<3)
            targetPos = key_lock.position + offset;
        else if(door_num<13)
            targetPos = key_lock.position + offset1;
        else 
            targetPos = key_lock.position + offset2;
        Vector3 smoothFollow = Vector3.Lerp(cam.transform.position, targetPos, smoothSpeed);

        cam.transform.position = smoothFollow;
        cam.transform.LookAt(key_lock);
    }
}
