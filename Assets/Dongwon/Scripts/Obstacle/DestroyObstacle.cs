using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") //만약 플레이어란 이름을 가진 오브젝트에 충돌 시
        {
            Destroy(gameObject); //이 장애물 오브젝트를 삭제
        }
    }
}
