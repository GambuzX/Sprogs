using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    static public void GameOver(Fighter loser) {
        string winner = (loser is Sprog ? "frolien" : "sprog");
        PlayerPrefs.SetString("winner", winner);
        SceneManager.LoadScene("WinScreen");
    }
}
