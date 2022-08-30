using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door11 : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            Global.door_num = 11;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == player)
        {
            Global.door_num = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
