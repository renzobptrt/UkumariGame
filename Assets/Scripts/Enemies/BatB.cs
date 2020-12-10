using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BatB : Bat
{
    [SerializeField]
    private float _vision;
    [SerializeField]
    private PlayerController _player;
    public float Vision { get => _vision; set => _vision = value; }
    public PlayerController Player { get => _player; set => _player = value; }

    // Start is called before the first frame update
    void Start()
    {
        Rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        if ((Vector3.Distance(transform.position, Target) < Vision))
        {
            ActiveMovement();
        }
        else
            base.Movement();
    }
    public override void ActiveMovement()
    {
        Target = Player.transform.position;
        Rb2d.MovePosition(Vector2.MoveTowards((Vector2)transform.position, Target - Vector2.up, Speedx * Time.deltaTime));
    }
}
