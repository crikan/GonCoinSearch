using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVoladorController : MonoBehaviour {

    public Transform target;
    public float velocidad;
    private Vector3 start, end;
    private SpriteRenderer flip;

    // Use this for initialization
    void Start()
    {
        velocidad = 2f;
        start = transform.position;
        end = target.position;
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento de ida
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
        // movimiento de vuelta
        if (transform.position == target.position)  
        {
            flip.flipX = true;
            if (target.position == start)
            {
                
                target.position = end;
                flip.flipX = false;
            }
            else
            {
                target.position = start;
            }
        }
    }
}
