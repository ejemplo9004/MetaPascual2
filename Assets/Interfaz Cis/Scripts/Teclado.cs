using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado : MonoBehaviour
{
    public string[] tags;
    public string letra;

    Vector3 tama�oBase;
    Vector3 tama�oMax = new Vector3(120f,120f,120f);

    public float detener = 120f;
    public bool Crece;

    void Start()
    {
        letra = gameObject.name;

        tama�oBase = gameObject.GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(tama�oBase+ " de "+ letra);
        if (Crece)
        {
            transform.localScale += (new Vector3(5f, 5f, 5f) * Time.deltaTime);
            if (detener >= tama�oMax.y)
            {
                transform.localScale = tama�oMax;
                
            }
        }
        if (!Crece)
        {
           
              transform.localScale = tama�oBase;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            Crece = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            Crece = false;
            Debug.Log(letra);
        }
    }
  
}
