using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

    public GameObject enemy;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        StartCoroutine("CrearEnemigos");
		
	}

    IEnumerator CrearEnemigos() {
        // esperamos dos segundos tras el comienzo del juego
        yield return new WaitForSeconds(2f);
        // Instanciamos enemigos mientras dure el juego con una espera random entre ellos
        while (true) {
            Instantiate(enemy, transform.position, enemy.transform.rotation);
            yield return new WaitForSeconds(Random.Range(5,10));
        }
    }
    // método para detener el respawn llamado por ScavengerController
    public void CancelarEnemigos() {
        // detenemos la corutina para dejar de crear enemigos
        StopCoroutine("CrearEnemigos");
        //buscamos los enemigos por tag y los guardamos en un array de GameObjects
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        // recorremos el array y los vamos destruyendo
        for (int i = 0; i < enemigos.Length; i++) {
            Destroy(enemigos[i], 0.2f);
        }
        // llamamos a la corutina de final
        StartCoroutine("FinJuego");

    }
    // corutina de final
    IEnumerator FinJuego() {
        yield return new WaitForSeconds(1.5f);
        // activamos el panel de GameOver
        panel.SetActive(true);
    }
}
