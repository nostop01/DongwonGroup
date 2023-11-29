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
    [SerializeField] private bool canShowNextText = false;
    [SerializeField] private float timeBetweenText = 2.0f;
    [SerializeField] private float timeSinceLastText = 0f;

    private void Update()
    {
        if (panel != null)
        {
            if(panel.activeSelf == true)
            {
                timeSinceLastText += Time.deltaTime;
            }

            if (timeSinceLastText >= timeBetweenText)
            {
                canShowNextText = true;
                continueText.text = spaceText;
            }

            if (canShowNextText && Input.GetKeyDown(KeyCode.Space))
            {
                // 스페이스 바를 눌렀을 때 다음 텍스트로 이동

                if (currentTextIndex < messages.Length)
                {
                    ShowNextText();
                }
                else
                {
                    // 모든 텍스트를 출력했을 때 원하는 함수 호출
                    OnAllTextsDisplayed();
                }

                // 텍스트 지우기
                continueText.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("DetectCollider"))
        {
            panel.SetActive(true);
            PlayerStatus.Instance.Pause = true;
        }

        if(other.gameObject.tag == ("EndLine"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void ShowNextText()
    {
        textComponent.text = "";

        // 다음 텍스트를 출력
        textComponent.text = messages[currentTextIndex];
        ++currentTextIndex;

        timeSinceLastText = 0;
        canShowNextText = false;
    }

    public void OnAllTextsDisplayed()
    {
        Destroy(panel);
        enabled = false;
        PlayerStatus.Instance.Pause = false;
    }
}
