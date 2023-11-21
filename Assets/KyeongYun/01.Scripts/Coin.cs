using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Score.coinAmount += 1;
        //SFX.SoundPlay();
        Destroy(gameObject);
    }
}
