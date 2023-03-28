using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidKillZone : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pigman"))
        {
            Destroy(other.gameObject);
        }
    }
}
