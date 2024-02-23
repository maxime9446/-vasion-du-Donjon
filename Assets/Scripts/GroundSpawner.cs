using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;

    Vector3 nextspawnPoint;

    public void spawnTile()
    {
        // Quaternion.identity signifie que l'objet instanci� n'aura pas de rotation.
        GameObject tempGround = Instantiate(groundTilePrefab, nextspawnPoint, Quaternion.identity);
        // Cela suppose que le prefab de la tuile de sol a un enfant dont la position d�termine o� la prochaine tuile doit �tre g�n�r�e.
        nextspawnPoint = tempGround.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Ex�cute une boucle pour g�n�rer 10 tuiles de sol � l'initialisation du jeu.
        for (int i = 0; i < 20; i++)
        {
            spawnTile();
        }
    }
}
