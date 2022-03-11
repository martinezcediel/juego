using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vision : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "vision")
        {
            
            Destroy(this.gameObject);
            SceneManager.LoadScene("escena2");
        }
    }
}
