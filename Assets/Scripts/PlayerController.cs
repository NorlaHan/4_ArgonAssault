using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// TODO Player collide with environment and enemies.
// TODO Player shoots bullet.
// TODO Fix the bullet slower than player.
// TODO enemies action.

public class PlayerController : MonoBehaviour {

    [Header("General")]    
    [SerializeField] [Tooltip("In ms^-1")] float xControlSpeed = 8f;
    [SerializeField][Tooltip("In ms^-1")] float yControlSpeed = 8f;
    [SerializeField][Tooltip("In m")] float xRange = 5f;
    [SerializeField] [Tooltip("In m")] float yRange = 3f;

    [Header("Screen-position Based")]
    [SerializeField] float posPitchFactor = 2f;
    [SerializeField] float posYawFactor = -2f;

    [Header("Control-throw Based")]
    [SerializeField] float ctrlPitchFactor = -20f;
    [SerializeField] float ctrlRowFactor = -20f;

    Vector3 rawOffset; 
    float xOffset, yOffset , zOffset, xThrow, yThrow;
    bool isControlEnabled = true;

    // Use this for initialization
    void Start () {
        rawOffset = transform.localPosition;
        xOffset = rawOffset.x;
        yOffset = rawOffset.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled == true)
        {
            OnProcessTranslation();
            OnProcessRotation();
        }
        
    }

    private void OnProcessRotation()
    {
        float pitch = transform.localPosition.y * posPitchFactor + yThrow * ctrlPitchFactor;
        float yaw = transform.localPosition.x * posYawFactor ;
        float row = xThrow * ctrlRowFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, row);
    }

    private void OnProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetPerFrame = Time.deltaTime * xControlSpeed * xThrow;
        float yOffsetPerFrame = Time.deltaTime * yControlSpeed * yThrow;

        xOffset = Mathf.Clamp(xOffset += xOffsetPerFrame, -xRange, xRange);
        yOffset = Mathf.Clamp(yOffset += yOffsetPerFrame, -yRange, yRange);

        transform.localPosition = new Vector3(xOffset, yOffset, rawOffset.z);
    }

    private void OnPlayerDeath()    // called by string reference
    {
        print("Player losing control !!!");
        isControlEnabled = false;
    }
}
