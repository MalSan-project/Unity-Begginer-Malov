using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnotherEnemyControllerScript : MonoBehaviour
{
    [SerializeField] float LookRadius = 7f;
    [SerializeField] float AttackRadius = 1f;
    [SerializeField] float EnemyMoveSpeed = 3f;
    [SerializeField] float EnemyRunSpeed = 5f;
    [SerializeField] float EnemyRotationSpeed = 5f;
    [SerializeField] float CoolDawn=2f;
    float actCoolDawn;

    Transform target;
    NavMeshAgent agent;
    Animator enemy;
    PlayerList player;
    EnemyList thisEnemy;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Animator>();
        player = PlayerManager.instance.player.GetComponent<PlayerList>();
        thisEnemy = GetComponent<EnemyList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance<=LookRadius && distance>AttackRadius)
        {
            enemy.SetBool("Move", false);
            enemy.SetBool("Move", true);
            FaceOnTarget();
            agent.SetDestination(target.position);
        }
        else
        if (distance <= AttackRadius)
        {
            FaceOnTarget();
            enemy.SetBool("Attack", true);
            if (actCoolDawn <= 0)
            {
                actCoolDawn = CoolDawn;
                player.OnHit(thisEnemy.GetDamage());
            }

        }              
        else
        {
            enemy.SetBool("Move", false);
            enemy.SetBool("Attack", false);
        }
    }
    void FaceOnTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * EnemyRotationSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);   
    }
}
