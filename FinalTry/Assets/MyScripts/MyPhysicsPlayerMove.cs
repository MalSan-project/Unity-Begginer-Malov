using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhysicsPlayerMove : MonoBehaviour
{
    private Rigidbody myHeroRigidBody;
    [SerializeField] private float speedMove = 1;
    private Vector3 directionMove;
    private float moveHero;
    private float rotationHero;
    
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private float jumpForce = 10;    
    // Start is called before the first frame update
    void Start()
    {
        myHeroRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        moveHero = Input.GetAxis("Vertical") * speedMove;
        rotationHero = Input.GetAxis("Horizontal") * speedRotation;
        myHeroRigidBody.AddRelativeForce(0f, 0f, moveHero);
        myHeroRigidBody.AddRelativeTorque(0f, rotationHero, 0f);
        
    }
}
