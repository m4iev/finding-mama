using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutscene;
    [SerializeField] private string nextScene;
    private double durasi;
    private void Start()
    {
        GameState.lose = false;
        GameState.onQuestion = false;
        GameState.isPlayingCutscene = false;
        durasi = cutscene.duration;
        GameState.isPlaying = true;    
        GameState.canMove = true;   
    }

    private void Update()
    {
        if (GameState.isPlayingCutscene)
        {
            durasi -= Time.deltaTime;
        }

        if(durasi + 1d < 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void StartCutscene()
    {
        cutscene.Play();
        GameState.isPlayingCutscene = true;   
    }
}
