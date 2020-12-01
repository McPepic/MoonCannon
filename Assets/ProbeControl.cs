using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeControl : MonoBehaviour {

    public Transform moon;

    public float turnSpeed;

    Vector2 lastVector = Vector2.up;

    public float angle, altitude;
    public float maxAlt;

    public float distance;

    public GameObject destroyed;

    public CameraMove move;
    public CannonControl control;

    bool canDestroy;

    public IEnumerator GetDestroyed() {
        yield return new WaitForSeconds(0.5f);
        canDestroy = true;
    }

    private void LateUpdate() {
        float radius = moon.localScale.x / 2;
        altitude = Vector2.Distance(transform.position, moon.position) - radius;

        Vector2 currVector = (transform.position - moon.position).normalized;

        angle += Vector2.Angle(lastVector, currVector);
        lastVector = currVector;

        float circumference = 2 * Mathf.PI * radius;
        distance = circumference * angle / 360;

        if (altitude > maxAlt) maxAlt = altitude;

        //print($"Altitude: {altitude}\nDistance: {distance}");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroyed();
    }

    public void Destroyed() {
        if (canDestroy) {
            control.ResetCannon();
            canDestroy = false;
        }
    }

    public void Disable() {
        GameObject debris = Instantiate(destroyed, transform.position, Quaternion.Euler(Vector3.forward * Random.Range(0, 360)));
        debris.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;

        gameObject.SetActive(false);
    }
}
