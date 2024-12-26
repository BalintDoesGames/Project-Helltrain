using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    public float length = 25f, speed = 6f;
    public Transform ignore;
    public float seconds;
    Transform enemy;
    public Transform player;
    public bool canseePlayer = false;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("PatrolDelay");
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MovementDelay");

    }

    void FixedUpdate()
    {
	//Get the first object hit by the ray
	RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, 0f, 0f), transform.right, length);

	//If the collider of the object hit is not NUll
	if (hit.collider != null)
	{
		//Hit something, print the tag of the object
        if(hit.collider.tag == "Player")
        {
            //Debug.Log("Hitting: " + hit.collider.tag);
            Debug.Log("I can see you");
            canseePlayer = true;
            Debug.DrawRay(transform.position + new Vector3(0f, 0f, 0f), transform.right * length, Color.green);
            OnSeePlayer();
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 0f, 0f), transform.right * length, Color.red);
            canseePlayer = false;
            
        }
		
        
	}

	    
    }

    void OnSeePlayer()
    {
        if(canseePlayer == true)
        {
            transform.LookAt(player, Vector3.right);
            transform.Rotate(new Vector3 (0, -90, 0), Space.Self);
            transform.Translate(new Vector3 (speed * Time.deltaTime, 0, 0));
        }
    }

    void Patrol()
    {
        if(canseePlayer == false)
        {
            transform.Rotate(new Vector3 (0, 0, Random.Range(-360.0f, 360.0f)), Space.Self);            
            
        }
    }

    void EnemyMovement()
    {
        if(canseePlayer == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator PatrolDelay()
    {
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        
        Patrol();
        yield return new WaitForSeconds(3.5f);
        Patrol();
        

        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StartCoroutine("PatrolDelay");
    }
    IEnumerator MovementDelay()
    {
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Debug.Log("Time is: " + seconds + " Speed is: " + speed);
        yield return new WaitForSeconds(0.5f);
        EnemyMovement();
        yield return new WaitForSeconds(0.5f);
        transform.Translate(0, 0, 0);
        

        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Walls")
        {
            Debug.Log("Hit the wall");
            this.transform.rotation = Quaternion.Inverse(this.transform.rotation);
        }
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hit you");
            
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        
    }
    



}
