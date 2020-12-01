using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoals : MonoBehaviour {

    public ProbeControl control;
    public Goal[] goals;

    public TaskControl[] tc;

    private void Update() {
        foreach (Goal goal in goals) {
            if (!goal.complete && control.distance >= goal.distance && control.maxAlt >= goal.altitude) goal.complete = true;
        }
    }
}

[System.Serializable]
public class Goal {
    public bool complete;
    public float distance, altitude;

    public string desc;
    public int points;
}
