using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HookScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 _Fin, _Dir;
    public Transform caster, collidedWith;
    private LineRenderer line;
    public PlayerController player;
    public bool hook;
    [SerializeField] private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        line = transform.Find("Line").GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        if ((_Fin - transform.position).magnitude >= 0.05)
        {
            Debug.Log((_Fin - transform.position).magnitude);
            line.SetPosition(0, caster.position);
            line.SetPosition(1, transform.position);
            transform.Translate(_Dir * speed * Time.deltaTime);

        }
        else
        {
            player.IsHookActived = true;
            Debug.Log(player.IsHookActived);
        }
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }

}
