using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Button starbtn;
    public Canvas canvas;
    public GameObject canvas2;
    public Canvas canvas3;
    private void Awake()
    {
        starbtn.onClick.AddListener(StarGame);
        canvas2.SetActive(false);
        canvas3.enabled=false;
    }

    private void StarGame()
    {
        canvas.enabled= false;
        canvas2.SetActive(true);
        canvas3.enabled=false;
    }

}
