using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthDir : MonoBehaviour {

    public Transform earth, player;

    private void Update() {
        Vector2 dir = earth.position - player.position;

        transform.up = -dir.normalized;
    }
}
