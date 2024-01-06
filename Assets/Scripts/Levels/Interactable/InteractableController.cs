using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableController : MonoBehaviour
{
    [SerializeField] InteractableBehavior Key;
    [SerializeField] InteractableBehavior Door;
    [SerializeField] GameObject Player;
    private bool isPicked = false;
    private InteractableBehavior pickedKey;
    public bool SetupBehavior(InteractableBehavior behavior) 
    {
        if (behavior == Key)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public string GetPlayerName() 
    {
        return Player.name;
    }
    public void PickedUp(InteractableBehavior DestroyedKey) 
    {
        pickedKey = Instantiate(DestroyedKey, Player.transform, false);
        isPicked = true;
        pickedKey.isPickedUp = true; 
        pickedKey.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3f);
        pickedKey.transform.rotation = Quaternion.Euler(0,0,0);
        Destroy(pickedKey.GetComponent<BoxCollider2D>());
    }
    public bool IsFlipped() 
    {
        return !Player.GetComponent<PlayerController>().isFacingRight;
    }

    public bool IsPicked() 
    {
        return isPicked;
    }

    public void OpenTheDoor() 
    {
        Destroy(pickedKey.gameObject);
    }
}
