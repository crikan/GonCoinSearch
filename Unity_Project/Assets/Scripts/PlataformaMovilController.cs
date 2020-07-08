using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilController : MonoBehaviour {

    public Transform target;
    public float velocidad;
    private Vector3 start, end;

	// Use this for initialization
	void Start () {
        velocidad = 1.20f;
        start = transform.position;
        end = target.position;
	}
	
	// Update is called once per frame
	void Update () {
        //movimiento de ida
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
        // movimiento de vuelta
        if (transform.position == target.position) {
            if (target.position == start)
            {
                target.position = end;
            }
            else
            {
                target.position = start;

            }
        }
	}
    // cuando el personaje toca la plataforma se convierte en su hijo
    void OnCollisionEnter2D(Collision2D collision) {
        collision.transform.parent = transform;
    }
    // cuando la plataforma llega a su destino y personaje recupera el control sobre su posición
    void OnCollisionExit2D(Collision2D collision) {
        collision.transform.parent = null;
    }

}
