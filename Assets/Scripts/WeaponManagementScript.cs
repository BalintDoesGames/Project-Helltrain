using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagementScript : MonoBehaviour
{
    public int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponManagement;
    public GameObject currentWeapon;
    
    // Start is called before the first frame update
    void Start()
    {

        weapons[currentWeaponIndex].SetActive(true);

        currentWeapon = weapons[currentWeaponIndex];

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
