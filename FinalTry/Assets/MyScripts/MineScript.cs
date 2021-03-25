using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private float damage=50;
    float actdam;
    public GameObject explosionEffect;
    public float explosionForce = 500f;   
    public float explosionRadius = 5f;
    HashSet<MaterialList> targets=new HashSet<MaterialList>();
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.tag!="Ground")
        Explode();
        //    collision.gameObject.name;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] targetsAr = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider target in targetsAr)
        {                        
            if (target.tag!="Ground" && target.tag!="Untagget")
            { 
            Rigidbody rb = target.GetComponent<Rigidbody>();
                if (rb != null)
                {                
                    Destroy(gameObject);
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);                   
                    if (target.tag == "Player")
                    {
                        targets.Add(target.GetComponentInParent<PlayerList>());
                    }
                    else
                        if (target.tag == "Enemy")
                        {
                        targets.Add(target.GetComponentInParent<EnemyList>());
                        }
                    else
                        if (target.tag =="ActiveObject")
                    {
                        targets.Add(target.GetComponentInParent<ObjectList>());
                    }
                }
            }
        }
        GetDamage(targets);

    }
    public void GetDamage(HashSet<MaterialList> targets)
    {
        foreach(MaterialList t in targets)
        {
            actdam =damage - Vector3.Distance(t.transform.position, transform.position)*10;
            t.OnHit(actdam);
        }
    }
}
