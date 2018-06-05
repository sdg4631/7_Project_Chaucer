using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour, IDamagable
{
	[SerializeField] public Stat health;
	[SerializeField] float attackRadius = 4f;
	[SerializeField] float chaseRadius = 10f;
	[SerializeField] float damagePerShot = 7f;
	[SerializeField] float secondsBetweenShots = 1f;
	[SerializeField] GameObject projectileToUse;
	[SerializeField] GameObject projectileSocket;
	[SerializeField] Vector3 aimOffset = new Vector3(0,1f,0);

	ThirdPersonCharacter thirdPersonCharacter = null;
	AICharacterControl aICharacterControl = null;
	GameObject player;
	Vector3 startingLocation;

	bool isAttacking = false;

	public void TakeDamage(float damage)
	{
		health.CurrentVal = health.CurrentVal - damage;

		if (health.CurrentVal <= 0)
        {
            Destroy(gameObject);
        }

	}

	void Awake() 
	{
		health.Initialize();
	}

	void Start() 
	{
		thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
		aICharacterControl = GetComponent<AICharacterControl>();
		player = GameObject.FindGameObjectWithTag("Player");
		startingLocation = transform.position;
	}
	
	void Update() 
	{
		float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
		float distanceFromStartingLocation = Vector3.Distance(startingLocation, transform.position);

		if (distanceToPlayer <= attackRadius && !isAttacking)
        {
			isAttacking = true;
            InvokeRepeating("SpawnProjectile", 0f, secondsBetweenShots); // TODO switch to coroutine
        }

		if (distanceToPlayer > attackRadius)
		{
			isAttacking = false;
			CancelInvoke();
		}

        if (distanceToPlayer <= chaseRadius)
		{
			aICharacterControl.SetTarget(player.transform);
		}
		else
		{
			aICharacterControl.SetTarget(transform);
		}
	}

    void SpawnProjectile()
    {
        GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.identity);
		Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
		projectileComponent.SetDamage(damagePerShot);

		Vector3 unitVectorToPlayer = (player.transform.position + aimOffset - projectileSocket.transform.position).normalized;
		float projectileSpeed = projectileComponent.projectileSpeed;
		newProjectile.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileSpeed;
    }

    void OnDrawGizmos()
    {
        // draw attack sphere
        Gizmos.color = new Color(255f, 0f, 0f, .5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

		// draw move sphere
        Gizmos.color = new Color(0f, 0f, 255f, .5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
	}
}
