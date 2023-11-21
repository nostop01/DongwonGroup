using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathStopBGM : MonoBehaviour
{
    public AudioSource Sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.Instance.Death)
        {
            Sounds.Stop();
        }
        if(PlayerStatus.Instance.Clear) 
        {
            Sounds.Stop();
        }
    }
}
