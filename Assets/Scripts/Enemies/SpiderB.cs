using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderB : Spider
{
    // Start is called before the first frame update
    private float _down = -1.0f;   //hacia abajo
    [SerializeField]
    private Vector2 _startPoint, _endPoint, _raycastDirection;
    [SerializeField]
    private float _speed, _rage, _rageTimer;
    private float _rageRemainTime; 
    private bool _isOnRage;
    private float _distance;         //distancia entre startPoint y endPoint
    private float _distanceCount;    //comienza en 0 y al igualar a "distance" se invierte la dirección

    public float Down { get => _down; set => _down = value; }
    public Vector2 StartPoint { get => _startPoint; set => _startPoint = value; }
    public Vector2 EndPoint { get => _endPoint; set => _endPoint = value; }
    public Vector2 RaycastDirection { get => _raycastDirection; set => _raycastDirection = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float Rage { get => _rage; set => _rage = value; }
    public float RageTimer { get => _rageTimer; set => _rageTimer = value; }
    public bool IsOnRage { get => _isOnRage; set => _isOnRage = value; }
    public float RageRemainTime { get => _rageRemainTime; set => _rageRemainTime = value; }
    public float Distance { get => _distance; set => _distance = value; }
    public float DistanceCount { get => _distanceCount; set => _distanceCount = value; }

    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        RaycastDirection = new Vector2(0, -1);
        Rb2d.position = StartPoint;
        Distance = StartPoint.y - EndPoint.y;
    }


    void Update()
    {
        move();
        detectPlayer();
    }

    void move()
    {
        if (DistanceCount > Distance)
        {
            Down *= -1;
            DistanceCount = 0;
        }

        if (IsOnRage)
        {
            RageRemainTime -= Time.deltaTime;
            if (RageRemainTime < 0)
            {
                IsOnRage = false;
                RageRemainTime = RageTimer;
                Speed /= Rage;
            }
        }

        Rb2d.position += new Vector2(0, Speed * Down * Time.deltaTime);
        DistanceCount += Speed * Time.deltaTime;
    }

    //Emite un raycast que al detectar al jugador entra en modo rage, multiplica la velocidad y se inicia un contador
    void detectPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(Rb2d.position + Vector2.up * 0.2f, RaycastDirection,
                                            StartPoint.y - EndPoint.y, LayerMask.GetMask("Player"));
        if (hit.collider != null && !IsOnRage)
        {
            RageRemainTime = RageTimer;         //resetea el contador
            Speed *= Rage;
            IsOnRage = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(StartPoint, EndPoint);
    }
}
