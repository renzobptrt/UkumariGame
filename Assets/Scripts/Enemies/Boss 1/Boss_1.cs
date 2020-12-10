using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : Enemy
{

    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private Vector2 _target = Vector2.zero;
    [SerializeField]
    private float _changeTime = 3f;
    private float _timer;
    private int _direction = 1;
    private bool _isRight = true;
    [SerializeField]
    private Vector2 _startPoint, _endPoint, _raycastDirection;
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private float _probability=0.5f;
    public Vector2 Target { get => _target; set => _target = value; }
    public float ChangeTime { get => _changeTime; set => _changeTime = value; }
    public float Timer { get => _timer; set => _timer = value; }
    public int Direction { get => _direction; set => _direction = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }
    public PlayerController Player { get => _player; set => _player = value; }
    public float Probability { get => _probability; set => _probability = value; }
    public Vector2 StartPoint { get => StartPoint1; set => StartPoint1 = value; }
    public Vector2 EndPoint { get => EndPoint1; set => EndPoint1 = value; }
    public Vector2 RaycastDirection { get => RaycastDirection1; set => RaycastDirection1 = value; }
    public Vector2 StartPoint1 { get => _startPoint; set => _startPoint = value; }
    public Vector2 EndPoint1 { get => _endPoint; set => _endPoint = value; }
    public Vector2 RaycastDirection1 { get => _raycastDirection; set => _raycastDirection = value; }
    public GameObject Projectile { get => _projectile; set => _projectile = value; }

    public override void PasiveMovement()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Direction = -Direction;
            Timer = ChangeTime;
            if (IsRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                IsRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                IsRight = true;
            }
            
        }
        Target = Rb2d.position;
        _target.x = Target.x + Time.deltaTime * Speedx * Direction;
        Rb2d.MovePosition(Target);
    }
    private void Awake()
    {
        Rb2d = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PasiveMovement();
        detectPlayer();
    }

    void detectPlayer()
    {
        StartPoint = transform.position;
        EndPoint = transform.position + Vector3.down*4f;
        RaycastHit2D hit = Physics2D.Raycast(Rb2d.position + Vector2.up * 0.2f, RaycastDirection,
                                            StartPoint.y - EndPoint.y, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            Debug.Log("Diparar");
            GameObject projectile_object = Instantiate(Projectile, Rb2d.position + Vector2.down, Quaternion.identity);
            Projectile projectile = projectile_object.GetComponent<Projectile>();
            projectile.Launch(Vector2.down, 500f);
        }
    }


    /*código de movimiento aleatorio
     * 
     * Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            if (Random.value > Probability)
            {
                Direction = -Direction;
                Timer = ChangeTime;
                if (IsRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    IsRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    IsRight = true;
                }
            }
            
        }*/
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(StartPoint, EndPoint);
    }
}
