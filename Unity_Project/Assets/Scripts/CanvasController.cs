using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    public Text texto, puntosFinales;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        texto.text = "Puntos: " + PointController.puntos;
        puntosFinales.text = "Has conseguido " + PointController.puntos + " puntos";
		
	}

    public void Reiniciar() {
        SceneManager.LoadScene("Game");
        VidaController.vidas = 3;
    }

    public void Salir() {
        Debug.Log("Has Salido");
        Application.Quit();
    }
}
