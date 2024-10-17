using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tunnel_to_room : MonoBehaviour
{
    public IEnumerator TeleportAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 15 seconds

        Debug.Log("delay");

        // Load the desired scene (replace "YourSceneName" with the actual scene name)
        SceneManager.LoadScene("rusty_hole");
    }
}
