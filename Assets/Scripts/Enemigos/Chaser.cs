using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//culebron
public class Chaser : Enemigo
{
    public int segundosDeMovimientoMaximo =10;
    public override void SerAlumbrado()
    {
        // no tiene efecto        
    }
    bool haComenzadoElCD = false;
    private void Start() => StartCoroutine(Timer());
    public override  void MoverEnemigo(Vector3 destino)
    {

            base.MoverEnemigo(destino);      
    }
    async void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
            feed.text = "El culebron te deboro";
            await Task.Delay(3500);
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator Timer()
    {
            yield return new WaitUntil(() => puedeMoverse);
        while (true)
        {
            puedeMoverse = false;
            yield return new WaitForSecondsRealtime(segundosDeMovimientoMaximo);
            puedeMoverse = true;
            yield return new WaitForSecondsRealtime(segundosDeMovimientoMaximo);
        }
    }
}
