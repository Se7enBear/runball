using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    Button conBtn;
    private void Awake()
    {
        conBtn = transform.GetComponent<Button>();
        conBtn.onClick.AddListener(ContinueGame);
    }
    void ContinueGame()
    {
       StartCoroutine(LoadLevel(SceneController.Instance.ScenceName));

    }
    IEnumerator LoadLevel(string scene)
    {
        yield return SceneManager.LoadSceneAsync(scene);
        yield break;
    }
}
