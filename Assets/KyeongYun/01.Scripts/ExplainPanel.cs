using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ExplainPanel : MonoBehaviour
{
    public TMP_Text textComponent;
    public TMP_Text continueText;
    public GameObject panel;
    public string spaceText;
    public string sceneName;

    public string[] messages; // 원하는 텍스트 메시지를 배열로 저장

    private int currentTextIndex = 0;
    private bool canShowNextText = false;
    private float timeBetweenText = 2.0f;
    private float timeSinceLastText = 0f;

    private void Update()
    {
        if (panel != null)
        {
            timeSinceLastText += Time.deltaTime;

            if (timeSinceLastText >= timeBetweenText)
            {
                canShowNextText = true;
                continueText.text = spaceText;
            }

            if (canShowNextText && Input.GetKeyDown(KeyCode.Space))
            {
                // 스페이스 바를 눌렀을 때 다음 텍스트로 이동
                ShowNextText();
                // 텍스트 지우기
                continueText.text = "";
            }
        }
    }

    private void ShowNextText()
    {
        textComponent.text = "";

        if (currentTextIndex < messages.Length)
        {
            // 다음 텍스트를 출력
            textComponent.text = messages[currentTextIndex];
            currentTextIndex++;

            canShowNextText = false;
            timeSinceLastText = 0f;
        }
        else
        {
            // 모든 텍스트를 출력했을 때 원하는 함수 호출
            OnAllTextsDisplayed();
        }
    }

    public void OnAllTextsDisplayed()
    {
        Destroy(panel);
        enabled = false;
        SceneManager.LoadScene(sceneName);
    }
}
