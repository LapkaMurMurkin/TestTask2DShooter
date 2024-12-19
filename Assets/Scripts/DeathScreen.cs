using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;

    public void Initialize()
    {
        _restart.onClick.AddListener(ReloadScene);
        _exit.onClick.AddListener(ExitGame);
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
