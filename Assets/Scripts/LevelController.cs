using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    private Animation winAnimation;

    private bool gameover;

    private Sprog sprog;
    private Frolien frolian;

    private void Start() {
        gameover = false;

        winAnimation = GameObject.Find("FatalityAnim").GetComponent<Animation>();
        sprog = GameObject.FindObjectOfType<Sprog>();
        frolian = GameObject.FindObjectOfType<Frolien>();
    }

    private void Update() {
        if(gameover && !winAnimation.isPlaying)
            SceneManager.LoadScene("WinScreen");
    }
    
    public void GameOver(Fighter loser) {
        string winner = (loser is Sprog ? "frolien" : "sprog");
        PlayerPrefs.SetString("winner", winner);

        sprog.toggleComponents(false);
        frolian.toggleComponents(false);

        winAnimation.Play();
        gameover = true;
    }
}
