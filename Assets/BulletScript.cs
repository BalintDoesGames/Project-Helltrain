using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, .5f);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);;    
    }
}
