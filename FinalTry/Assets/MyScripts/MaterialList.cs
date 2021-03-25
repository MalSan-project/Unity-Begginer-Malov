using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialList : MonoBehaviour
{        
    [SerializeField] protected float Health;
    [SerializeField] protected float Defends;
    [SerializeField] protected float Damage;
    

    public MaterialList()
    {
        Health = 0f;
        Defends = 0f;
        Damage = 0f;
    }
    public MaterialList(float hp, float def, float damage)
    {

        Health = hp;
        Defends = def;
        Damage = damage;
    }
    public virtual void OnHit(float d)
    {
        if (d - Defends > 0)
        {
            if ((d - Defends) > (Health / 3))
            {

            }
            Health -= d - Defends;
        }
        Debug.Log(gameObject.name + " current Health: " + Health);
    }
    public virtual float GetDamage ()
    {
        return Damage;
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
