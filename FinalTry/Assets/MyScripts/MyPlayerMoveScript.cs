using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPlayerMoveScript : MonoBehaviour
{
    CharacterController myCharacterController;
    [SerializeField] private float speedMove = 1;
    [SerializeField] private float speedRun = 1;

    private Vector3 directionMove;
    private float currentSpeed;
    private float currZ;
    private float currentjumpspeed;
    [SerializeField] private float speedRotation = 3;
    [SerializeField] private float jumpForce=6;
    [SerializeField] private float gravity;
    Animator MyAnimPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        MyAnimPlayer = gameObject.GetComponent<Animator>();
    }

    public void Attack()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        currZ = Input.GetAxis("Vertical");
        if (currZ > 0)
        {
            MyAnimPlayer.SetBool("AssMove", false);
            MyAnimPlayer.SetBool("Move", true);
        }
        else
        if (currZ < 0)
        {
            MyAnimPlayer.SetBool("AssMove", true);
            MyAnimPlayer.SetBool("Move", false);
        }
        else
        {
            MyAnimPlayer.SetBool("AssMove", false);
            MyAnimPlayer.SetBool("Move", false);
        }        
        currentSpeed = speedMove * currZ*Time.deltaTime;
        if (myCharacterController.isGrounded)
        {
            currentjumpspeed = 0;
            if (Input.GetAxis("Jump") > 0)
            {
                currentjumpspeed = jumpForce;
                MyAnimPlayer.SetTrigger("Jump");
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MyAnimPlayer.SetBool("Run", true);
            currentSpeed = speedRun * currZ*Time.deltaTime;
        }
        else
        {
            MyAnimPlayer.SetBool("Run", false);
        }
            currentjumpspeed += gravity * Time.deltaTime;
        myCharacterController.Move(new Vector3(0, currentjumpspeed * Time.deltaTime, 0));
        
        transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0);
        directionMove = transform.TransformDirection(Vector3.forward);
        directionMove.y = currentjumpspeed * Time.deltaTime*3f;
        
        myCharacterController.Move(directionMove*currentSpeed);
        if (Input.GetMouseButton(0))
        {
            MyAnimPlayer.SetBool("Attack",true);
            MyAnimPlayer.SetBool("Stand", false);
            Attack();
        }
        else
        {
            MyAnimPlayer.SetBool("Attack", false);
            MyAnimPlayer.SetBool("Stand", true);
        }
        

    }
}
