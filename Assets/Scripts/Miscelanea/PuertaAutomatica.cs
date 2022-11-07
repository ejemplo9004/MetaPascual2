using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAutomatica : MonoBehaviour
{
    public float        rango = 2;
    public Animator     animaciones;
    public Transform    objetivo;

    IEnumerator Start()
    {
        float r2 = rango * rango;
        if (animaciones != null && objetivo != null)
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                animaciones.SetBool("cerca", (transform.position - objetivo.position).sqrMagnitude < r2);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
