using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tobii.Gaming;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControllToKey : MonoBehaviour
{
    private int SIZE = 4;

    //該当オブジェクトの設定
    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;
    public GameObject Plane4;

    public GameObject Next;

    private Transform Video1;
    private Transform Video2;
    private Transform Video3;
    private Transform Video4;
    private Transform NextObject;

    private VideoPlayer Player1;
    private VideoPlayer Player2;
    private VideoPlayer Player3;
    private VideoPlayer Player4;

    private int SW;


    void Start()
    {
        Video1 = Plane1.GetComponent<Transform>();
        Video2 = Plane2.GetComponent<Transform>();
        Player1 = Plane1.GetComponent<VideoPlayer>();
        Player2 = Plane2.GetComponent<VideoPlayer>();
        SW = 0;
    }

    void Update()
    {
        switch (SW)
        {
            case 1://Video1を消してVideo2を表示
                Player1.Pause();
                Player2.Play();
                NextObject.transform.localPosition = new Vector3(1.5f, 2.5f, 0.18f);
                Video1.transform.localPosition = new Vector3(0, 0, 100);
                Video2.transform.localPosition = new Vector3(0, 0, 77);
                break;

            case 2:
                Player2.Pause();
                Player3.Play();
                NextObject.transform.localPosition = new Vector3(-1.4f, 1.4f, 0.18f);
                Video2.transform.localPosition = new Vector3(0, 0, 100);
                Video3.transform.localPosition = new Vector3(0, 0, 77);
                break;

            case 3:
                SceneManager.LoadScene("Scene2");
                /*Player3.Pause();
                Player4.Play();
                NextObject.transform.localScale = new Vector3(0,0,0);
                Video3.transform.localPosition = new Vector3(0, 0, 100);
                Video4.transform.localPosition = new Vector3(0, 0, 77);*/
                break;
        }
    }
}