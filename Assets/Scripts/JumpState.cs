using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpState: State{

    private bool isGrounded = false;

    public JumpState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine){
    
    }

    public override void Enter(){
        base.Enter();
        isGrounded = false;
        player.Jump();
    }
    
    public override void HandleUpdate(){
        //Input para proximo estado  
    }

    public override void LogicUpdate(){
        //Condicionales
        if(isGrounded){
            stateMachine.ChangeState(player.ground);
        }
    }

    public override void PhysicsUpdate(){
        //Fisicas
        isGrounded = player.isGrounded;
    }

    public override void Exit(){
        
    }
}