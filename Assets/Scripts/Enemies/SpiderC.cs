using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpiderC : Spider
{
    [SerializeField]
    private PlayerController _player;
    [SerializeField]
    private bool _canFollow = false;
    [SerializeField]
    private Vector2 _target = Vector2.zero;
    [SerializeField]
    private float _changeTime = 3f;
    private float _timer;
    private int _direction = 1;
    private bool _found = false;
    private bool _isRight = true;
    public bool CanFollow { get => _canFollow; set => _canFollow = value; }
    public Vector2 Target { get => _target; set => _target = value; }
    public float ChangeTime { get => _changeTime; set => _changeTime = value; }
    public float Timer { get => _timer; set => _timer = value; }
    public int Direction { get => _direction; set => _direction = value; }
    public bool Found { get => _found; set => _found = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }
    public PlayerController Player { get => _player; set => _player = value; }

    // Start is called before the first frame update
    void Start()
    {
        Rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        if (CanFollow)
        {
            ActiveMovement();
            Debug.Log("Lo sigue");
        }
        else
        {
            PasiveMovement();
            Debug.Log("No lo sigue");
        }
            
    }
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
        _target.x= Target.x + Time.deltaTime * Speedx * Direction;
        Rb2d.MovePosition(Target);
    }
    public override void ActiveMovement()
    {
        Target = Player.transform.position;
        Rb2d.MovePosition(Vector2.MoveTowards((Vector2)transform.position, Target - Vector2.up, Speedx * Time.deltaTime));
        Found = true;
    }
}
