using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizador : MonoBehaviour
{
    public GameObject[] cabezas;
    public GameObject[] cuerpos;

    void Start()
    {
        int numero = Random.Range(0, cabezas.Length);
        for (int i = 0; i < cabezas.Length; i++)
        {
            cabezas[i].SetActive(i == numero);
        }
        numero = Random.Range(0, cuerpos.Length);
        for (int i = 0; i < cabezas.Length; i++)
        {
            cuerpos[i].SetActive(i == numero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
