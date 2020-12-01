using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// spacebar->set position, set velocity, enable, reset altitude & distance, stop rotating
public class CannonControl : MonoBehaviour {

    public CameraMove cam;
    public ProbeControl player;
    public CircleSlider slider;

    public bool isRotating;
    public float rotSpeed, minValue, maxValue;
    private float zRot;

    public float launchSpeed;

    public bool targetPlayer;

    private void Start() {
        ResetCannon();
        player.gameObject.SetActive(false);
    }

    /* Rotate cannon & wait for input
     * Input -> tp probe to cannon & enable & stop rotate
     * Set initial velocity
     * Wait for probe to hit ground
     * Hit -> disable probe & spawn debris
     * Camera target the cannon & continue rotation
     * REPEAT
     */
    void Update() {
        // Swerves cannon back and forth
        if(isRotating) zRot += rotSpeed * Time.deltaTime;
        transform.parent.eulerAngles = Vector3.forward * (Mathf.PingPong(zRot, maxValue - minValue) + minValue);

        if (isRotating) {
            slider.gameObject.SetActive(Input.GetButton("Jump"));
            if (Input.GetButtonDown("Jump")) cam.transform.position = cam.Teleport(transform.position);
            if (Input.GetButtonUp("Jump")) StartCoroutine(Launch());
        }

        slider.transform.up = cam.transform.up;

        if (targetPlayer) cam.SetTarget(player.transform.position);
    }

    public void ResetCannon() {
        cam.SetTarget(transform.position);

        isRotating = true;
        player.Disable();

        player.angle = 0;
        player.maxAlt = 0;

        targetPlayer = false;
    }

    IEnumerator Launch() {
        Rigidbody2D probeRB = player.GetComponent<Rigidbody2D>();

        isRotating = false;

        yield return new WaitForSeconds(0.5f);

        Vector2 offset = transform.up * 0.5f;
        player.transform.position = (Vector2)transform.position + offset;

        player.gameObject.SetActive(true);
        probeRB.velocity = transform.up * launchSpeed * slider.value;

        StartCoroutine(player.GetDestroyed());

        targetPlayer = true;
    }
}
