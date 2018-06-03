using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		{
			print("Collided with: " + other.gameObject.name);
		}
	}
}
