using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[Car Col]:Name of the object: " + other.gameObject.name);
    }
}
