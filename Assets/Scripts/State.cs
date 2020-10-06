public abstract class State{

    protected PlayerController player;
    protected StateMachine stateMachine;

    protected State(PlayerController player, StateMachine stateMachine){
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter(){
        //Entra en el estado
    }

    public virtual void HandleUpdate(){
        //Inputs
    }

    public virtual void LogicUpdate(){
        //Condicionales
    }

    public virtual void PhysicsUpdate(){
        //Fisicas
    }

    public virtual void Exit(){
        //Salida del estado
    }

}