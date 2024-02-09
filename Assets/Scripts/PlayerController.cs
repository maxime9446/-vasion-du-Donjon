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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
