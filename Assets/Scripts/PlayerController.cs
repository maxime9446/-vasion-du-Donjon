using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public float runSpeed;
    public float horizontalSpeed;
    public Rigidbody rb;
    float horizontalInput;

    [SerializeField] private float JumbForce = 350;
    [SerializeField] private LayerMask GroundMask;

    public float speedIncrease;


    private void Awake()
    {
        // Récupère le composant Rigidbody attaché à cet objet pour pouvoir manipuler sa physique.
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Vérifie si le personnage est en vie avant de procéder à tout mouvement.
        if (isAlive)
        {
            // Calcule le vecteur de mouvement vers l'avant.
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime;

            // Calcule le vecteur de mouvement horizontal.
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;

            // Déplace le Rigidbody à sa nouvelle position, en ajoutant les mouvements avant et horizontal à sa position actuelle.
            rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Récupère la valeur d'entrée horizontale (gauche/droite) de l'utilisateur.
        horizontalInput = Input.GetAxis("Horizontal");

        // Calcule la hauteur du joueur en récupérant la taille de son Collider.
        float playerHeight = GetComponent<Collider>().bounds.size.y;

        // Vérifie si le joueur est au sol en lançant un rayon vers le bas à partir de sa position.
        // La longueur du rayon est légèrement plus grande que la moitié de la hauteur du joueur pour s'assurer qu'il touche le sol.
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

        // Si l'utilisateur appuie sur la touche Espace, que le joueur est en vie et au sol, alors le joueur saute.
        if (Input.GetKeyDown(KeyCode.Space) && isAlive && IsGrounded == true) 
        {
            Jump();
        }
    }

    public void Jump()
    {
        SoundManager.PlaySound("Jump");
        // Ajoute une force vers le haut au Rigidbody, ce qui crée l'effet de saut.
        rb.AddForce (Vector3.up * JumbForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Graphic")
        {
            Dead();
        }
        if (collision.gameObject.name == "Coin(Clone)")
        {
           SoundManager.PlaySound("Coin");
           Destroy(collision.gameObject);
           GameManager.MyInstance.Score++;
           runSpeed += speedIncrease;
        }
    }

    public void Dead()
    {
        isAlive = false;
        GameManager.MyInstance.GameoverPanel.SetActive(true);
    }
}
