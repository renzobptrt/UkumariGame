using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquín : MonoBehaviour
{
    private float _tiempoInicial;
    private float _tiempoFinal;
    private SpriteRenderer _spriteR;
    private Color _color;

    public float TiempoInicial { get => _tiempoInicial; set => _tiempoInicial = value; }
    public float TiempoFinal { get => _tiempoFinal; set => _tiempoFinal = value; }
    public SpriteRenderer SpriteR { get => _spriteR; set => _spriteR = value; }
    public Color Color { get => _color; set => _color = value; }

    // Start is called before the first frame update
    void Start()
    {
        TiempoInicial = Time.time;
        SpriteR = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFinal = Time.time;
        Debug.Log(TiempoFinal - TiempoInicial);
        if (TiempoFinal - TiempoInicial > 5)
        {
            Color = SpriteR.color;
        }
        if (TiempoFinal - TiempoInicial > 10)
        {
            Destroy(this.gameObject);
        }
    }


}
