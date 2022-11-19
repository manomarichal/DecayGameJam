using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Player player;
    public Fade fade;
    
    [Header("Data")]
    [SerializeField] private PlayerData data0;
    [SerializeField] private PlayerData data1;
    [SerializeField] private PlayerData data2;
    [SerializeField] private PlayerData data3;

    [Header("Music")]
    public Transform levelStart;
    public AK.Wwise.Event music;
    
    [SerializeField] private AK.Wwise.State setInGame;
    [SerializeField] private AK.Wwise.State setMenu;

    [SerializeField] private AK.Wwise.State setMusicInGame0;
    [SerializeField] private AK.Wwise.State setMusicInGame1;
    [SerializeField] private AK.Wwise.State setMusicInGame2;
    [SerializeField] private AK.Wwise.State setMusicInGame3;
    [SerializeField] private AK.Wwise.State setMusicInGame4;

    private Dictionary<int, PlayerData> _levelData = new Dictionary<int, PlayerData>();
    private int _currentLevel;
    private void Start()
    {
        music.Post(player.gameObject);
        setInGame.SetValue();
        setMusicInGame0.SetValue();
        
        _levelData.Add(0, data0);
        _levelData.Add(1, data1);
        _levelData.Add(2, data2);
        _levelData.Add(3, data3);
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

        _currentLevel += 1;
        
        Invoke(nameof(StartLevel), 1f);
    }

    private void StartLevel()
    {
        fade.FadeOut();
        
        player.SetData(_levelData[_currentLevel]);
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
