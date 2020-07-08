using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaController : MonoBehaviour {


    public static int vidas = 3;
    public Text textoVidas;

	// Use this for initialization
	void Start () {
        ActualizarMarcadorVidas();
	}

    void ActualizarMarcadorVidas() {
        textoVidas.text = "Vidas: " + VidaController.vidas;
    }
	
    public void PerderVida() {
        VidaController.vidas--;
        ActualizarMarcadorVidas();
    }
}
