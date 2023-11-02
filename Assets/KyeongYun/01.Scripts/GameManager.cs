using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState currentGameState;

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
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {

        }
        if (newGameState == GameState.inGame)
        {

        }
        if (newGameState == GameState.gameOver)
        {

        }
        currentGameState = newGameState;
    }
    private void Start()
    {
        //PlayerStatus 스크립트를 찾아 onDeath가 불러와진다면 GameOver(게임종료)
        //FindObjectOfType<PlayerStatus>().onDeath += GameOver;
        //PlayerStatus 스크립트를 찾아 onDeath가 불러와진다면 StageClear(게임종료)
        //FindObjectOfType<PlayerStatus>().StageClear += StageClear;
        StartGame();
    }

    public void StartGame()
    {
        // 게임 시작 하자마자 실행 할 코드
    }

    public void GameOver()
    {
        // 게임오버 시 발생할 이벤트들
    }

    public void StageClear()
    {
        // 스테이지 클리어 시 발생 이벤트
    }
    public void BackToMenu()
    {

    }
}
