using UnityEngine;

public class StateMachine {
    
    //Estado actual
    public State CurrentState { get; private set; }

    //Inicializamos
    public void Initialize(State startingState){
        CurrentState = startingState;
        startingState.Enter();
    }

    //Cambiamos de estado
    public void ChangeState(State newState){
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}