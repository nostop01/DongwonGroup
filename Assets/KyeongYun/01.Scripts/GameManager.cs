using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string mainSceneName;

    public static GameManager instance;
    public Button nextSceneButton;
    public GameObject clearPanel;
    public GameObject failPanel;
    public GameObject Player;

    private void Awake()
    {
        instance = this;
    }
    public enum GameState
    {
        menu,
        inGame,
        gameOver,
        gameClear,
    }
    public void Update()
    {
        //PlayerStatus 스크립트를 찾아 onDeath가 불러와진다면 GameOver(게임종료)
        //FindObjectOfType<PlayerStatus>().onDeath += GameOver;

        //PlayerStatus 스크립트를 찾아 StageClear 불러와진다면 StageClear(게임종료)
        //FindObjectOfType<PlayerStatus>().StageClear += StageClear;

        if(PlayerStatus.Instance.Death)
        {
            GameOver();
        }

        if(PlayerStatus.Instance.Clear)
        {
            StageClear();
        }
    }

    public void GameOver()
    {
        // 게임오버 시 발생할 이벤트들
        failPanel.SetActive(true);
        
    }

    public void StageClear()
    {
        // 스테이지 클리어 시 발생 이벤트
        clearPanel.SetActive(true);
    }
    public void SceneLoad()
    {
        // 현재 씬의 빌드 인덱스를 가져옴(레벨 씬 순서만 연속적으로 두면 될듯)
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // 다음 씬의 빌드 인덱스를 계산하여 로드
        int nextSceneBuildIndex = currentSceneBuildIndex + 1;

        // 마지막 씬에서 더이상 다음 씬이 없는 경우 다음 스테이지 버튼 사라짐
        if (nextSceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneButton.enabled = false;
        }

        SceneManager.LoadScene(nextSceneBuildIndex);
    }
    public void SceneRetry() // 현재 씬 재도전 시 다시 불러오기
    {
        // 현재 씬의 빌드 인덱스를 가져옴
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
