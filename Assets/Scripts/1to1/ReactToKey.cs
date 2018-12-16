using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tobii.Gaming;
using UnityEngine.UI;
using UnityEngine.Video;




public class ReactToKey : MonoBehaviour
{

    //ビデオを表示するオブジェクト
    public GameObject[] Video = new GameObject[20];

    private Transform Plane1;
    private Transform Plane2;
    private VideoPlayer Player1;
    private VideoPlayer Player2;

    //テキスト表示用ゲームオブジェクト
    public GameObject Text;

    //状態表示テキスト
    private Text Text1;
    private int SW;
    private int newSW;

    void Start()
    {
        Text1 = Text.GetComponent<Text>();
        ChangeText("Video0");
        SW = 0;
        newSW = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            newSW = SW % 20;
            ChangeText("Video" + newSW);
            Plane1 = Video[newSW].GetComponent<Transform>();
            Player1 = Video[newSW].GetComponent<VideoPlayer>();
            if(newSW==19)
            {
                Plane2 = Video[0].GetComponent<Transform>();
                Player2 = Video[0].GetComponent<VideoPlayer>();
            }
            else
            {
                Plane2 = Video[newSW+1].GetComponent<Transform>();
                Player2 = Video[newSW+1].GetComponent<VideoPlayer>();
            }

            Player1.Pause();
            Player2.Play();
            Plane1.transform.localPosition = new Vector3(0, 0, 100);
            Plane2.transform.localPosition = new Vector3(0, 0, 77);
            SW++;
        }
    }

    void ChangeText(String S)
    {
        Text1.text = S;
    }

}