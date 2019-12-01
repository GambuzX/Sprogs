using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class WinVideoSelection : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public AudioClip[] audios;
    public VideoClip[] vids;
    private string winner;
    private int winnerSelected;

    private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = GameObject.Find("WinText").GetComponent<Text>();

        winner = PlayerPrefs.GetString("winner");
        if(winner == "frolien"){
            winnerSelected = 1;
            winText.text = "FROLIENS WIN";
        }else{
            winnerSelected = 0;
            winText.text = "SPROGS WIN";
        }
        videoPlayer.isLooping = true;
        rawImage.enabled = false;
        audioSource.Play();

        ChangeClip();

        Invoke("LoadSelectedScene",5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeClip(){
        videoPlayer.clip = vids[winnerSelected];
        audioSource.clip = audios[winnerSelected];
        StartCoroutine(PlayVideo(videoPlayer,audioSource));
    }
    IEnumerator PlayVideo(VideoPlayer vp, AudioSource musicSource)
    {
        vp.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!vp.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.enabled = true;
        rawImage.texture = vp.texture;
        vp.Play();
        musicSource.Play();
    }

    public void LoadSelectedScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
