using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}