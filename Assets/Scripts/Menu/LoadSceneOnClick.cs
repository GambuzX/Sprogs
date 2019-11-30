using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName = "MainMenu";

    public void LoadSelectedScene(){
        SceneManager.LoadScene(sceneName);
    }
}
