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
        // R�cup�re le composant Rigidbody attach� � cet objet pour pouvoir manipuler sa physique.
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // V�rifie si le personnage est en vie avant de proc�der � tout mouvement.
        if (isAlive)
        {
            // Calcule le vecteur de mouvement vers l'avant.
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime;

            // Calcule le vecteur de mouvement horizontal.
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;

            // D�place le Rigidbody � sa nouvelle position, en ajoutant les mouvements avant et horizontal � sa position actuelle.
            rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // R�cup�re la valeur d'entr�e horizontale (gauche/droite) de l'utilisateur.
        horizontalInput = Input.GetAxis("Horizontal");

        // Calcule la hauteur du joueur en r�cup�rant la taille de son Collider.
        float playerHeight = GetComponent<Collider>().bounds.size.y;

        // V�rifie si le joueur est au sol en lan�ant un rayon vers le bas � partir de sa position.
        // La longueur du rayon est l�g�rement plus grande que la moiti� de la hauteur du joueur pour s'assurer qu'il touche le sol.
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
        // Ajoute une force vers le haut au Rigidbody, ce qui cr�e l'effet de saut.
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
