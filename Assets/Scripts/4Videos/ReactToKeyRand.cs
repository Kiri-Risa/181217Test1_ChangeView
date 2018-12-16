using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tobii.Gaming;
using UnityEngine.UI;
using UnityEngine.Video;




public class ReactToKeyRand : MonoBehaviour
{

    //ビデオを表示するオブジェクト
    public GameObject[] Video = new GameObject[20];

    private Transform[] Plane = new Transform[4];
    private VideoPlayer[] Player = new VideoPlayer[4];

    //テキスト表示用ゲームオブジェクト
    public GameObject Text;

    //状態表示テキスト
    private Text Text1;
    private int[] a = new int[4];

    void Start()
    {
        Text1 = Text.GetComponent<Text>();

        int k = 0;
        int s = 0;
        while (k < 4)
        {
            s = 0;
            a[k] = UnityEngine.Random.Range(0, 20);
            for (int j = 0;j < k;j++)
            {
                if (a[k] == a[j]) s = 1;
            }

            if (s == 1) continue;
            k++;
        }

        for (int i = 0; i < 4; i++)
        {
            Plane[i] = Video[a[i]].GetComponent<Transform>();
            Player[i] = Video[a[i]].GetComponent<VideoPlayer>();
            Player[i].Play();
        }
        Plane[0].transform.localPosition = new Vector3(-50, 30, 100);
        Plane[1].transform.localPosition = new Vector3(50, 30, 100);
        Plane[2].transform.localPosition = new Vector3(-50, -30, 100);
        Plane[3].transform.localPosition = new Vector3(50, -30, 100);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 4; i++)
            {
                Player[i].Pause();
                Plane[i].transform.localPosition = new Vector3(0, 0, -100);
            }


            int k = 0;
            int s = 0;
            while (k < 4)
            {
                s=0;
                a[k]=UnityEngine.Random.Range(0, 20);
                for (int j = 0; j < k; j++)
                {
                    if (a[k] == a[j]) s = 1;
                }
                if (s == 1) continue;
                k++;
            }
            ChangeText(a[0] + "," + a[1] + "," + a[2] + "," + a[3] + ",");

            for (int i = 0; i < 4; i++)
            {
                Plane[i] = Video[a[i]].GetComponent<Transform>();
                Player[i] = Video[a[i]].GetComponent<VideoPlayer>();
                Player[i].Play();
            }
            Plane[0].transform.localPosition = new Vector3(-50, 30, 100);
            Plane[1].transform.localPosition = new Vector3(50, 30, 100);
            Plane[2].transform.localPosition = new Vector3(-50, -30, 100);
            Plane[3].transform.localPosition = new Vector3(50, -30, 100);
        }
    }

    void ChangeText(String S)
    {
        Text1.text = S;
    }

}