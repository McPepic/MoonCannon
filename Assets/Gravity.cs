using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public Rigidbody2D rb;

    const float G = .667f;

    public static List<Gravity> attractors;

    public float getG() {
        return G;
    }

    void FixedUpdate() {
        foreach (Gravity gravity in attractors) {
            if(gravity != this) Attract(gravity);
        }
    }

    void OnEnable() {
        if (attractors == null) attractors = new List<Gravity>();

        attractors.Add(this);
    }

    void OnDisable() {
        attractors.Remove(this);
    }

    void Attract(Gravity objToAttract) {
        Rigidbody2D otherRB = objToAttract.rb;

        Vector2 dir = rb.position - otherRB.position;
        float dist = dir.magnitude;

        if (dist == 0) return;

        float forceMag = G * (rb.mass * otherRB.mass) / Mathf.Pow(dist, 2);
        Vector2 force = dir.normalized * forceMag;

        otherRB.AddForce(force);
    }
}
