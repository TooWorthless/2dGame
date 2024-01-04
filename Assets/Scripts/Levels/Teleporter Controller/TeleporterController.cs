using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] GameObject TeleportA;
    [SerializeField] GameObject TeleportB;
    [SerializeField] GameObject TargetObject;
    private bool justTeleported = false;
    private Vector3 TApos;
    private Vector3 TBpos;



    void Start()
    {
        TApos = TeleportA.GetComponent<Collider2D>().transform.position;
        TBpos = TeleportB.GetComponent<Collider2D>().transform.position;
    }

    public void TeleportObject(GameObject gObj, string l) 
    {
        if (l == "A") 
        {
            gObj.transform.position = TBpos;
            justTeleported = true;
        }
        else if (l == "B") 
        { 
            gObj.transform.position = TApos;
            justTeleported = true;
        }
        else
        {
            Debug.LogWarning("Couldn't teleport! Specify which teleport will be used!\n\nl = " + l);
        }
    }
    public string GetTargetName() 
    { 
        return TargetObject.name; 
    }
    public bool IsJustTeleported() 
    { 
        if (justTeleported) 
        { 
            justTeleported = false;
            return true;
        }
        return false; 
    }

}
