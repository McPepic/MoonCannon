using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBoost : MonoBehaviour {

    // Accelerate space probe
    /* 
     * Check if in range & for button input
     * Focus camera on asteroid
     * Rotate probe around asteroid while facing perpendicular
     * Show slider & wait for button up
     * When released, launch probe in facing direction
     */

    public bool inRange;
    public float threshold;

    public float rotSpeed, launchSpeed;

    public CircleSlider slider;
    public CameraMove camMove;
    public ProbeControl player;
    public CannonControl cannon;

    private void Awake() {
        slider.gameObject.SetActive(true);
    }

    private void Update() {
        inRange = Vector2.Distance(Camera.main.transform.position, transform.position) <= threshold;
        if(inRange) {
            if(Input.GetButtonDown("Jump")) {
                camMove.transform.position = camMove.Teleport(transform.position);
                cannon.targetPlayer = false;

                player.transform.parent = transform.GetChild(0);

                slider.gameObject.SetActive(true);
            }
            if (Input.GetButton("Jump")) {
                transform.GetChild(0).Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
                player.transform.up = Vector2.Perpendicular(player.transform.position - transform.position);

                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                slider.transform.position = player.transform.position;
            }
            if(Input.GetButtonUp("Jump")) {
                cannon.targetPlayer = true;

                slider.gameObject.SetActive(false);
                slider.transform.position = (Vector2)cannon.transform.position + Vector2.up * 0.5f;

                player.GetComponent<Rigidbody2D>().velocity = player.transform.up * launchSpeed * slider.value;
            }
        }
    }
}
