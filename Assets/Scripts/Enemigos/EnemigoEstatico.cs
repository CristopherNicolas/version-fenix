
using System.Runtime.InteropServices;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//el coo chileno emmi metroid
public class EnemigoEstatico : Enemigo
{
    ///puede vigilar ,alerta
    public bool puedeVigilar = false;
    [SerializeField]float anguloMinimo, anguloMaximo;
    public override void SerAlumbrado()
    {
        Debug.Log("Enemigo estatico alimbrado");
        animator.SetBool("serDetectado", true);
        animator.SetBool("puedeVigilar", false);
               
    }
    public override void DejarDeSerAlumbrado()
    {
        base.DejarDeSerAlumbrado();
    }
    public override void MoverEnemigo(Vector3 destino)
    {
        return;
    }
    IEnumerator  Start()
    {
        int dir = 1;
        while(true)
        {
            while(puedeVigilar)
            {
                yield return new WaitForSeconds(0.01f);
                //rotar segun la rotacion actual   
                transform.Rotate(new Vector3(0, velocidadDeMovimiento*Time.deltaTime*dir, 0));
            }
            yield return new WaitForEndOfFrame();
            if (transform.rotation.y > anguloMaximo) dir = -1;
            else if (transform.rotation.y < anguloMinimo) dir = 1;
        }
    }
}
