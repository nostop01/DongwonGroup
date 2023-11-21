using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PopupSetting : MonoBehaviour
{
    public GameObject Panel;
    public Slider[] slider;

    public float[] value;

    public float Timer = 0;
    public float Times = 3;

    public Data data = new Data();

    private void Start()
    {
        Timer = Times;
        PlayerStatus.Instance.Pause = true;
        Panel.SetActive(false);

        DataManager.Instance.LoadGameData();

        for (int i = 0; i < 3; i++)
        {
            slider[i].value = data.SettingState[i];
        }
    }

    private void Awake()
    {
        DataManager.Instance.LoadGameData();

        for (int i = 0; i < 3; i++)
        {
            slider[i].value = data.SettingState[i];
        }
    }

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            value[i] = (float)slider[i].value;
        }

        if (!PlayerStatus.Instance.Pause && Panel.activeSelf == false)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                PlayerStatus.Instance.Pause = false;
                Timer = Times;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && Panel.activeSelf == false)
        {
            Panel.SetActive(true);
            PlayerStatus.Instance.Pause = true;
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && Panel.activeSelf == true)
        {
            Panel.SetActive(false);
            PlayerStatus.Instance.Pause = false;

            DataManager.Instance.SaveSettingData(value);
        }
        
    }

    public void PopDownClick()
    {
        Panel.SetActive(false);
        PlayerStatus.Instance.Pause = false;

        DataManager.Instance.SaveSettingData(value);
    }
}
