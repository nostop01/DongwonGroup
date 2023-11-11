using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance= container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }

            return instance;
        }
    }
}
