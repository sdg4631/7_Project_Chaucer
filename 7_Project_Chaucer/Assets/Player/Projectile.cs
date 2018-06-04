﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	[SerializeField] float damageCaused = 10f;

	void OnTriggerEnter(Collider collider)
	{
		Component damageableComponent = collider.gameObject.GetComponent(typeof(IDamagable));
		if (damageableComponent)
		{
			(damageableComponent as IDamagable).TakeDamage(damageCaused);
		}
		
	}
}
