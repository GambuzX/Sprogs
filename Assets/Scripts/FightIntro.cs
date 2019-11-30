using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightIntro : MonoBehaviour
{

    private Animation fightLogoAnimation;

    private Sprog sprog;
    private Frolien frolian;

    // Start is called before the first frame update
    void Start()
    {
        fightLogoAnimation = GameObject.Find("FightImage").GetComponent<Animation>();
        sprog = GameObject.FindObjectOfType<Sprog>();
        frolian = GameObject.FindObjectOfType<Frolien>();

        sprog.gameObject.SetActive(false);
        frolian.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!fightLogoAnimation.isPlaying) {

            sprog.gameObject.SetActive(true);
            frolian.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
