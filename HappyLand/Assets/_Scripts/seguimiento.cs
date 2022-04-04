using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir : MonoBehaviour
{

    public Transform jugador;

    private void LateUpdate()
    {
        Vector3 nuevapocicion = jugador.position;

        nuevapocicion.y = transform.position.y;

        transform.position = nuevapocicion;
    }

}
