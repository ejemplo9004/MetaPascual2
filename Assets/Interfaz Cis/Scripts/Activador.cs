using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
   
    public string[] tags;
    public bool rotarObj = false;
    private float tiempoCD = 1f ;
    public float tiempoAnimEntrada;
    public float tiempoAnimSalida;
    
    public float scaleO;
    public float tiempoEscalaIdle;
    private Vector3 scalaV = new Vector3();
    public bool scalaOA = false;

    public bool activador;
    /*public enum OpcionesMenu { MenuBase, Interfaz1, Interfaz2, Interfaz3 }
    public OpcionesMenu opcion = OpcionesMenu.MenuBase;*/
    public int estado;
    public Material[] material;
    
    [Range(0, 1)]
    public float tScale;
    public AnimationCurve curvaScale;
 
   /* [Range(0, 1)]
    public float tPotition;
    public AnimationCurve curvaPotition;

    */

    public GameObject[] EntrarMenu;
    public GameObject[] SalidaMenu;

    private Activador codeIn;
    private float cronometro;

    void Start()
    {
        
        GetComponentInChildren<Renderer>().material = material[estado];
        cronometro = tiempoCD;
        //this.gameObject.SetActive(activador);
    } 
    void Update()
    {
        if (rotarObj)
        {
            transform.Rotate(new Vector3(0, 20f, 0) * Time.deltaTime);
        }

        if (activador && tScale <= 1)
        {
            tScale += tiempoAnimEntrada * Time.deltaTime;              
        }
        else if (!activador && tScale >= 0 )
        {
            tScale -= tiempoAnimSalida * Time.deltaTime;             
        }

        transform.localScale = Vector3.one * curvaScale.Evaluate(tScale);
        
        scalaV = transform.localScale;
        scaleO = scalaV.y;

        if (scalaOA && scaleO <= 2.5f)
        {
            transform.localScale += Vector3.one * curvaScale.Evaluate(tiempoEscalaIdle);
          
        }
        else if (!scalaOA )
        {
            if (scaleO >= 1.01f && !activador)
            {
                transform.localScale -= Vector3.one * curvaScale.Evaluate(tiempoEscalaIdle) * Time.deltaTime;
            }
            else if(scaleO <= 1.01f && activador)
            {
                transform.localScale += Vector3.one * curvaScale.Evaluate(tiempoEscalaIdle) * Time.deltaTime;
            }    
            
        }


        /*if (activador && tPotition <= 1)
        {
            tPotition += tiempoAnimEntrada * Time.deltaTime;
        }
        else if (!activador && tPotition >= 0)
        {
            tPotition -= tiempoAnimEntrada * Time.deltaTime;
        }


        transform.localPosition = Vector3.one * curvaPotition.Evaluate(tPotition);
        */

        /* Este Si funciona pero el cd no desctiva el collider de los ocultos 
        if (activador)
        {  
            cronometro -= 0.8f * Time.deltaTime;

            if (cronometro > 0 )
            {
                GetComponent<Collider>().enabled = false;
            }
            else if (cronometro <= 0 )
            {
                GetComponent<Collider>().enabled = true;
                cronometro = 0;
            }
        }
        */


            if (!activador)
            {
                GetComponent<Collider>().enabled = false;
                cronometro = tiempoCD;
            }
            if (cronometro > 0 && activador)
            {  
               cronometro -= 0.8f * Time.deltaTime;
            }
            if (cronometro <= 0 && activador)
            {    
                GetComponent<Collider>().enabled = true;
                cronometro = 0;
            }
        
    }

    IEnumerator tiempoSpawn()
    {
        yield return new WaitForSeconds(0.8f);
        ActivarNodos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            scalaOA = true;       
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            scalaOA = false;
            DescativarNodos();
            StartCoroutine(tiempoSpawn());
            cronometro = tiempoCD;

        }

    }
    void ActivarNodos()
    {
        for (int i = 0; i < EntrarMenu.LongLength; i++)
        {         
            codeIn = EntrarMenu[i].GetComponent<Activador>();
            codeIn.activador = true;
            
        }
    }

    void DescativarNodos()
    {
        for (int i = 0; i < SalidaMenu.LongLength; i++)
        {
            codeIn = SalidaMenu[i].GetComponent<Activador>();
            codeIn.activador = false;
            
        }
    }
}
