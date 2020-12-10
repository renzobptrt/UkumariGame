using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour 
{
    [Header("Settings")]
    [SerializeField] private Slider[] SliderMusic = null;
    [SerializeField] private Button[] MuteMusic = null;
    [SerializeField] private Button GoToMenu = null;
    [SerializeField] private GameManager GameManager = null;

    void Awake() {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    void Start(){
        SoundManager.instance.StartSliders(SliderMusic[0], SliderMusic[1]);
        SliderMusic[0].onValueChanged.AddListener (delegate {SetMusicVolumen(SliderMusic[0].value);});
        SliderMusic[1].onValueChanged.AddListener (delegate {SetSfxVolumen(SliderMusic[1].value);});
        MuteMusic[0].onClick.RemoveAllListeners();
        MuteMusic[0].onClick.AddListener(()=>MuteMusicVolumen(SliderMusic[0]));
        MuteMusic[1].onClick.RemoveAllListeners();
        MuteMusic[1].onClick.AddListener(()=>MuteSfxVolume(SliderMusic[1]));
        GoToMenu.onClick.RemoveAllListeners();
        GoToMenu.onClick.AddListener(()=>GameManager.GoMenuScene());
    }


    public void SetMusicVolumen(float volume){
        SoundManager.instance.SetMusicVolumen(volume);
    }

    public void SetSfxVolumen(float volume){
        SoundManager.instance.SetSfxVolumen(volume);
    }
    
    public void MuteMusicVolumen(Slider musicSlider){
        SoundManager.instance.MuteMusicVolumen(musicSlider);
    }

    public void MuteSfxVolume(Slider sfxSlider){
        SoundManager.instance.MuteSfxVolume(sfxSlider);
    }
}
