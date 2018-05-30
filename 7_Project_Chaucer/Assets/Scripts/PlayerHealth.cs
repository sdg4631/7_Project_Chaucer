using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField] public Stat health;

	void Awake() 
	{
		health.Initialize();
	}
	

	void Update() 
	{
		ModifyHealth();
	}

	void ModifyHealth()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			health.CurrentVal -= 10;
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			health.CurrentVal += 10;
		}
		
	}
}
