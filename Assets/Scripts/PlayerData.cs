using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Player Data Information")]
    [SerializeField]
    float playerMaxHealth;
    [SerializeField]
    float playerCurrentHealth;
    [SerializeField]
    float playerDebugHealthVal;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DEBUGTAKEDAMAGE();
        DEBUGHEAL();
        if(playerCurrentHealth <= 0)
        {
            Debug.Log("Dead");
        }
    }

    public void DEBUGTAKEDAMAGE()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            playerCurrentHealth = playerCurrentHealth - playerDebugHealthVal;
        }
    }
    public void DEBUGHEAL()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            playerCurrentHealth = playerCurrentHealth + playerDebugHealthVal;
        }
    }
}
