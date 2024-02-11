using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class DirectorSceneLoader : MonoBehaviour
{

    public bool cutscene = false;
    public PlayableDirector director;

    void OnEnable()
    {
        if(cutscene){director.stopped += OnPlayableDirectorStopped;}
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if(director == aDirector){
            PlayerPrefs.SetInt("Presteige", 1);
            SceneManager.LoadScene(0);
        }
    }

    void OnDisable()
    {
        if(cutscene){director.stopped -= OnPlayableDirectorStopped;}
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}