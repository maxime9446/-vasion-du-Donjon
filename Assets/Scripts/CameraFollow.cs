using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Awake()
    {
        // Trouve l'objet dans la sc�ne qui a un script PlayerController attach� et stocke sa transformation (position, rotation, �chelle).
        player = FindObjectOfType<PlayerController>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Calcule et stocke le d�calage initial entre la position de cet objet (probablement la cam�ra) et la position du joueur.
        // Ce d�calage sera utilis� pour maintenir une distance constante entre la cam�ra et le joueur.
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcule la position cible pour cet objet en ajoutant le d�calage � la position du joueur.
        // Cela garantit que cet objet suit le joueur tout en maintenant le d�calage.
        Vector3 targetpos = player.position + offset;

        // Force la composante x de la position cible � �tre 0.
        // Cela peut �tre utilis� pour s'assurer que la cam�ra reste align�e sur un axe sp�cifique, par exemple dans un jeu 2D ou un runner lat�ral.
        targetpos.x = 0;

        // Met � jour la position de cet objet pour qu'elle corresponde � la position cible calcul�e.
        // Cela d�place effectivement cet objet pour qu'il suive le joueur, tout en respectant le d�calage et en restant sur l'axe y-z.
        transform.position = targetpos;
    }
}
