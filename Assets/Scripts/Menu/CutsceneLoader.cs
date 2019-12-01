using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneLoader : MonoBehaviour
{

public RawImage rawImage;
public VideoPlayer videoPlayer;
public AudioSource audioSource;

public Text[] texts;
public VideoClip[] vids;

private int count = 0;

  // Use this for initialization
void Start () {

    videoPlayer.isLooping = true;
    rawImage.enabled = false;
    audioSource.Play();


    ChangeClip();

    count++;

    Invoke("ChangeClip",15f);

    Invoke("LoadSelectedScene",30f);

}

void ChangeClip(){
    videoPlayer.clip = vids[count];
    if(count>0){
        texts[count-1].GetComponent<Text>().enabled = false;
    }
    texts[count].GetComponent<Text>().enabled = true;
    StartCoroutine(PlayVideo(videoPlayer));
}

IEnumerator PlayVideo(VideoPlayer vp)
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
}


public void LoadSelectedScene(){
    SceneManager.LoadScene("Game");
}


}
