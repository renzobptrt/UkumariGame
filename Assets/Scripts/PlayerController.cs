using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController {
    
    [Header("States")]
    public StateMachine movementSM;
    public GroundState ground;
    public JumpState jump;
    public HookState hook;
    public DieState die;

    [Header("Components")]
    public LayerMask mask;
    private RaycastHit2D hit;
    //Objeto joint usado para el pendulo
    public DistanceJoint2D joint;


    [Header("Parameters")]
    public bool isGrounded = false;
    public bool isHook = false;
    [SerializeField] private float distanceDetection = 1f;

    #region Methods

    public void Move(int directionX){
        rb2D.velocity =  new Vector2(speedX * directionX, rb2D.velocity.y);
    }

    public void Jump(){
        rb2D.velocity = new Vector2(rb2D.velocity.x , speedY);
    }

    public void CheckGround(){
        hit = Physics2D.Raycast(this.transform.position, Vector2.down,distanceDetection,mask);
        if(hit.collider != false && (hit.collider.tag.Equals("Ground") || hit.collider.tag.Equals("Wood") || hit.collider.tag.Equals("Earth"))){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
    }

    void Friction(){
        Vector2 frictionVelocity = rb2D.velocity;
        //Friction
        frictionVelocity.x *= 0.75f;
        if (isGrounded)
        {
            rb2D.velocity = frictionVelocity;
        }
    }
    #endregion

    private void Awake() {
        rb2D = this.GetComponent<Rigidbody2D>();
        //joint = this.GetComponent<DistanceJoint2D>();
        //joint.enabled = false;
    }

    private void Start(){
        movementSM = new StateMachine();
        ground = new GroundState(this,movementSM);
        jump = new JumpState(this,movementSM);
        hook = new HookState(this,movementSM);
        die = new DieState(this,movementSM);

        movementSM.Initialize(ground);
    }

    private void Update(){

        movementSM.CurrentState.HandleUpdate();
        movementSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate(){
        Friction();
        CheckGround();
        movementSM.CurrentState.PhysicsUpdate();
    }
}