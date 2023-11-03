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
    public void Start()
    {
        //PlayerStatus ��ũ��Ʈ�� ã�� onDeath�� �ҷ������ٸ� GameOver(��������)
        //FindObjectOfType<PlayerStatus>().onDeath += GameOver;

        //PlayerStatus ��ũ��Ʈ�� ã�� StageClear �ҷ������ٸ� StageClear(��������)
        //FindObjectOfType<PlayerStatus>().StageClear += StageClear;
    }


    public void GameOver()
    {
        // ���ӿ��� �� �߻��� �̺�Ʈ��
        failPanel.SetActive(true);
    }

    public void StageClear()
    {
        // �������� Ŭ���� �� �߻� �̺�Ʈ
        clearPanel.SetActive(true);
    }
    public void SceneLoad()
    {
        // ���� ���� ���� �ε����� ������
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // ���� ���� ���� �ε����� ����Ͽ� �ε�
        int nextSceneBuildIndex = currentSceneBuildIndex + 1;

        // ������ ������ ���̻� ���� ���� ���� ��� ���� �������� ��ư �����
        if (nextSceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneButton.enabled = false;
        }

        SceneManager.LoadScene(nextSceneBuildIndex);
    }
    public void SceneRetry() // ���� �� �絵�� �� �ٽ� �ҷ�����
    {
        // ���� ���� ���� �ε����� ������
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}