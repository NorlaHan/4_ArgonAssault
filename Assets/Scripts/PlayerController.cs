﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// TODO Work-out why player gets super fast on start.
// TODO Player collide with environment and enemies.
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

    [SerializeField] GameObject[] guns;
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
            OnProcessFiring();
        }
        
    }

    private void OnProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
         foreach (GameObject gun in guns)   // Aware may effect
        {
            var emission = gun.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
        }
    }

    #region
    // private void DeactivateGuns()
    // {
    //     foreach (GameObject item in guns)
    //     {
    //         //item.SetActive(false);
    //         ParticleSystem gun  = item.GetComponent<ParticleSystem>();
    //         gun.loop = false;
    //     }
    // }

    // private void SetGunsActive()
    // {
    //     foreach (GameObject item in guns)
    //     {   
    //         if (!item.active)
    //         {
    //             item.SetActive(true);
    //         }            
    //         ParticleSystem gun  = item.GetComponent<ParticleSystem>();
    //         if (!gun.loop)
    //         {
    //             item.SetActive(false);
    //             item.SetActive(true);
    //             gun.loop = true;
    //         }
    //     }
    // }
    #endregion

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
        // isControlEnabled = false;
    }
}
