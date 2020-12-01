using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisControl : MonoBehaviour {

    public Gravity orbitted;
    public Rigidbody2D rb;

    Rigidbody2D other;

    float rotSpeed, ellip;

    private void Awake() {
        other = orbitted.GetComponent<Rigidbody2D>();

        rotSpeed = Random.Range(-15, 15);
        ellip = Random.Range(0, 10);
    }

    void FixedUpdate() {
        float distance = Vector2.Distance(rb.position, other.position);
        float orbitSpeed = Mathf.Sqrt(orbitted.getG() * other.mass / distance);
        float modOrbit = orbitSpeed + ellip;

        Vector2 velocity = Vector2.Perpendicular(other.position - rb.position).normalized * modOrbit;
        rb.velocity = velocity;

        transform.Rotate(Vector3.forward * rotSpeed * Time.fixedDeltaTime);
    }
}
