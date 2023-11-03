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
        // ���� ����� �� �ε�(OnClick ����)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetActiveGameoverUI(bool value)
    {
        // ���ӿ��� UI ���(��ġ �� ���� �Ʒ��� �־�� �ٸ� UI���� ���� ���)
        gameOverUI.SetActive(value);
    }
}