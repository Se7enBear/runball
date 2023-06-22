using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    Button Btn;
    public Canvas canvas;
    public Canvas canvas3;
    private void Awake()
    {
        Btn = transform.GetComponent<Button>();
        Btn.onClick.AddListener(HelpMessage);
    }
    void HelpMessage()
    {
       canvas.enabled = false;
       canvas3.enabled=true;
    }

}
