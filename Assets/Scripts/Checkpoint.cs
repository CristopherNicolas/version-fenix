using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Valve.VR.InteractionSystem;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(BoxCollider))]

public class Checkpoint : MonoBehaviour
{
    Player player;
    private IEnumerator Start()
    {
        GetComponent<BoxCollider>().isTrigger=true;
        yield return new WaitForSeconds(5);
        //poner sonido comenzar nivel
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name == "Player" )
        {
            var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
            feed.text = $"Entraste en la zona segura!";
            await Task.Delay(System.TimeSpan.FromSeconds(5));
            feed.text = "";

            PonerEnemigosEnZonaInicial();
            var enemigos = GameObject.FindObjectsOfType<Enemigo>().ToList();
            enemigos.ForEach(e => { e.puedeMoverse = false; 
                e.StopAllCoroutines();
                e.GetComponent<NavMeshAgent>().speed = 0;
            });
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
            feed.text = "Saliste de la zona segura, encuentra a tu hermano!";
            await Task.Delay(System.TimeSpan.FromSeconds(5));
            feed.text = "";
            ActivarMovimientoEnemigos();   
        }
    }
    void ActivarMovimientoEnemigos()
    {
        var enemigos = GameObject.FindObjectsOfType<Enemigo>().ToList();
        enemigos.ForEach(e => e.puedeMoverse=true);
        enemigos.ForEach(e => e.GetComponent<NavMeshAgent>().speed = e.velocidadDeMovimiento);
        
    }
    void PonerEnemigosEnZonaInicial()
    {
        var enemigos = GameObject.FindObjectsOfType<Enemigo>().ToList();
        enemigos.ForEach(e => e.transform.root.transform.position = e.starPos);
    }
    [SerializeField] GameObject puertaZonaSegura;
    Vector3 puertaStarPos;
    

}
