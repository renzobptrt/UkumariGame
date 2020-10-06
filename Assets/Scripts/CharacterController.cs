using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{   
    [Header("Position Setting")]
    protected Vector3 initialPosition;

    [Header("Speed Settings")]
    protected float speedX = 5f;
    protected float speedY = 5f;

    [Header("Components")]
    protected Rigidbody2D rb2D;

}
