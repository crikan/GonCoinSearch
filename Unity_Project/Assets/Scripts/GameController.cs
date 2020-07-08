using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private AudioSource sonido;
    public AudioClip sonidoExplosion;
    public Text maxScore;

	// Use this for initialization
	void Start () {

        sonido = GetComponent<AudioSource>();
        maxScore.text = "Max: " + GetMaxScore();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReproducirSonidoMoneda() {
        sonido.Play();
    }

    public void ReproducirSonidoExplosion()
    {
        sonido.clip = sonidoExplosion;
        sonido.Play();
    }

    // actualizamos la puntuación máxima
    public void ActualizarMaxScore() {
        if (PointController.puntos > GetMaxScore()) {
            // cambiamos el texto de la UI
            maxScore.text = "Max: " + PointController.puntos.ToString();
            // guardamos el nuevo record en el registro 
            SaveMaxScore(PointController.puntos);
        }
    }
    // getter que consulta el registro de Windows y nos devuelve el valor asociado a la referencia que le pasamos
    public int GetMaxScore() {
        return PlayerPrefs.GetInt("Max Score", 0);
    }
    // setter para guardar en el registro la puntuación máxima
    public void SaveMaxScore(int puntos) {
        PlayerPrefs.SetInt("Max Score", puntos);
    }
}
