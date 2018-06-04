using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
	[SerializeField] public Stat health;
	[SerializeField] private 

	void Awake() 
	{
		health.Initialize();
	}

	public void TakeDamage(float damage)
	{
		health.CurrentVal = health.CurrentVal - damage;
	}
}
