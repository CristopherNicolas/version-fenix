using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using TMPro;
using System.Threading.Tasks;

public class PuzzleRojo : MonoBehaviour
{
    // todo se produce en base que la luz activada sea roja.
    //dada una cierta cantidad de puntos, pasar por una ruta especifica, en caso de iluminar otro punto no prendido
    // desactivar todos los enemigos de la escena.
    public List<PuzzleRojoPunto> puntosPuzle,puntosRojosAlumbrados;
    public GameObject prefabPuzlePunto,target;
    Vector3 startPos;

    public virtual async void Efecto()
    {
        startPos = target.transform.position;
        // sonido de abrir puerta 
        AudioSystem.instance.PonerSonido("sonido reja");
        target.transform.DOMove(new Vector3(startPos.x, startPos.y + 5, startPos.z), 2);

        var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
        feed.text = "Se ha abierto una puerta";
        await Task.Delay(3000);
        feed.text = "";
    }
    public void ResetearPuzzle()
    {
        puntosRojosAlumbrados.ForEach(p => p.ApagarPunto());
        puntosRojosAlumbrados.Clear();
    }
    public bool Comprobar()
    {
        print($"cuenta en puzzle : {puntosPuzle.Count}  --- alumbrados: {puntosRojosAlumbrados.Count}");
        if (puntosRojosAlumbrados.Count == puntosPuzle.Count)
        {
            return true;
        }
        else return false;
    }

    [ContextMenu("generar puntos")]
    public void GenerarPuntosEnPrefab()
    {
        for (int i = 0; i < 3; i++)
        {
            puntosPuzle.Add(Instantiate(prefabPuzlePunto, transform).GetComponent<PuzzleRojoPunto>());
                
        }
    }
}
    
