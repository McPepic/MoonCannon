using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Probe")) {
            other.GetComponent<ProbeControl>().Destroyed();
        }
    }
}
