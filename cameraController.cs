using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform personaje;

    private float TamañoCamara;
    private float alturaPantalla;
    // Start is called before the first frame update
    void Start()
    {
        TamañoCamara = Camera.main.orthographicSize;
        alturaPantalla = TamañoCamara * 2;
    }

    // Update is called once per frame
    void Update()
    {
        calcularPosicionCamara();
    }

    void calcularPosicionCamara()
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + TamañoCamara;

        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}
