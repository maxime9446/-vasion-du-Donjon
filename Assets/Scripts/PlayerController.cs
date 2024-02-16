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

    private int laneIndex = 1; // 0 = gauche, 1 = milieu, 2 = droite
    private float[] lanePositions = new float[] { -3f, 0f, 3f }; // Positions X des trois voies


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
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);
        if (isAlive)
        {
            // Permettre le déplacement à gauche et à droite indépendamment de la condition IsGrounded
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLane(false);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveLane(true);
            }

            // Sauter uniquement si le joueur est au sol
            if (IsGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }
            }



            Vector3 targetPosition = new Vector3(lanePositions[laneIndex], rb.position.y, rb.position.z);
            rb.position = Vector3.MoveTowards(rb.position, targetPosition, Time.deltaTime * 25f); // Déplace le joueur vers la voie cible
        }
    }

    void MoveLane(bool goingRight)
    {
        laneIndex += (goingRight ? 1 : -1);
        laneIndex = Mathf.Clamp(laneIndex, 0, lanePositions.Length - 1); // Garde l'index de la voie dans les limites
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
