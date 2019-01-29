﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot : MonoBehaviour
{
    public int current_value = 1;
    public Transform transform;

    public void Rotate_Slot()
    {
        var a = GetComponent<Animator>();
        a.SetBool("IsRot", true);
        StartCoroutine("Rotate");
        current_value++;
        if(current_value > 4)
        {
            current_value = 1;
        }        
    }

    IEnumerator Rotate()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            var a = GetComponent<Animator>();
            a.SetBool("IsRot", false);
            break;
        }
    }
}