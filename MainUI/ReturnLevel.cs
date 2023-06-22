using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnLevel : MonoBehaviour
{
    Button btn;
    public new string name;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Fan);
    }

    private void Fan()
    {
        name = btn.name;
        SceneManager.LoadSceneAsync(name);
    }
}
