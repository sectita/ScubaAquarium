using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuPannel;


    public void Pause()
    {
        PauseMenuPannel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseMenuPannel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        PauseMenuPannel.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
