using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersegueBola : MonoBehaviour
{
    [SerializeField]
    private Transform trfBola;
    [SerializeField]
    private Vector3 distancia;
    [SerializeField]
    private float ftLerpVal;
    [SerializeField]
    private Vector3 posCamera, posAlvo;

    // Start is called before the first frame update
    void Start()
    {
        distancia = trfBola.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {    
        if (!BolaControlador.gameOver)
        {
            Perserguir();
        }
    }

    void Perserguir()
    {
        posCamera = transform.position;
        posAlvo = trfBola.position - distancia;
        posCamera = Vector3.Lerp(posCamera, posAlvo, ftLerpVal);

        transform.position = posCamera; 
    }

}
