using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_col : MonoBehaviour
{
    
    public GameObject player;
    public GameObject collider;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            string n_s = collider.name;
            string[] splitArray = n_s.Split(char.Parse("_"));
            Global.door_num = int.Parse(splitArray[1]);
            print(Global.door_num);
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
