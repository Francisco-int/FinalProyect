using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;  // Referencia al transform del jugador a seguir
    public float smoothSpeed = 0.125f;  // Velocidad de suavizado del seguimiento
    public Vector3 offset;  // Offset o desplazamiento de la cámara respecto al jugador

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
