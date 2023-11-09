using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryImagePanel : MonoBehaviour
{
    public TMP_Text continueText;
    public GameObject panel;
    public string spaceText;
    public string nextScene;
    private float timeSinceLastText = 0f;
    private bool isCanMoveToNext = false;
    
    void Update()
    {
        if (panel != null)
        {
            timeSinceLastText += Time.deltaTime;

            if (timeSinceLastText >= 2)
            {
                continueText.text = spaceText;
                isCanMoveToNext = true;
            }
            if(isCanMoveToNext == true && Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
