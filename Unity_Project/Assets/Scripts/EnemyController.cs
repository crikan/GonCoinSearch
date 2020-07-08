using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //variable para la posición del player
    public Transform target;
    public float velocidad;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        velocidad = 2f;
	}
	
	// Update is called once per frame
	void Update () {

        //comprobar que el player no ha sido destruido ya
        if (target != null) {

            // el enemigo se mueve desde su posición a la del player a la velocidad indicada
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
            // para que se gire siguiendo al player
            if (transform.position.x < target.position.x) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }


	}
}
