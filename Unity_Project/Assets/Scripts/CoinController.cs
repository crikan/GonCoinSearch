using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    //public float velocidad;
    public GameObject gameController;
  

    // Use this for initialization
    void Start () {
        //velocidad = 60f;
        gameController = GameObject.FindGameObjectWithTag("GameController");

    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.down * velocidad * Time.deltaTime);
		
	}
    // al colisionar con la moneda...
    void OnTriggerEnter2D(Collider2D other) {
        // comprobamos que la colisión se ha producido con el player y no con un enemigo
        if (other.tag == "Player") {
            // reproducimos sonido
            gameController.SendMessage("ReproducirSonidoMoneda");
            // sumamos los puntos
            PointController.puntos += 5;
            // actualizamos la puntuación máxima
            gameController.SendMessage("ActualizarMaxScore");
            // hacemos desaparecer la moneda
            Destroy(gameObject);
        }
        
    }
}
