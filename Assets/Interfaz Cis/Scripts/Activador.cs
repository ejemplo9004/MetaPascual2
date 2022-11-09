using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
   [Header("BotonesInterfaz")]
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

    public bool estadoSi;
    public int estado;
    public Material[] material;
    
    [Range(0, 1)]
    public float tScale;
    public AnimationCurve curvaScale;


    public GameObject[] EntrarMenu;
    public GameObject[] SalidaMenu;

    private Activador codeIn;
    private float cronometro;

    [Header("Teclado")]
    public Teclado tec;
    public bool TomarDatosTeclado ;

    void Start()
    {
        if (estadoSi)
        {
            GetComponentInChildren<Renderer>().material = material[estado];
        }
        
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
        //-----------------------------------El error de titilar esta aca-------------------------------------
        else if (!scalaOA && !activador)
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
        // ------------------------------------------Hasta acá------------------------------------------------

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
