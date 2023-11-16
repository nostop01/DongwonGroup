using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    public float StoneHitMoveSpeed = 4.5f; //돌 장애물에 충돌했을 때 속도
    public float SharkHitMoveSpeed = 4.25f; //상어 장애물에 충돌했을 때 속도
    public float SeaweedHitMoveSpeed = 3.75f; //해초 장애물에 충돌했을 때 속도

    private static ObstacleSystem instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public static ObstacleSystem Instance
    {
        get
        {
            if(instance == null)
            {
                return null;

            }

            return instance;
        }
    }

    public void HitStone()
    {

    }

    public void HitShark()
    {

    }

    public void HitSeaWeed()
    {

    }
}
