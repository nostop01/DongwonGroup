using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private UIManager instance;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameRestart()
    {
        // 게임 재시작 신 로드(OnClick 연동)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetActiveGameoverUI(bool value)
    {
        // 게임오버 UI 출력(배치 시 가장 아래에 있어야 다른 UI보다 위에 출력)
        gameOverUI.SetActive(value);
    }
}
