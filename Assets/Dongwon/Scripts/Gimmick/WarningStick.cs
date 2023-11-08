using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class WarningStick : PoolAble
{
    public MeshRenderer mesh; //투명화 변경을 위한 MeshRenderer
    public GameObject Spear; //소환할 창 오브젝트
    public GameObject Trans; //창 오브젝트 소환할 위치값
    public GameObject Player; //플레이어 오브젝트

    // Start is called before the first frame update
    void OnEnable() //오브젝트 활성화 되었을 떄
    {
        mesh = GetComponent<MeshRenderer>(); //meshRenderer 컴포넌트 찾고

        StartCoroutine(EMarkerGrid()); //코루틴 시작

        //transform.position = Player.transform.position; //경고 막대의 위치는 플레이어 위치랑 동일
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator EMarkerGrid() //코루틴
    {
        int count = 0; //while문 반복 조건용 지역변수

        while (count < 6) //count 값이 6 이상일 때 while문 break
        {
            //투명하게 하는 코드
            Color color1 = mesh.material.color; //지역변수 color1은 찾아둔 MeshRenderer의 머터리얼의 색과 같고
            color1.a = 0; //color1의 알파값은 0임
            mesh.material.color = color1; //MeshRenderer의 머터리얼의 색은 color1값과 같다.
            
            yield return new WaitForSeconds(0.15f); //0.15초 기다려.

            //다시 투명도 올리는 코드
            Color color2 = mesh.material.color;
            color2.a = 0.8f;
            mesh.material.color = color2;

            yield return new WaitForSeconds(0.15f); //0.15초 기다려

            count++; //count에 더해.
        }

        yield return new WaitForSeconds(0.7f); //0.7초 기다려

        var SpearGo = ObjectPoolManager.instance.GetGo("Spear"); //오브젝트 풀
        SpearGo.transform.position = Trans.transform.position; //창을 풀링하고 그 위치는 Trans오브젝트의 트랜스폼 포지션과 동일

        ReleaseObject(); //오브젝트 반환
    }
}
