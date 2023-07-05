using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionCoo : MonoBehaviour
{
    //GameObject coll
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name=="Player"|| other.transform.root.name == "HeadCollider")
        {
            Debug.Log("colicion con player");
            StartCoroutine(Perder());
        }

    }
    IEnumerator Perder()
    {
        var feedText = GameObject.Find("feedText").GetComponent<TMP_Text>();
        feedText.text = "Has perdido, el Coo te ha visto, ten cuidado con su area de vision";
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
