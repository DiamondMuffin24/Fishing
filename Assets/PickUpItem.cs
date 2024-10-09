using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float pickupDistance = 3.0f;
    public Transform holdParent; // Parent object to hold the items
    [SerializeField] private List<GameObject> currentItems = new List<GameObject>(); // List to hold picked items

    void Update()
    {
        // Check for pickup input (e.g., "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentItems.Count < 5) // Limit the number of items (e.g., max 5 items)
            {
                // Try to pick up an item
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
                {
                    if (hit.collider.CompareTag("Pickup")) // Ensure the object has the "Pickup" tag
                    {
                        Pickup(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                // Drop the last item picked
                Drop();
            }
        }
    }

    void Pickup(GameObject item)
    {
        currentItems.Add(item); // Add item to the list
        item.transform.SetParent(holdParent); // Set parent to the holdParent
        item.transform.localPosition = new Vector3(0, currentItems.Count * 0.1f, 0); // Stack items slightly above each other
        item.GetComponent<Collider>().enabled = true; // Disable collider
        item.GetComponent<Rigidbody>().isKinematic = true; // Make it kinematic
    }

    void Drop()
    {
        if (currentItems.Count > 0) // Make sure there's at least one item to drop
        {
            GameObject itemToDrop = currentItems[currentItems.Count - 1]; // Get the last item
            Debug.Log("Dropping item: " + itemToDrop.name); // Log the item being dropped
            currentItems.RemoveAt(currentItems.Count - 1); // Remove it from the list
            itemToDrop.transform.SetParent(null); // Remove parent
            itemToDrop.GetComponent<Collider>().enabled = true; // Enable collider
            itemToDrop.GetComponent<Rigidbody>().isKinematic = false; // Make it dynamic
        }
    }
}