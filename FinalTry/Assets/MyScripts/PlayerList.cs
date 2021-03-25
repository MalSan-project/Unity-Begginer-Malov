using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MaterialList
{
    Animator MyAnimPlayer;
    public PlayerList() : base()
    {

    }
    public PlayerList(float HP,float DEF,float DAMAGE) : base(HP,DEF,DAMAGE)
    {
    }

    public override void OnHit(float d)
    {
        if (d - Defends > 0)
        {
            if ((d - Defends) > (Health / 3))
            {
                MyAnimPlayer.SetTrigger("GetDamHard");
            }
            else
            {
                MyAnimPlayer.SetTrigger("GetDamLight");
            }
            Health -= d - Defends;
        }
        if (Health<=0)
        {
            MyAnimPlayer.SetTrigger("Falling");
        }
        
        Debug.Log(gameObject.name + " current Health: " + Health);
    }

    // Start is called before the first frame update

    void Start()
    {
        MyAnimPlayer = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
