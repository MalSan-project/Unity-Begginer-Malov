using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBomb : MonoBehaviour
{
    public float delay = 3f;
    public float explosionRadius = 5f;
    public float explosionForce = 500f;
    public float damage = 30;
    float actdam;
    float countdown;
    HashSet<MaterialList> targets = new HashSet<MaterialList>();
    public GameObject explosionEffect;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown<=0f && !hasExploded)
        {            
            Explode();
            hasExploded = true;
        }
    }
    public void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] targetsAr = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider target in targetsAr)
        {
            if (target.tag != "Ground" && target.tag != "Untagget" && target.tag != "Player")
            {
                Rigidbody rb = target.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Destroy(gameObject);
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);                    
                   if (target.tag == "Enemy")
                    {
                        targets.Add(target.GetComponentInParent<EnemyList>());
                    }
                    else
                        if (target.tag == "ActiveObject")
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
        foreach (MaterialList t in targets)
        {
            actdam = damage - Vector3.Distance(t.transform.position, transform.position) * 10;
            t.OnHit(actdam);
        }
    }
    private void LateUpdate()
    {
        
    }
}
