using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming.Internal;
using Tobii.Gaming;


public class Move : MonoBehaviour
{
    private Vector3 rotateRate = new Vector3(0, 0, 0);
    private int CenterX = UnityEngine.Screen.width / 2;
    private int CenterY = UnityEngine.Screen.height / 2;
    //public Text text1;
    public int MaxUD;
    //private int MaxLR;
    public int Speed;

    private float SumA;

    // Use this for initialization
    void Start()
    {
        SumA = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        CheckLR(gazePoint);
        CheckUD(gazePoint);
        Rotate();
    }

    void CheckLR(GazePoint gazePoint)
    {
        var point = gazePoint.GUI;
        if (point.x > CenterX)
        {
            rotateRate.z = -Speed * (point.x - CenterX) / CenterX;
        }
        else if (point.x < CenterX)
        {
            rotateRate.z = Speed * (CenterX - point.x) / CenterX;
        }
        else
        {
            rotateRate.z = 0;
        }
    }

    void CheckUD(GazePoint gazePoint)
    {
        var point = gazePoint.GUI;
        if (point.y > CenterY)
        {
            rotateRate.x = Speed * (point.y - CenterY) / CenterY;
        }
        else if (point.y < CenterY)
        {
            rotateRate.x = -Speed * (CenterY - point.y) / CenterY;
        }
        else
        {
            rotateRate.x = 0;
        }

        SumA += rotateRate.x;

        if (SumA > MaxUD)
        {
            SumA = MaxUD;
            rotateRate.x = 0;
        } else
        {
            if (SumA < -MaxUD)
            {
                SumA = -MaxUD;
                rotateRate.x = 0;
            }
        }
    }

    void Rotate()
    {
        //text1.text ="SumA="+SumA;
        transform.Rotate(rotateRate * Time.deltaTime);
    }

}
