using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotationController : MonoBehaviour
{
    [SerializeField] PauseMenuContoller pauseMenu;
    public float offset;
    public PlayerController player;
    public GameObject weapon;
    

    private bool isFliped = false;


    void Update()
    {
        if (!pauseMenu.IsPaused()) 
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // Debug.Log(Input.mousePosition);
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

            Vector3 localScale = transform.localScale;

            if (rotateZ >= 90 || rotateZ <= -90)
            {
                if (!isFliped)
                {
                    localScale.x *= -1f;
                    transform.localScale = localScale;

                    Vector3 weaponScale = weapon.transform.localScale;
                    weaponScale.x *= -1f;
                    weapon.transform.localScale = weaponScale;

                    player.Flip2();
                    isFliped = true;
                }
            }
            else
            {
                if (isFliped)
                {
                    localScale.x *= -1f;
                    transform.localScale = localScale;

                    Vector3 weaponScale = weapon.transform.localScale;
                    weaponScale.x *= -1f;
                    weapon.transform.localScale = weaponScale;

                    player.Flip2();
                    isFliped = false;
                }
            }
        }
        

        
    }
}
