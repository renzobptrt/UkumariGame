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
    public GameObject HookOBJ;
   
    //Objeto joint usado para el pendulo
    //public GameObject Objhook;
    private bool isHookActived = false;
    public Vector3 Fin { get => _fin; set => _fin = value; }
    public bool IsHook { get => isHook; set => isHook = value; }
    public bool IsHookActived { get => isHookActived; set => isHookActived = value; }

    // public Hook ObjHook { get => _objHook; set => _objHook = value; }

    // [SerializeField]  private Hook _objHook;

    public float distance;
    public Vector3 _fin;
    private Vector3 _inicio;
    public Vector3 _direction;
    public LineRenderer line;  
      
    [Header("Parameters")]
    public float step = 5f;   
    public bool isGrounded = false;
    private bool isHook = false;
    [SerializeField] private float distanceDetection = 1f;

    #region Methods

    public void Move(int directionX){
        Rb2d.velocity =  new Vector2(Speedx * directionX, Rb2d.velocity.y);
    }

    public void Jump(){
        Rb2d.velocity = new Vector2(Rb2d.velocity.x , Speedy);
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

    public void Hook(){
        if (GameObject.Find("HookOB(Clone)") == null)
        {
            Debug.Log("se crea el objeto");
            HookOBJ = Instantiate(HookOBJ,_inicio,Quaternion.identity); // ponerlo en el START y  ocultarlo 
            HookOBJ.GetComponent<HookScript>().caster = this.transform;
            HookOBJ.GetComponent<HookScript>()._Fin =  _fin;
            HookOBJ.GetComponent<HookScript>()._Dir = _direction;
            HookOBJ.GetComponent<HookScript>().player = this;           

        }
        else
        {
            Rb2d.velocity = new Vector2(_direction.x * Speedx, _direction.y * Speedy);
        }
        
        
        
        //Cambia la variable isHook a true del player
        /*
        Joint.enabled = true;
        //Detectamos el punto donde se conecta el pendulo
        Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
        connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
        connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
        //Conectamos el pendulo a ese punto
        Joint.connectedAnchor = connectPoint;
        //Conecta el rigidbody del objeto al pendulo
        Joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
        //La distancia de ese pendeulo sera desde el Player hasta el pivote
        Joint.distance = Vector2.Distance(transform.position, hit.point);*/



    }
    void Friction(){
        Vector2 frictionVelocity = Rb2d.velocity;
        //Friction
        frictionVelocity.x *= 0.75f;
        if (isGrounded)
        {
            Rb2d.velocity = frictionVelocity;
        }
    }
    
    private void OnMouseDrag()
    {   
        //Rb2d.velocity = new Vector2(0, 0);
        // GetComponentInParent<PlayerController>().rb.velocity.y = 0 ;
        //Physics2D.gravity = new Vector2(0f, -4.81f);
        //deshabilito el playerController
        // PlayerController.enabled =false;
        //La variable fin toma la posicion del mouse(y se modifica mientras mueva el mouse)
        Fin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // fin.z = 0;
        //seteo el primer punto de la linea
        line.SetPosition(0, this.transform.position);
        //Lo opuesto al lugar del mouse
        _fin.x =  this.transform.position.x - (_fin.x -  this.transform.position.x);
        _fin.y =  this.transform.position.y - (_fin.y -  this.transform.position.y);
        _fin.z = 0;
        //seteo el segundo punto de la linea lo cual crea la linea
        line.SetPosition(1, Fin);
        if (Input.GetMouseButtonUp(0))
        {            
        Debug.Log("suelta1");
        }
    }
    private void OnMouseUp()
    {
        _inicio = this.transform.position;
        Debug.Log("suelta2");
        //_target = Fin;
        line.SetPosition(0, Fin);
        line.SetPosition(1, Fin);
        distance = (Fin - this.transform.position).magnitude;
        hit = Physics2D.Raycast(transform.position, Fin - transform.position, distance, mask);
        Debug.Log("hook1");
        //Si la colision es diferente de null, el objeto de la colision tiene un rb !=null , el objeto de la colision su tag es Ground
        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            //if(hit.collider != false && hit.collider.tag.Equals("Earth"))
            if (hit.collider.tag.Equals("Earth"))
            {   
                _fin = hit.point;
                _direction = _fin - _inicio;
                _direction = _direction.normalized;
                IsHook = true;
            }
            else
            {
                IsHook = false;
            }

        }
        else
        {
            IsHook = false;
        }
    }
    #endregion

    private void Awake() {
        Rb2d = this.GetComponent<Rigidbody2D>();
        
        line = this.GetComponent<LineRenderer>();
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