using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCoo : MonoBehaviour
{
    //GameObject coll
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player"|| other.gameObject.name == "HeadCollider")
        {
            Debug.Log("colicion con player");
                //StartCoroutine()
        }

    }

}
