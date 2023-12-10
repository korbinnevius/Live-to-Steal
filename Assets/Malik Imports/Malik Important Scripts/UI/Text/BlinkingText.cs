using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BlinkingText : MonoBehaviour
{

    private TMP_Text _textMeshPro;
    public float BlinkFadeInTime = 0.5f;
    public float BlinkStayTime = 0.8f;
    public float BlinkFadeOutTime = 0.7f;
    private float _timeChecker = 0;
    private Color _color;
    
    

    private void Start()
    {
        _textMeshPro = GetComponent<TMP_Text>();
        _color = _textMeshPro.color;
    }

    private void Update()
    {
        _timeChecker += Time.deltaTime;
        if (_timeChecker < BlinkFadeInTime)
        {
            _textMeshPro.color = new Color(_color.r, _color.g, _color.b, _timeChecker / BlinkFadeInTime);
        }
        else if (_timeChecker < BlinkFadeInTime + BlinkStayTime)
        {
            _textMeshPro.color = new Color(_color.r, _color.g, _color.b, 1);
        }
        else if (_timeChecker < BlinkFadeInTime + BlinkStayTime + BlinkFadeOutTime)
        {
            _textMeshPro.color = new Color(_color.r, _color.g, _color.b,
                1 - (_timeChecker - (BlinkFadeInTime + BlinkStayTime)) / BlinkFadeOutTime);
        }

        else
        {
            _timeChecker = 0;
        }
    }

    
    
}
