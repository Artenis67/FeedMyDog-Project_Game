using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursorHorizontal : MonoBehaviour
{
    void Update()
    {
        // Récupérer la position de la souris
        Vector3 mousePosition = Input.mousePosition;

        // Convertir la position de la souris de l'écran vers le monde
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        gameObject.transform.position = new Vector3(worldMousePosition.x, transform.position.y, transform.position.z);
    }
}
