using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeyYou : MonoBehaviour, IInteractable
{
    public GameObject hut;
    public GameObject textbox;

    public void Interact()
    {
        Debug.Log("interact");
        textbox.SetActive(true);
        StartCoroutine(TeleportAfterDelay(1f)); // Start the coroutine
    }

    private IEnumerator TeleportAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 15 seconds

        Debug.Log("delay");

        // Load the desired scene (replace "YourSceneName" with the actual scene name)
        SceneManager.LoadScene("innner_dock");
    }

}