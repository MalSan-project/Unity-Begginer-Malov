using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MaterialList
{

    public float HP { get => base.Health; set => base.Health = value; }
    public float DP { get => base.Defends; set => base.Defends = value; }
    public float DAM { get => base.Damage; set => base.Damage = value; }


    public ObjectList() : base()
    {

    }
    public ObjectList(float HP, float DEF, float DAMAGE) : base(HP, DEF, DAMAGE)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
