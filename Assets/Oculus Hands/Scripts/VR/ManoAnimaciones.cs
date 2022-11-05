using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class ManoAnimaciones : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    Animator animaciones;
    void Start()
    {
        animaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float tv = pinchAnimationAction.action.ReadValue<float>();
        animaciones.SetFloat("Trigger", tv);
        float gv = gripAnimationAction.action.ReadValue<float>();
        animaciones.SetFloat("Grip", gv);
    }
}
