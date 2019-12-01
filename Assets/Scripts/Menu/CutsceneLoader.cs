using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneLoader : MonoBehaviour
{

public RawImage rawImage;
public VideoClip[] vids;
public VideoPlayer videoPlayer;
public AudioSource audioSource;

private int count = 0;

  // Use this for initialization
void Start () {

    DontDestroyOnLoad(audioSource);

    ChangeClip();

    count++;

    Invoke("ChangeClip",15f);
}

void ChangeClip(){
    videoPlayer.clip = vids[count];
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
    rawImage.texture = vp.texture;
    vp.Play();
    audioSource.Play();
}



}
