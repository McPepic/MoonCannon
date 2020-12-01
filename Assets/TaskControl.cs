using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskControl : MonoBehaviour {
    // Manage task description, points
    public Text description, pointText;

    public void setDescription(string d) {
        description.text = d;
    }

    public void setPoints(int n) {
        pointText.text = n.ToString();
    }
}
