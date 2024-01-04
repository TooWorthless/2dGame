using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableBehavior : MonoBehaviour
{

    [SerializeField] InteractableController interactableController;
    bool isKey = false;
    public bool isPickedUp = false;
    bool flipped = false;

    private void Start()
    {
        isKey = interactableController.SetupBehavior(this);
    }
    private void Update()
    {
        if (isPickedUp)
        {
            if (flipped != interactableController.IsFlipped()) 
            { 
                flipped = interactableController.IsFlipped();
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == interactableController.GetPlayerName()) 
        {
            if (isKey)
            {
                interactableController.PickedUp(this);
                Destroy(gameObject);
            }
            else if (!isKey && interactableController.IsPicked())
            {
                Debug.Log("Work");
                interactableController.OpenTheDoor();
                Destroy(gameObject);
            }
        }
        
    }
}
