using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    
    public void PlayButtonPress()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
