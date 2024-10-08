using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fshSawner : MonoBehaviour
{
    public GameObject fish_one;

    public Transform parent;

   


    public void Spawnfish()
    {
        Quaternion randomRotation = Random.rotation;

        // Get the parent's position
        Vector3 parentPosition = transform.position;

        // Generate a random position within the specified range relative to the parent
        float randomX = Random.Range(-6f,6f);
        float randomZ = Random.Range(-6f, 6f);
        float randomY = Random.Range(-2f, 0f);

        Vector3 randomPosition = parentPosition + new Vector3(randomX, randomY, randomZ); // Set y to 0 or any desired value

        Instantiate(fish_one, randomPosition, randomRotation, parent );

       
    }
}