using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookState : State{


    /*//Linea visual del pendulo
    public LineRenderer line;
    //Componente que permite detectar la colision
    private RaycastHit2D hit;
    //Distancia del pendulo
    private float distance = 0f;
    
    //Capa de colision
    public LayerMask mask;
    //Cuanto va a disminuir la distancia del pendulo por cada frame
    public float step = 0.2f;

    //Martin
    //Punto inicial del player(gancho/linea)
    private Vector2 inicio;
    //Punto final del gancho/linea (varía mientras este arrastrandose el mouse con el clic presionado)
    private Vector2 fin;
    //Punto final a donde se dirige el player
    private Vector2 target;
    //Variable que permite activar el movimiento del hook   
    public bool isHook = false;
    //Variable que permitira guardar la velocidad del player
    private Vector2 vel;

    //Gancho
    public GameObject hookGO;*/



    public HookState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine){
    
    }

    public override void Enter(){
        base.Enter();
    }

    public override void HandleUpdate(){
        
    }

    public override void LogicUpdate(){
        //Condicionales
    }

    public override void PhysicsUpdate(){
        //Fisicas
    }

    public override void Exit(){
        
    }

}