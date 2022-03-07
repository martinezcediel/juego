using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "vision")
        {
            Debug.Log("tocado");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
