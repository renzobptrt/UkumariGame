using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{   
    
    [Header("Scenas")]
    [SerializeField] private string _menuScene = string.Empty;
    public string MenuScene { get => _menuScene; set =>_menuScene = value;}
    [SerializeField] private string _nextScene = string.Empty;
    public string NextScene { get => _nextScene; set => _nextScene = value;}

    [Header("Audio")]
    private string _backgroundMusic = string.Empty;
    public string BackgroundMusic { get => _backgroundMusic; set => _backgroundMusic = value;}
    public string[] _sfxMusic = null;
    public string[] SfxMusic { get => _sfxMusic; set=> _sfxMusic = value;}
    
    private string ScriptName = string.Empty;

    protected virtual void Awake() {
        ScriptName = this.GetType().Name;
        print(ScriptName);
    }

    protected virtual void Start(){
        PlayBackground();
    }

    public void GoMenuScene(){
        SceneManager.LoadScene(MenuScene);
    } 

    public void GoNextScene(){
        SceneManager.LoadScene(NextScene);
    }

    public void PlayBackground(){
        string FolderBackgroundName = GetName("background");
        SoundManager.instance.PlayBackground(FolderBackgroundName);
    }

    public void PlaySFX(string _nameSfx){
        string FolderSfxName = GetName(_nameSfx);
        SoundManager.instance.PlaySfx(FolderSfxName);
    }

    
    string GetName(string name){
        string NameToGet = string.Empty;
        NameToGet = "sounds/";
        for(int i=2; i<= ScriptName.Length; i += 2)
            NameToGet += ScriptName.Substring(0,i) + "/";
        NameToGet += name;
        return NameToGet;
    }

    protected void GoToExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif   
    }

}