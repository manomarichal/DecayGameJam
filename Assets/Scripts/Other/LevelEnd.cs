using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public Player player;
    public Fade fade;
    public Transform levelStart;
    
    [SerializeField] private string nextLevel;

    [Header("Music")]
    [SerializeField] private AK.Wwise.State setInGame;
    [SerializeField] private AK.Wwise.State setMusicInGame;
    [SerializeField] private AK.Wwise.State setEndMusic;
    

    private void Start()
    {
        setInGame.SetValue();
        setMusicInGame.SetValue();
        
        Invoke(nameof(FadeOnStart), 1);
    }

    private void FadeOnStart()
    {
        fade.FadeOut();
    }
    private void StartFade()
    {
        fade.FadeIn();
        Invoke(nameof(TransitionToNextLevel), 2f);
        levelStart.position = new Vector3(levelStart.position.x, levelStart.position.y, player.transform.position.z);
    }

    private void TransitionToNextLevel()
    {
        if (nextLevel == "end")
        {
            player.transform.position = levelStart.position;
            setEndMusic.SetValue();
            player.StateMachine.ChangeState(player.IdleState);
        }
        else
        { SceneManager.LoadScene(nextLevel);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           player.StateMachine.ChangeState(player.EndLevelState);
           Invoke(nameof(StartFade), 2.5f);
        }
    }
    
}
