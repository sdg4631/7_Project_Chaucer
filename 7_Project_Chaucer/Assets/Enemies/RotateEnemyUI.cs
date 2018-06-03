using UnityEngine;

// Add a UI Socket transform to your enemy
// Attack this script to the socket
// Link to a canvas that contains NPC UI
public class RotateEnemyUI : MonoBehaviour 
{
    Camera cameraToLookAt;

    // Use this for initialization 
    void Start()
    {
        cameraToLookAt = Camera.main;
    }

    // Update is called once per frame 
    void Update()
    {
        transform.LookAt(cameraToLookAt.transform.position);
    }
}