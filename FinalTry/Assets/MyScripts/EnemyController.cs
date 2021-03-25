using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] string targetTag = "Player";
	[SerializeField] int rays = 6;
	[SerializeField] int distance = 15;
	[SerializeField] float angle = 20;
	[SerializeField] Vector3 offset;
	[SerializeField] float RangeAttackForce = 0f;
	[SerializeField] float RangeAttackDistance = 10f;
	[SerializeField] GameObject RangeAttackPrefab;
	[SerializeField] float RangeAttackCountdown = 3f;
	float tempRangeTime;
    private Transform target;
	private Transform PositionRangeAttack;	

	void Start()
	{

		target = GameObject.FindGameObjectWithTag(targetTag).transform;
		tempRangeTime = 0;
	}

	bool GetRaycast(Vector3 dir)
	{
		bool result = false;
		RaycastHit hit = new RaycastHit();
		Vector3 pos = transform.position + offset;
		if (Physics.Raycast(pos, dir, out hit, distance))
		{
			if (hit.transform == target)
			{
				result = true;
				Debug.DrawLine(pos, hit.point, Color.green);
			}
			else
			{
				Debug.DrawLine(pos, hit.point, Color.blue);
			}
		}
		else
		{
			Debug.DrawRay(pos, dir * distance, Color.red);
		}
		return result;
	}

	bool RayToScan()
	{
		bool result = false;
		bool a = false;
		bool b = false;
		float j = 0;
		for (int i = 0; i < rays; i++)
		{
			var x = Mathf.Sin(j);
			var y = Mathf.Cos(j);

			j += angle * Mathf.Deg2Rad / rays;

			Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
			if (GetRaycast(dir)) a = true;

			if (x != 0)
			{
				dir = transform.TransformDirection(new Vector3(-x, 0, y));
				if (GetRaycast(dir)) b = true;
			}
		}

		if (a || b) result = true;
		return result;
	}
	public void RangeAttack()
    {				 
		GameObject MyRangeAttack = Instantiate(RangeAttackPrefab, transform.position+offset, transform.rotation);		
	}

	void Update()
	{
		if (Vector3.Distance(transform.position, target.position) < distance)
		{
			if (RayToScan())
			{
				
				gameObject.transform.LookAt(target);
				if (tempRangeTime <= 0)
				{
					tempRangeTime = RangeAttackCountdown;
					RangeAttack();					
				}
			}
			else
			{
				// Поиск цели...
			}
		}
	}
    private void FixedUpdate()
    {
        if (tempRangeTime>0)
        {
			tempRangeTime -= Time.deltaTime;
        }
    }
}

