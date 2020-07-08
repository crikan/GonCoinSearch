using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void CambioEscena() {
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        Debug.Log("Has Salido");
        Application.Quit();
    }
}
