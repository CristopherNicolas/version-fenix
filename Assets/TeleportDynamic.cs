using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class TeleportDynamic : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.CompareTag("Player"))
        {
            print("el player entro al area, desactivando la anterior");
        }
    }
}
