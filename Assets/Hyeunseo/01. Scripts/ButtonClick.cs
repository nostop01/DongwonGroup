using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public string scenename;
    public void Click()
    {
        SceneManager.LoadScene(scenename);
    }
}
