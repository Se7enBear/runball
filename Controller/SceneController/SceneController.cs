using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : Single<SceneController>
{
    string scenceName = "Level1";
    public string ScenceName { get { return PlayerPrefs.GetString(scenceName); } }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void Update()
    {

    }
    public void SaveScence()
    {
        PlayerPrefs.SetString(scenceName, SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
