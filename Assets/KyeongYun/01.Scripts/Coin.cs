using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.coinAmount += 1;
        Destroy(gameObject);
        SFX.SoundPlay();
    }
}
