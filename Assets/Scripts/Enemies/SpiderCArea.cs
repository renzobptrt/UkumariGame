using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCArea : MonoBehaviour
{
    [SerializeField]
    private SpiderC _spiderC;

    public SpiderC SpiderC { get => _spiderC; set => _spiderC = value; }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpiderC.CanFollow = true;
            Debug.Log("Entra al área");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpiderC.CanFollow = false;
            Debug.Log("Sale del área");
        }
    }
}
