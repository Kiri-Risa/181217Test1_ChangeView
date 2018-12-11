using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming.Internal;
using Tobii.Gaming;


public class Move : MonoBehaviour
{
    public Vector3 rotateRate = new Vector3(0, 0, 0);
    public int CenterX = UnityEngine.Screen.width / 2;
    public int CenterY = UnityEngine.Screen.height / 2;

    // Use this for initialization
    void Start()
    {

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
            rotateRate.y = -50 * (point.x - CenterX) / CenterX;
        }
        else if (point.x < CenterX)
        {
            rotateRate.y = 50 * (point.x - CenterX) / CenterX;
        }
        else
        {
            rotateRate.y = 0;
        }
    }

    void CheckUD(GazePoint gazePoint)
    {
        var point = gazePoint.GUI;
        if (point.y > CenterY)
        {
            rotateRate.x = -50 * (point.y - CenterY) / CenterY;
        }
        else if (point.y < CenterY)
        {
            rotateRate.x = 50 * (point.y - CenterY) / CenterY;
        }
        else
        {
            rotateRate.x = 0;
        }
    }

    void Rotate()
    {
        transform.Rotate(rotateRate * Time.deltaTime);
    }

}
