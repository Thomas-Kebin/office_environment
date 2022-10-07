using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Cinemachine;

public class Unlock : MonoBehaviour
{
    public Camera cam;
    public GameObject key;

    private CinemachineBrain cinemc;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        cinemc = cam.GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void unlock(){
        StartCoroutine(PlayStreamingAudio());
    }

    IEnumerator PlayStreamingAudio()
    {
        string base_url="https://inigmademo-a.azurewebsites.net/Home/Privacy/";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(base_url + Global.temp_door_num.ToString()))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                if(int.Parse(webRequest.downloadHandler.text) == 1){
                    Global.key_flag = 1;
                }
                cinemc.enabled = true;

                key = GameObject.Find("key" + Global.door_num);
                key.transform.position = new Vector3(500,500,500);
                key.SetActive(false);
            }
        }
    }
}
