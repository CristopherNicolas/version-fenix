using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
class Key: MonoBehaviour
{
    bool open;
    [SerializeField]GameObject cerrojo;
    private void Start()
    {
        //GetComponent<BoxCollider>().isTrigger = true;
        cerrojo.GetComponent<BoxCollider>().isTrigger = true;
    }
    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name ==  cerrojo.name && !open)
        {
            open = true;
            AudioSystem.instance.PonerSonido("key");
            await AbirirPuerta(); 
            
            Destroy(gameObject);
        }  
    }
    [SerializeField] GameObject target;
    public async Task AbirirPuerta()
    {
        var feed = GameObject.Find("feedText").GetComponent<TMP_Text>();
        feed.text = "Se ha abierto una puerta";
        await target.transform.DOMove(new Vector3(0,target.transform.position.y+5,0),2.2f).AsyncWaitForCompletion();
        feed.text = "";
    }
}
