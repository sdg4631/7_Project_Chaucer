using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
	[SerializeField] public Stat health;

	void Awake() 
	{
		health.Initialize();
	}
	
	public void TakeDamage(float damage)
	{
		health.CurrentVal = health.CurrentVal - damage;
	}
}
