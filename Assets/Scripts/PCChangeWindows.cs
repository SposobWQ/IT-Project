using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCChangeWindows : MonoBehaviour
{
    [SerializeField] GameObject StorePanel;
    [SerializeField] GameObject InfoPanel;
    [SerializeField] GameObject InfoPanel2;
    
    public void OpenStore()
    {
        StorePanel.SetActive(true);
        InfoPanel.SetActive(false);
        InfoPanel2.SetActive(false);
    }

    public void OpenInfo()
    {
        StorePanel.SetActive(false);
        InfoPanel.SetActive(true);
        InfoPanel2.SetActive(false);
    }

    public void OpenInfo2()
    {
        StorePanel.SetActive(false);
        InfoPanel.SetActive(false);
        InfoPanel2.SetActive(true);
    }

    public void OpenInfo3()
    {
        StorePanel.SetActive(false);
        InfoPanel.SetActive(false);
        InfoPanel2.SetActive(false);
    }
}
