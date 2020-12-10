using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour
{   
    [Header("Paneles")]
    [SerializeField] private RectTransform _guiMain = null;
    [SerializeField] private RectTransform _guiSettings = null;
    [SerializeField] private RectTransform _guiCredits = null;
    [SerializeField] private Vector2 _initialPosGuiMain = Vector2.zero;
    [SerializeField] private Vector2 _initialPosGuiSettings = Vector2.zero;
    [SerializeField] private Vector2 _initialPosGuiCredits = Vector2.zero;
    
    void Start()
    {
        _guiMain.DOAnchorPos(Vector2.zero,0.25f);
    }

    public void SettingsButton(){
        _guiMain.DOAnchorPos(_initialPosGuiMain,0.25f);
        _guiSettings.DOAnchorPos(Vector2.zero,0.25f);
    }

    public void CloseSettingsButton(){
        _guiMain.DOAnchorPos(Vector2.zero,0.25f);
        _guiSettings.DOAnchorPos(_initialPosGuiSettings,0.25f);
    }

    public void CreditsButton(){
        _guiMain.DOAnchorPos(_initialPosGuiMain,0.25f);
        _guiCredits.DOAnchorPos(Vector2.zero,0.25f).SetDelay(0.25f);
    }

    public void CloseCreditsButton(){
        _guiMain.DOAnchorPos(Vector2.zero,0.25f).SetDelay(0.25f);
        _guiCredits.DOAnchorPos(_initialPosGuiCredits,0.25f);
    }

}
