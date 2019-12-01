using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{

    private string winner;

    // Start is called before the first frame update
    void Start()
    {
        winner = PlayerPrefs.GetString("winner");
        print(winner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
