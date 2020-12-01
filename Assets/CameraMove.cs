using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform probe, moon;

    public float moveSpeed, threshold;

    Vector2 target;
    Vector3 offset;

    private void Start() {
        target = transform.position;
        offset = Vector3.back * 10;
    }

    private void FixedUpdate() {
        transform.position = Vector2.Distance(transform.position, target) <= threshold ?
            (Vector3)Vector2.MoveTowards(transform.position, target, moveSpeed * Vector2.Distance(transform.position, target) * Time.fixedDeltaTime) + offset : Teleport(target);

        transform.up = Vector2.MoveTowards(transform.up, (transform.position - moon.position).normalized, moveSpeed * Time.fixedDeltaTime);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    public void SetTarget(Vector2 target) {
        this.target = target;
    }

    public Vector3 Teleport(Vector2 pos) {
        target = pos;
        return (Vector3)target + offset;
    }
}
