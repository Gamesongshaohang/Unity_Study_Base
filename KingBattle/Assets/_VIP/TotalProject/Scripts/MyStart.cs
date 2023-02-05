using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStart : MonoBehaviour
{
   
    void Start()
    {
        UIPage.ShowPageAsync<LogoPage>();
    }

}
