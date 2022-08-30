using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static int door_num = 0;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject door6;
    public GameObject door7;
    public GameObject door8;
    public GameObject door9;
    public GameObject door10;
    public GameObject door11;
    public GameObject target;
    float m_Timer;
    int key_flag=0;
    int door11_status = 0; // 0:close, 1:open
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Timer == 0 && door_num !=0)
            target = GameObject.Find("door" + door_num);
        if (Input.GetKeyDown(KeyCode.K)){
            key_flag=1;
        }
        if(key_flag == 1){
                if(door11_status == 0)
                    OpenDoor(target);
                else
                    CloseDoor(target);
        }
            
        
    }
    void OpenDoor(GameObject door){
        
        m_Timer += Time.deltaTime;
        if(m_Timer < 1){
            float degreesPerSecond = 90;
            door.transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        }
        else{
            door11_status = 1;
            key_flag = 0;
            m_Timer = 0;
        }
    }
    void CloseDoor(GameObject door){
        
        m_Timer += Time.deltaTime;
        if(m_Timer < 1){
            float degreesPerSecond = 90;
            door.transform.Rotate(new Vector3(0, -degreesPerSecond, 0) * Time.deltaTime);
        }
        else{
            door11_status = 0;
            key_flag = 0;
            m_Timer = 0;
        }
    }
}
