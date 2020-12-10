using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MENU : GameManager
{   
    [Header("GUI Main")]
    [SerializeField] private Button GoToGame = null;



    protected override void Awake() {
        base.Awake();
    }

    protected override void Start(){
        base.Start();
        GoToGame.onClick.RemoveAllListeners();
        GoToGame.onClick.AddListener(()=>GoNextScene());
    }


}
