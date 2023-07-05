using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerInput))]
public class Personaje : MonoBehaviour
{
    public float velocidad;
    PlayerInput xrInput;
    public AudioSource audioSourceJugador;
    bool estaEnZonaSegura = true, estaAgachado = false;
    Linterna linterna;
    Vector3 offset;

    public async void Start()
    {
        linterna = GameObject.FindObjectOfType<Linterna>();
        xrInput = GetComponent<PlayerInput>();
        audioSourceJugador = GetComponent<AudioSource>();
        offset = transform.GetChild(0).transform.position;

        await Task.Delay(TimeSpan.FromSeconds(audioSourceJugador.clip.length));
    }
    // agacharse
    private void Update()
    {
       
        if (xrInput.actions["triggerPress"].IsPressed() || Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("xr input trigger izquierdo presionado");
            TIPOLINTERNA tIPOLINTERNA = linterna.tipolINTERNA;
            switch (tIPOLINTERNA)
            {
                case TIPOLINTERNA.TipoLinternaRoja:
                    linterna.CambiarTipoDeLinterna(TIPOLINTERNA.TipoLinternaBlanca);
                    break;
                case TIPOLINTERNA.TipoLinternaBlanca:
                    linterna.CambiarTipoDeLinterna(TIPOLINTERNA.TipoLinternaAzul);
                    break;
                case TIPOLINTERNA.TipoLinternaAzul:
                    linterna.CambiarTipoDeLinterna(TIPOLINTERNA.TipoLinternaRoja);
                    break;
                default:
                    break;
            }

            if (xrInput.actions["menu"].IsPressed())
            {
                print("menu activado");
            }

        }
    }
}

