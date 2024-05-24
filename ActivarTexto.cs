using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarTexto : MonoBehaviour
{
    public GameObject texto;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            texto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            texto.SetActive(false);
        }

    }

}
