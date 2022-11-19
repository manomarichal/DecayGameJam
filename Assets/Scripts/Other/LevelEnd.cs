using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Player player;
    public Fade fade;
    public Transform levelStart;
    public AK.Wwise.Event music;

    [SerializeField] private AK.Wwise.State setInGame;
    [SerializeField] private AK.Wwise.State setMenu;

    [SerializeField] private AK.Wwise.State setMusicInGame0;
    [SerializeField] private AK.Wwise.State setMusicInGame1;
    [SerializeField] private AK.Wwise.State setMusicInGame2;
    [SerializeField] private AK.Wwise.State setMusicInGame3;
    [SerializeField] private AK.Wwise.State setMusicInGame4;
    
    private void Start()
    {
        music.Post(player.gameObject);
        setInGame.SetValue();
        setMusicInGame0.SetValue();
    }

    private void StartFade()
    {
        fade.FadeIn();
        Invoke(nameof(TransitionToNextLevel), 2f);
        levelStart.position = new Vector3(levelStart.position.x, levelStart.position.y, player.transform.position.z);
    }

    private void TransitionToNextLevel()
    {
        player.transform.position = levelStart.position;
        player.SetVelocityX(0);
        Invoke(nameof(StartLevel), 1f);
    }

    private void StartLevel()
    {
        fade.FadeOut();
        player.StateMachine.ChangeState(player.IdleState); 
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
