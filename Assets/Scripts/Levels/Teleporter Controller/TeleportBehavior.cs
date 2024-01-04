using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    [SerializeField] TeleporterController tC;
    [SerializeField] string TeleportLetter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == tC.GetTargetName() && !tC.IsJustTeleported()) 
        {
            Debug.Log("Collision Succeed");
            tC.TeleportObject(collision.gameObject, TeleportLetter);
        }
    }
}
