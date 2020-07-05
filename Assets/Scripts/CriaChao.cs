using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaChao : MonoBehaviour
{
    [SerializeField]
    private GameObject chao;
    [SerializeField]
    private GameObject moeda;
    [SerializeField]
    private float tamanhoX;
    [SerializeField]
    private float tamanhoZ;
    [SerializeField]
    private Vector3 posUltima;

    [SerializeField]
    private int limiteChao;
    public static int numChaoCena;

    void Start()
    {
        posUltima = chao.transform.position;
        tamanhoX = chao.transform.localScale.x;
        tamanhoZ = chao.transform.localScale.z;
        numChaoCena = 0;
        StartCoroutine(CriaChaoInGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CriaX()
    {
        Vector3 tempPos = posUltima;
        tempPos.x += tamanhoX;
        posUltima = tempPos;
        Instantiate (chao, tempPos, Quaternion.identity);

        int rand = Random.Range(0,5);

        if (rand <= 2)
        {
            Instantiate(moeda, new Vector3(tempPos.x, tempPos.y + 0.2f, tempPos.z), moeda.transform.rotation);
        }
    }

    void CriaZ()
    {
        Vector3 tempPos = posUltima;
        tempPos.z += tamanhoZ;
        posUltima = tempPos;
        Instantiate(chao, tempPos, Quaternion.identity);

        int rand = Random.Range(0, 5);

        if (rand <= 2)
        {
            Instantiate(moeda, new Vector3(tempPos.x, tempPos.y + 0.2f, tempPos.z), moeda.transform.rotation);
        }
    }

    void CriaChaoXouZ()
    {
        int temp = Random.Range(0, 10);

        if (numChaoCena < limiteChao)
        {
            if (temp < 5)
            {
                CriaX();
                numChaoCena++;
            }
            else if (temp >= 5)
            {
                CriaZ();
                numChaoCena++;
            }
        }
        

    }

    IEnumerator CriaChaoInGame()
    {
        while (BolaControlador.gameOver != true)
        {
            yield return new WaitForSeconds(0.2f);
            CriaChaoXouZ();
        }
    }
}
