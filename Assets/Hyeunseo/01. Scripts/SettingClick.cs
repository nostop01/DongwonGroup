using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class SettingClick : MonoBehaviour
{
    public GameObject popup; //팝업창 넣을 게임 오브젝트
    bool check; //팝업이 열렸는지 아닌지 확인하는 오브젝트

    public void ShowPopup() //팝업창 열어주는 함수
    {
        popup.SetActive(true);
        check = true;
    }

    public void ClosePopup() //팝업창 닫아주는 함수
    {
        popup.SetActive(false);
        check = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(check == true)
            {
                popup.SetActive(false);
                check = false;
            }
            else if(check == false)
            {
                popup.SetActive(true);
                check = true;
            }
        }
    }
}
