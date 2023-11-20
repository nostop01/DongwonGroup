using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingClick : MonoBehaviour
{
    public Slider[] sliders;
    public float[] Value;

    public Data data = new Data();

    public GameObject popup; //팝업창 넣을 게임 오브젝트
    bool check; //팝업이 열렸는지 아닌지 확인하는 오브젝트

    private void Start()
    {
        DataManager.Instance.LoadGameData();

        for(int i = 0; i< 3; i++)
        {
            sliders[i].value = data.SettingState[i];
        }
    }

    public void ShowPopup() //팝업창 열어주는 함수
    {
        popup.SetActive(true);
        check = true;
    }

    public void ClosePopup() //팝업창 닫아주는 함수
    {
        popup.SetActive(false);
        check = false;

        DataManager.Instance.SaveSettingData(Value);
    }

    void Update()
    {
        for(int i = 0; i< 3; i++)
        {
            Value[i] = (float)sliders[i].value;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(check == true)
            {
                ClosePopup();
            }
            else if(check == false)
            {
                ShowPopup();
            }
        }
    }
}
