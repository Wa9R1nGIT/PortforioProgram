using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherFromTitle : MonoBehaviour
{
    public string sceneToLoad; // 切り替え先のシーン名

    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Debug.Log("Button Clicked! Switching scene to: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad); // シーンの切り替え

        // 時間を元に戻す
        Time.timeScale = 1f;
    }
}
