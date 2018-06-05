using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
	[SerializeField] public Stat health;
	[SerializeField] int enemyLayerNumber = 10;
	[SerializeField] float damagePerHit = 10f;
	[SerializeField] float minTimeBetweenHits = 1f; 
	[SerializeField] float maxAttackRange = 2f; 

	GameObject currentTarget;
	CameraRaycaster cameraRaycaster;
	float lastHitTime = 0f;

	void Awake() 
	{
		health.Initialize();
	}

	void Start()
	{
		cameraRaycaster = FindObjectOfType<CameraRaycaster>();
		cameraRaycaster.notifyMouseClickObservers += OnMouseClick;
	}
	
	void OnMouseClick(RaycastHit raycastHit, int layerHit)
	{
		if (layerHit == enemyLayerNumber)
		{
			var enemy = raycastHit.collider.gameObject;

			// check enemy is in range
			if ((enemy.transform.position - transform.position).magnitude > maxAttackRange)
			{
				return;
			}

			currentTarget = enemy;
			
			var enemyComponent = enemy.GetComponent<Enemy>();
			if (Time.time - lastHitTime > minTimeBetweenHits)
			{
				enemyComponent.TakeDamage(damagePerHit);
				lastHitTime = Time.time;
			}
			
		}
	}

	public void TakeDamage(float damage)
	{
		health.CurrentVal = health.CurrentVal - damage;
	}
}
