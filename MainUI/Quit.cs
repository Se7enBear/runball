using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quit : MonoBehaviour
{
    Button quitbtn;
    private void Awake()
    {
        quitbtn = transform.GetComponent<Button>();
        quitbtn.onClick.AddListener(QuitGame);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
