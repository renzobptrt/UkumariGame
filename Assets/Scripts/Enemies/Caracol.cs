using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracol : Enemy
{

    [SerializeField]
    private Transform _GroundDetection;
    [SerializeField]
    private RaycastHit2D _GroundInfo;
    [SerializeField]
    private LayerMask _Mask;
    [SerializeField] 
    private float _DistanceDetection = 2f;
    private bool _isRight = true;
    private bool _isUp = true;

    public Transform GroundDetection { get => _GroundDetection; set => _GroundDetection = value; }
    public RaycastHit2D GroundInfo { get => _GroundInfo; set => _GroundInfo = value; }
    public LayerMask Mask { get => _Mask; set => _Mask = value; }
    public float DistanceDetection { get => _DistanceDetection; set => _DistanceDetection = value; }
    public bool IsRight { get => _isRight; set => _isRight = value; }
    public bool IsUp { get => _isUp; set => _isUp = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Movement()
    {
        Rb2d.gravityScale = 0f;
        //El movimiento siempre sera a la derecha
        Rb2d.velocity = new Vector2(Speedx, Speedy);
        //Se creara un rayo invisible hacia abajo para determinar si detecta un piso o no
        GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, DistanceDetection, Mask);
        if (GroundInfo.collider == null || (GroundInfo.collider.tag != "Ground" && GroundInfo.collider.tag != "Player"))
        {
            if (IsRight == true && IsUp == true)
            {
                GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, DistanceDetection, Mask);
                if (GroundInfo.collider == null || (GroundInfo.collider.tag != "Ground" && GroundInfo.collider.tag != "Player"))
                {
                    //Girara a 90° en Z

                    Debug.Log("hello");
                    transform.eulerAngles = new Vector3(0, 0, -90);
                    //transform.Rotate(new Vector3(0f,0f,-90f));
                    transform.position = transform.position - new Vector3(0f, 0.5f, 0f);
                    Speedx = 0f;
                    Speedy = -0.5f;
                    IsUp = false;

                }
            }
            else if (IsRight == true && IsUp == false)
            {
                //Girara a 90° en Z
                GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.left, DistanceDetection, Mask);
                if (GroundInfo.collider == null || (GroundInfo.collider.tag != "Ground" && GroundInfo.collider.tag != "Player"))
                {
                    Debug.Log("hello1");
                    transform.eulerAngles = new Vector3(0, 0, -180);
                    transform.position = transform.position - new Vector3(0.5f, 0f, 0f);
                    Speedx = -0.5f;
                    Speedy = 0f;
                    IsUp = true;
                    IsRight = false;

                }
            }
            else if (IsRight == false && IsUp == true)
            {
                //Girara a 90° en Z
                GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.up, DistanceDetection, Mask);
                if (GroundInfo.collider == null || (GroundInfo.collider.tag != "Ground" && GroundInfo.collider.tag != "Player"))
                {
                    Debug.Log("hello2");
                    transform.eulerAngles = new Vector3(0, 0, -270);
                    transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
                    Speedx = 0f;
                    Speedy = 0.5f;
                    IsUp = false;

                }
            }
            else if (IsRight == false && IsUp == false)
            {
                GroundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.right, DistanceDetection, Mask);
                if (GroundInfo.collider == null || (GroundInfo.collider.tag != "Ground" && GroundInfo.collider.tag != "Player"))
                {
                    //Girara a 0° en Y
                    Debug.Log("hello3");
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
                    Speedx = 0.5f;
                    Speedy = 0f;
                    IsUp = true;
                    IsRight = true;

                }
            }
        }
    }
}
