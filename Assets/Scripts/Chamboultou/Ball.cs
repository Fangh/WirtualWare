using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform respawnPoint;
    Rigidbody rb;

    public GameObject canPrefab;
    public GameObject canToDestroy;
    public GameObject canSpawnPoint;
    public bool collisionBall;

    // Start is called before the first frame update
    void Start()
    {
        collisionBall = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            gameObject.transform.position = respawnPoint.position;
            rb.isKinematic = true;
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Can" && collisionBall == false)
        {
            collisionBall = true;
            Invoke("Relaunch", 2f);
        }
    }


    void Relaunch()
    {
        Destroy(canToDestroy);
        GameObject newcan = Instantiate(canPrefab, canSpawnPoint.transform.position, Quaternion.Euler(0,90,0));
        canToDestroy = newcan;
        collisionBall = false;
    }
}
