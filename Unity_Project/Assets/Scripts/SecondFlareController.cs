using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondFlareController : MonoBehaviour {

    public float velocidad;
    //public GameObject gameController;

    // Use this for initialization
    void Start () {
        velocidad = 60f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * velocidad * Time.deltaTime);
    }
    // al entrar en el trigger del resplandor se produce el cambio de escena
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            SceneManager.LoadScene("Game");
        }
        
    }
}
