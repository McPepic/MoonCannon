using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Probe")) {
            // End
            StartCoroutine(End());
        }
    }

    public IEnumerator End() {
        endScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
