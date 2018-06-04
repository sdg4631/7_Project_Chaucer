﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour 
{
	[SerializeField] float attackRadius = 4f;
	[SerializeField] float chaseRadius = 10f;


	ThirdPersonCharacter thirdPersonCharacter = null;
	AICharacterControl aICharacterControl = null;
	GameObject player;
	Vector3 startingLocation;
	Transform startingTransform;

	void Start() 
	{
		thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
		aICharacterControl = GetComponent<AICharacterControl>();
		player = GameObject.FindGameObjectWithTag("Player");
		startingLocation = transform.position;
		startingTransform = transform;
	}
	
	void Update() 
	{
		float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
		float distanceFromStartingLocation = Vector3.Distance(startingLocation, transform.position);

		if (distanceToPlayer <= attackRadius)
		{
			print(gameObject.name + " attacking player");
			// TODO spawn projectile 
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
