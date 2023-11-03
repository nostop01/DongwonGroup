using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StagePanelViewer : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void PanelLoad()
    {
        panel.SetActive(true);
    }
    public void PanelClose()
    {
        panel.SetActive(false);
    }
}
