using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int _totalLifes = 0;
    private int _currentLifes = 0;

    public int TotalLifes { get => _totalLifes; set => _totalLifes = value; }
    public int CurrentLifes { get => _currentLifes; set => _currentLifes = value; }
}
