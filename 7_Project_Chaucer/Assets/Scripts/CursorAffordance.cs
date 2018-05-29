﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour 
{
	[SerializeField] Texture2D walkCursor = null;
	[SerializeField] Texture2D attackCursor = null;
	[SerializeField] Texture2D unknownCursor = null;
	[SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

	CameraRaycaster cameraRaycaster;
	
	void Awake()
	{
		cameraRaycaster = GetComponent<CameraRaycaster>();
		cameraRaycaster.layerChangeObservers += OnLayerChanged; // regestering
	}

	void OnLayerChanged() 
	{
		switch (cameraRaycaster.currentLayerHit)
		{
			case Layer.Walkable:
				Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
				break;		
			case Layer.Enemy:
				Cursor.SetCursor(attackCursor, cursorHotspot, CursorMode.Auto);
				break;
			case Layer.RaycastEndStop:
				Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
				break;			
			default:
				Debug.LogError("Dont know what cursor to show");
				return;
		}		
	}
}
