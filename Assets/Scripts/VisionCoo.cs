using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCoo : MonoBehaviour
{
    //GameObject coll
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            Debug.Log("colicion con player");
                //StartCoroutine()
        }

    }
    IEnumerator Vision()
    {
        yield return new WaitForSeconds(3);

    }
}
