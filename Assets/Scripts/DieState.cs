using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DieState : State{
    
    public DieState(PlayerController player, StateMachine stateMachine) : base(player,stateMachine){

    }

    public override void Enter(){
        base.Enter();

    }
    
    public override void HandleUpdate(){
        //Input
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