using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tobii.Gaming;
using UnityEngine.UI;



public class React : MonoBehaviour
{

    //該当オブジェクトの設定
    //視線の反応するオブジェクト
    public GameObject Next;

    //ビデオを表示するオブジェクト
    public GameObject Video1;
    public GameObject Video2;
    public GameObject Video3;
    public GameObject Video4;

    //テキスト表示用ゲームオブジェクト
    public GameObject Text;

    //各視線に反応すオブジェクトのスイッチの状態を保存
    private ChangeColor2 NextSW;

    //状態表示テキスト
    private Text Text1;

    //
    private Controll Cont;
    private int SW;

    void Start()
    {
        Text1 = Text.GetComponent<Text>();
        Cont = this.GetComponent<Controll>();
        SW = Cont.ReturnSW();
    }

    void Update()
    {
        NextSW = Next.GetComponent<ChangeColor2>();

        if (NextSW.GetSelect())
        {
            ChangeText("Selected");
            Cont.SetSW();
            NextSW.ResetSelect();
        }

    }

    void ChangeText(String S)
    {
        Text1.text = S;
    }

}