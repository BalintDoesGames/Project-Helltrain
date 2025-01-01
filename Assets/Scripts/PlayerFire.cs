using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Base Projectile Information")]
    public GameObject projectilePrefab;  // The projectile prefab to instantiate
    public float shootForce = 10f;       // Force applied to the projectile
    public float fireRate = 0.5f;        // How fast can the player shoot (in seconds)

    private float nextFireTime = 0f;

    [Header("Ammo Data")]
    public int maxAmmoCount;
    public int currentAmmoCount;
    public float reloadTime;
    public bool isReload;

    [Header("UI Data")]
    public Text ammoDisplay;


    void Start()
    {
        currentAmmoCount = maxAmmoCount;

        ammoDisplay.text = currentAmmoCount.ToString();
    }

    void Update()
    {
        // Shoot when the left mouse button is pressed
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            if(currentAmmoCount > 0 /*&& isReload == false*/)
            {
                PrimaryFire();
                nextFireTime = Time.time + fireRate;  // Prevent shooting too often
            }
        }
        if(currentAmmoCount <= 0)
        {
            Reload();
        }
        
    }

    void PrimaryFire()
    {
        currentAmmoCount = currentAmmoCount - 1;

        ammoDisplay.text = currentAmmoCount.ToString();
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Keep the projectile in the 2D plane (z=0)

        // Calculate the direction to the mouse position
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Create the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component and apply a force in the direction of the mouse
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * shootForce;
        }
        
    }

    void Reload()
    {
        isReload = true;
        Invoke("FinishReload", reloadTime);
        Debug.Log("Reloading...");
    } 

    void FinishReload()
    {
        currentAmmoCount = maxAmmoCount;
        ammoDisplay.text = currentAmmoCount.ToString();
        isReload = false;
        Debug.Log("Reloaded!");
    }
    

}
