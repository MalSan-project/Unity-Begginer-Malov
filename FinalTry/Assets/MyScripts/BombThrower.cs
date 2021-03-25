using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject mybombprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown("f"))
        {
            ThrowBomb();
        }
    }
    public void ThrowBomb()
    {
       GameObject mybomb = Instantiate(mybombprefab, transform.position, transform.rotation);
        Rigidbody rb = mybomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*throwForce,ForceMode.VelocityChange);
    }


}
