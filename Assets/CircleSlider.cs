using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSlider : MonoBehaviour {

    public float rotSpeed, min, max;
    float zRot;

    Transform childSlider;

    public float value;
    public float minValue, maxValue;

    private void Start() {
        childSlider = transform.GetChild(0);
    }

    private void Update() {
        zRot += rotSpeed * Time.deltaTime;
        float rot = (Mathf.PingPong(zRot, max - min) + min);

        childSlider.localEulerAngles = Vector3.back * rot;

        float averageRot = (min + max) / 2;

        float a = (minValue - maxValue) / averageRot;
        float abs = Mathf.Abs(rot - averageRot);
        float k = maxValue;

        value = a * abs + k;
    }
}
