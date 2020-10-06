using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float _speedx;
    [SerializeField]
    private float _speedy;
    private int _life;
    private Vector3 _initialPosition;
    private Rigidbody2D _rb2d;
    private Animator _anim;
    private Collider2D _collider;

    public Vector3 InitialPosition { get => _initialPosition; set => _initialPosition = value; }
    public int Life { get => _life; set => _life = value; }
    public float Speedy { get => _speedy; set => _speedy = value; }
    public float Speedx { get => _speedx; set => _speedx = value; }
    public Rigidbody2D Rb2d { get => _rb2d; set => _rb2d = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public Collider2D Collider { get => _collider; set => _collider = value; }


    // Start is called before the first frame update
    void Start()
    {
        Rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        Anim = this.gameObject.GetComponent<Animator>();
        Collider = this.gameObject.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Movement()
    {

    }
}
