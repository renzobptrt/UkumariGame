using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderA : Spider
{
    [SerializeField]
    private Transform _groundDetection;
    [SerializeField]
    private RaycastHit2D _groundInfo;
    [SerializeField]
    private LayerMask _mask;
    private bool _isRight = true;

    public Transform GroundDetection { get => _groundDetection; set => _groundDetection = value; }
    public RaycastHit2D GroundInfo { get => _groundInfo; set => _groundInfo = value; }
    public LayerMask Mask { get => _mask; set => _mask = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }

    // Start is called before the first frame update
    void Start()
    {
        Rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        Collider2d = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public override void Movement()
    {
        //El movimiento siempre sera a la derecha        
        Rb2d.velocity = new Vector2(Speedx, Rb2d.velocity.y);
        //Se creara un rayo invisible hacia abajo para determinar si detecta un piso o no
        GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 1, Mask);
        //Debug.Log(groundInfo.collider.tag);

        if (GroundInfo.collider == null || (GroundInfo.collider.tag.Equals("Ground") && GroundInfo.collider.tag.Equals("Player")))
        {
            if (IsRight == true)
            {
                //Girara a 180° en Y
                transform.eulerAngles = new Vector3(0, -180, 0);
                Speedx = -Speedx;
                IsRight = false;
            }
            else
            {
                //Girara a 0° en Y
                transform.eulerAngles = new Vector3(0, 0, 0);
                Speedx = -Speedx;
                IsRight = true;
            }
        }
    }
}
