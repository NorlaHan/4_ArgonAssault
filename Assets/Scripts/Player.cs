using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField][Tooltip("In ms^-1")] float xSpeed = 8f, ySpeed = 8f;
    [SerializeField][Tooltip("In m")] float xRange = -5f, yRange = -2f;

    [SerializeField] float posPitchFactor = 5f , posYawFactor = 5f;
    [SerializeField] float ctrlPitchFactor = 10f, ctrlRowFactor = 4f;

    float xOffset, yOffset , xThrow, yThrow;

    // Use this for initialization
    void Start () {
        xOffset = transform.localPosition.x;
        yOffset = transform.localPosition.y;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        OnProcessTranslation();
        OnProcessRotation();
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

        float xOffsetPerFrame = Time.deltaTime * xSpeed * xThrow;
        float yOffsetPerFrame = Time.deltaTime * ySpeed * yThrow;

        xOffset = Mathf.Clamp(xOffset += xOffsetPerFrame, -xRange, xRange);
        yOffset = Mathf.Clamp(yOffset += yOffsetPerFrame, -yRange, yRange);

        transform.localPosition = new Vector3(xOffset, yOffset, transform.localPosition.z);
    }
}
