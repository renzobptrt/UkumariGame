using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.UIElements;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float _tiempoInicial;
    private float _tiempoFinal;
    private SpriteRenderer _spriteR;
    private int _timer;
    [SerializeField]
    private int _timerAux=20;


    public float TiempoInicial { get => _tiempoInicial; set => _tiempoInicial = value; }
    public float TiempoFinal { get => _tiempoFinal; set => _tiempoFinal = value; }
    public SpriteRenderer SpriteR { get => _spriteR; set => _spriteR = value; }
    public int Timer { get => _timer; set => _timer = value; }
    public int TimerAux { get => _timerAux; set => _timerAux = value; }

    // Start is called before the first frame update
    void Start()
    {
        TiempoInicial = Time.time;
        SpriteR = this.gameObject.GetComponent<SpriteRenderer>();
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Blink();
    }

    public void Blink()
    {
        TiempoFinal = Time.time;
        //Debug.Log(TiempoFinal - TiempoInicial);
        if (TiempoFinal - TiempoInicial > 5)
        {
            Timer++;
            if (Timer % TimerAux == 0)
            {
                this.SpriteR.enabled = !this.SpriteR.enabled;
            }
        }
        if (TiempoFinal - TiempoInicial > 10)
        {
            Destroy(this.gameObject);
        }
    }


}
