using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScavengerController : MonoBehaviour {
    public float velocidad, fuerzaSalto;
    private Rigidbody2D rigidBody;
    private SpriteRenderer flip;
    public AudioSource sonido;
    public AudioClip sonidoSalto, sonidoQuitarVida;
    public GameObject gameController;
    public Animator animator;
    public GameObject arma;
    public VidaController vidas;


    // Use this for initialization
    void Start () {
		velocidad = 10f;
        rigidBody = GetComponent<Rigidbody2D>();
        fuerzaSalto = 7f;
        flip = GetComponent<SpriteRenderer>();
        sonido = GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //desactivamos el arma
        arma.SetActive(false);

        // dar la vuelta según se va  a derecha o izquierda
        if (Input.GetAxis("Horizontal") > 0) {
            //transform.localScale = new Vector3(1, 1, 1);
            flip.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            flip.flipX = true;
        }
        // movimiento
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0)*velocidad*Time.deltaTime;

        // salto: 
        // si se pulsa la flecha hacia arriba y el player está en el suelo le damos un impulso
        if (Input.GetKeyDown(KeyCode.UpArrow) && rigidBody.velocity.y == 0) {
            rigidBody.AddForce(Vector2.up*fuerzaSalto, ForceMode2D.Impulse);
            animator.SetTrigger("SALTAR");
            ReproducirSonidoSalto();
        
        }
        // ataque:
        // si se pulsa la tecla espacio activamos la animación y el arma
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("ATACAR");
            arma.SetActive(true);
        }
		
	}

    // método para asignar el sonido de salto
    public void ReproducirSonidoSalto() {
        sonido.clip = sonidoSalto;
        sonido.Play();
    }

    // método para asignar el clip de sonido al quitar una vida
    public void ReproducirSonidoQuitarVida() {
        sonido.clip = sonidoQuitarVida;
        sonido.Play();
    }
    

    // muerte del player
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {

            vidas.PerderVida();
            ReproducirSonidoQuitarVida();

            

            if (VidaController.vidas == 0) {
                // la cámara deja de ser hijo del player 
                GetComponentInChildren<Camera>().transform.parent = null;
                // arrancar la explosión de partículas
                GetComponentInChildren<ParticleSystem>().Play();
                // el sistema de partículas deja de ser hijo del player
                GetComponentInChildren<ParticleSystem>().transform.parent = null;
                // arrancar el sonido de la explosión llamndo al método incluido en GameController mediante mensaje
                gameController.SendMessage("ReproducirSonidoExplosion");
                // llamamos al método que detiene el respawn de enemigos
                GameObject.FindGameObjectWithTag("Respawn").SendMessage("CancelarEnemigos");

                // destruimos el player 
                Destroy(gameObject);
            }

        }
    }
}
