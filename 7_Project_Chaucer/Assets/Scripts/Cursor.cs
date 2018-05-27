using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour 
{
	CameraRaycaster cameraRaycaster;
	
	void Start()
	{
		cameraRaycaster = GetComponent<CameraRaycaster>();
	}

	void Update() 
	{
		var layerHit = cameraRaycaster.layerHit;
		print(layerHit);
	}
}
