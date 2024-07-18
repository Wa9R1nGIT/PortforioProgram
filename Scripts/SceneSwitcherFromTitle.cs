using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherFromTitle : MonoBehaviour
{
    public string sceneToLoad; // �؂�ւ���̃V�[����

    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Debug.Log("Button Clicked! Switching scene to: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad); // �V�[���̐؂�ւ�

        // ���Ԃ����ɖ߂�
        Time.timeScale = 1f;
    }
}
