using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{   
    [Header("Position Setting")]
    [SerializeField]
    private Vector3 _initialPosition;

    [Header("Speed Settings")]
    [SerializeField]
    private float _speedx = 5f;
    [SerializeField]
    private float _speedy = 5f;

    [Header("Components")]
    private Rigidbody2D _rb2d;
    private Collider2D _collider2d;
    private HealthManager _healthMG;

    public Vector3 InitialPosition { get => _initialPosition; set => _initialPosition = value; }
    public float Speedx { get => _speedx; set => _speedx = value; }
    public float Speedy { get => _speedy; set => _speedy = value; }
    public Rigidbody2D Rb2d { get => _rb2d; set => _rb2d = value; }
    public Collider2D Collider2d { get => _collider2d; set => _collider2d = value; }
    public HealthManager HealthMG { get => _healthMG; set => _healthMG = value; }

    public virtual void Movement()
    {

    }

    public virtual void Dead()
    {

    }
}
