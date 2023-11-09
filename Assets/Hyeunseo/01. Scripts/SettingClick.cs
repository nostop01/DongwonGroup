using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class SettingClick : MonoBehaviour
{
    public GameObject popup; //�˾�â ���� ���� ������Ʈ
    bool check; //�˾��� ���ȴ��� �ƴ��� Ȯ���ϴ� ������Ʈ

    public void ShowPopup() //�˾�â �����ִ� �Լ�
    {
        popup.SetActive(true);
        check = true;
    }

    public void ClosePopup() //�˾�â �ݾ��ִ� �Լ�
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