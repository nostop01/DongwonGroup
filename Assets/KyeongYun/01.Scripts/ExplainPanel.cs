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

    public string[] messages; // ���ϴ� �ؽ�Ʈ �޽����� �迭�� ����

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
                // �����̽� �ٸ� ������ �� ���� �ؽ�Ʈ�� �̵�
                ShowNextText();
                // �ؽ�Ʈ �����
                continueText.text = "";
            }
        }
    }

    private void ShowNextText()
    {
        textComponent.text = "";

        if (currentTextIndex < messages.Length)
        {
            // ���� �ؽ�Ʈ�� ���
            textComponent.text = messages[currentTextIndex];
            currentTextIndex++;

            canShowNextText = false;
            timeSinceLastText = 0f;
        }
        else
        {
            // ��� �ؽ�Ʈ�� ������� �� ���ϴ� �Լ� ȣ��
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