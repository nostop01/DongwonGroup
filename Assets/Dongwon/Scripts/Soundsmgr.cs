using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soundsmgr : MonoBehaviour
{
    private void Awake()
    {
        var SoundManager = FindObjectsOfType<Soundsmgr>();
        
        if(SoundManager.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Destroy(gameObject);
        }
    }
}
