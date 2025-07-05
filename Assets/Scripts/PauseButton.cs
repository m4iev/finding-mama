using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseLayout;
    public void Pause()
    {
        GameState.canMove = false;
        pauseLayout.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        GameState.canMove = true;
        pauseLayout.SetActive(false);
    }
}
