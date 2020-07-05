using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoChaoCair : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            rb.useGravity = true;
            Destroy(this.gameObject, 0.5f);
            CriaChao.numChaoCena--;
        }
    }
}
