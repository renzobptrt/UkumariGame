using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundState : State{

    //Movement settings
    protected float speed;

    //Inputs
    private bool isRight;
    private bool isLeft;
    private bool isJump;
    private bool isHook;

    public GroundState(PlayerController player, StateMachine stateMachine) : base(player, stateMachine){
    
    }

    public override void Enter(){
        base.Enter();
        //Cuando entra al estado...
        isRight = false;
        isLeft = false;
        isJump = false;
        isHook = false;
    }

    public override void HandleUpdate(){
        //Input
        base.HandleUpdate();    
        isRight = Input.GetKey(KeyCode.D);
        isLeft = Input.GetKey(KeyCode.A);
        isJump = Input.GetKey(KeyCode.Space);
        isHook = player.IsHook;
        
    }

    public override void LogicUpdate(){
        //Condicionales
        base.LogicUpdate();
        if(isJump){
            stateMachine.ChangeState(player.jump);
        }else if (isHook){
            stateMachine.ChangeState(player.hook);
        }
    }

    public override void PhysicsUpdate(){
        //Fisicas
        base.PhysicsUpdate();
        if(isRight){
            Debug.Log("Moviendo a la derecha");
            player.Move(1);
        }else if(isLeft){
            Debug.Log("Moviendo a la izquierda");
            player.Move(-1);
        }
    }

    public override void Exit(){
        base.Exit();
    }          
    
}