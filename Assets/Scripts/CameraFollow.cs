using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Awake()
    {
        // Trouve l'objet dans la scène qui a un script PlayerController attaché et stocke sa transformation (position, rotation, échelle).
        player = FindObjectOfType<PlayerController>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Calcule et stocke le décalage initial entre la position de cet objet (probablement la caméra) et la position du joueur.
        // Ce décalage sera utilisé pour maintenir une distance constante entre la caméra et le joueur.
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcule la position cible pour cet objet en ajoutant le décalage à la position du joueur.
        // Cela garantit que cet objet suit le joueur tout en maintenant le décalage.
        Vector3 targetpos = player.position + offset;

        // Force la composante x de la position cible à être 0.
        // Cela peut être utilisé pour s'assurer que la caméra reste alignée sur un axe spécifique, par exemple dans un jeu 2D ou un runner latéral.
        targetpos.x = 0;

        // Met à jour la position de cet objet pour qu'elle corresponde à la position cible calculée.
        // Cela déplace effectivement cet objet pour qu'il suive le joueur, tout en respectant le décalage et en restant sur l'axe y-z.
        transform.position = targetpos;
    }
}
