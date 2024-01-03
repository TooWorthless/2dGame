using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotationController : MonoBehaviour
{
    public float offset;
    public PlayerController player;


    private bool isFliped = false;


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Debug.Log(Input.mousePosition);
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 localScale = transform.localScale;

        if(rotateZ > 90 || rotateZ < -90) {
            if(!isFliped) {
                localScale.x *= -1f;
                transform.localScale = localScale;

                player.Flip2();
                isFliped = true;
            } 
        }
        else {
            if(isFliped) {
                localScale.x *= -1f;
                transform.localScale = localScale;

                player.Flip2();
                isFliped = false;
            } 
        }

        
    }
}
