using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour 
{
	[SerializeField] float attackRadius = 4f;
	[SerializeField] float aggroRange = 20f;


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
			aICharacterControl.SetTarget(player.transform);
		}
		else
		{
			aICharacterControl.SetTarget(transform);
		}

		// TODO return enemy to starting location 
		// if (distanceFromStartingLocation >= aggroRange)
		// {
		// 	aICharacterControl.SetTarget(null);
		// 	thirdPersonCharacter.Move(startingLocation, false, false);
		// }
	}
}
