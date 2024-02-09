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


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            // Calcule le vecteur de mouvement vers l'avant.
            Vector3 forwardMovement = transform.forward * runSpeed * Time.fixedDeltaTime;

            // Calcule le vecteur de mouvement horizontal.
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;

            // Combine les vecteurs de mouvement en les additionnant, puis ajoute le résultat à la position actuelle du Rigidbody pour obtenir la nouvelle position.
            rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isAlive && IsGrounded == true) 
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce (Vector3.up * JumbForce);
    }
}
