using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinController :Single<WinController>
{

    public int score;
    public Text scoreText;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            Destroy(other.gameObject);
            score += 100;
            scoreText.text = "score:" + score;
        }
        if (other.gameObject.CompareTag("Final") && score >= 100)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
