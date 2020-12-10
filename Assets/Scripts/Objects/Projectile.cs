using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;

    public Rigidbody2D Rigidbody2d { get => _rigidbody2d; set => _rigidbody2d = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Launch(Vector2 direction, float force)
    {
        Rigidbody2d.AddForce(direction * force);
    }
}
