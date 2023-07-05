using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//basilisco
public class Basilisco : Enemigo
{
    //tiempo de reaccion al entrar ala rango
    private async void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name ==("Player"))
        {
            var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
            feed.text = "El carbuclo te ha matado y comido!";
            await Task.Delay(3500);
            SceneManager.LoadScene(0);
        }
    }
    void Start()
    {
        velocidadDeMovimiento = 2;
    }
    public override void MoverEnemigo(Vector3 destino)
    {
        if (GameObject.FindObjectOfType<Linterna>()
            .enemigosDentroDeLaLuzLinterna.Exists(x => x == this.gameObject))
            puedeMoverse = false;
        else {puedeMoverse=true; }
        base.MoverEnemigo(destino);
    }
    public override void SerAlumbrado()
    {
        puedeMoverse = false;
    }
}
