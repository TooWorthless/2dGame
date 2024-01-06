using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{

    private const float EASY = 0.5f;
    private const float NORMAL = 1f;
    private const float HARD = 2f;

    private static float multiplayer = NORMAL;
    public static float enemyHPMultiplayer { get; private set; } = multiplayer;
    public static float enemyDamageMultiplayer { get; private set; } = multiplayer;



    private void SetValues() 
    {
        enemyHPMultiplayer = multiplayer;
        enemyDamageMultiplayer = multiplayer;
        Debug.LogWarning("MultiplayerChanged");
    }

    public void SetEASY() 
    {
        multiplayer = EASY;
        SetValues();
    }
    public void SetNORMAL() 
    {   
        multiplayer = NORMAL;
        SetValues();
    }
    public void SetHARD() 
    {
        multiplayer = HARD;
        SetValues();
    }

}
