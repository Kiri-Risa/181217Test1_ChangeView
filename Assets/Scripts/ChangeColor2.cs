//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;
using System;
using Tobii.Gaming;

/// <summary>
/// Changes the color of the game object's material, when the the game object 
/// is in focus of the user's eye-gaze.
/// </summary>
/// <remarks>
/// Referenced by the Target game objects in the Simple Gaze Selection example scene.
/// </remarks>
[RequireComponent(typeof(GazeAware))]
[RequireComponent(typeof(MeshRenderer))]
public class ChangeColor2 : MonoBehaviour
{

    public Color selectionColor;
    public Color decisionColor;
    public float decisionTime;

    private GazeAware _gazeAwareComponent;
    private MeshRenderer _meshRenderer;

    private Color _deselectionColor;
    private Color _lerpColor;
    private float _fadeSpeed = 0.1f;
    private DateTime startSelect;
    private bool Select;
    private bool SaveSelect;

    /// <summary>
    /// Set the lerp color
    /// </summary>
    void Start()
    {
        _gazeAwareComponent = GetComponent<GazeAware>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _lerpColor = _meshRenderer.material.color;
        _deselectionColor = Color.white;
        Select = false;
        SaveSelect = false;
    }

    /// <summary>
    /// Lerping the color
    /// </summary>
    void Update()
    {

        if (_meshRenderer.material.color != _lerpColor)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, _lerpColor, _fadeSpeed);
        }

        // Change the color of the cube
        if (_gazeAwareComponent.HasGazeFocus)
        {
            SetLerpColor(selectionColor);
            if (!Select)
            {
                Select = true;
                startSelect = System.DateTime.Now;
            }
            else
            {
                if ((System.DateTime.Now - startSelect).TotalSeconds > decisionTime)
                {
                    SetLerpColor(decisionColor);
                    SaveSelect = true;
                }
            }

        }
        else
        {
            SetLerpColor(_deselectionColor);
            if (Select)
            {
                Select = false;
            }
        }
    }

    /// <summary>
    /// Update the color, which should used for the lerping
    /// </summary>
    /// <param name="lerpColor"></param>
    public void SetLerpColor(Color lerpColor)
    {
        this._lerpColor = lerpColor;
    }

    public Boolean GetSelect()
    {
        return SaveSelect;
    }

    public void ResetSelect()
    {
        Select = false;
        SaveSelect = false;
    }
}
