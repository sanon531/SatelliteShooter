﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameEvents : MonoBehaviour
{
    [SerializeField] public Button uibutton;
    [SerializeField] public event EventHandler OnUIPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator PressedCheck () {


        yield return null;
    }

}
