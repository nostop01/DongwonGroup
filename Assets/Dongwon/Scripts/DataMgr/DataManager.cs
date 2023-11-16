using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance= container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }

            return instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    string GameDataFileName = "GameData.json";

    public Data data = new Data();

    public void LoadGameData() //데이터 불러오기
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
        }
    }

    public void SaveStageClearData() //스테이지 클리어 여부 데이터 저장하기
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
        print("저장 완료");
        for (int i = 0; i < data.isUnlock.Length; i++)
        {
            print($"{i}번 챕터 잠금 해제 여부 : " + data.isUnlock[i]);
        }
    }

    public void SaveSettingData(float[] Setting) //세팅 데이터 저장하기
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
        print("저장 완료");
        for (int i = 0; i < data.SettingState.Length; i++)
        {
            Setting[i] = data.SettingState[i];
        }
    }

    public void SaveCoinData() //현재 코인 수 저장하기
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string ToJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, ToJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
        print("저장 완료");
        for (int i = 0; i < data.CointCount.Length; i++)
        {
            print($"{i}번 세팅 저장 완료 " + data.CointCount[i]);
        }
    }
}
