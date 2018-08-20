using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[Tooltip("FX prefab on enemy")][SerializeField] GameObject deathFX;
	[Tooltip("The parent which the deathFX follow")][SerializeField] GameObject parent;
	
	[SerializeField] int scorePerHit = 12;
	ScoreBoard scoreBoard;
	// Use this for initialization
	void Start ()
    {
        OnAddBoxCollider();

        // Create a parent if not existed
        OnFindSpawnParent();

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnFindSpawnParent()
    {
        if (!GameObject.Find("SpawnedAtRuntime"))
        {
            parent = new GameObject("SpawnedAtRuntime");
        }
        else
        {
            parent = GameObject.Find("SpawnedAtRuntime");
        }
    }

    private void OnAddBoxCollider()
    {
        BoxCollider bc = gameObject.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

	private void OnParticleCollision(GameObject other) 
	{
		print("Particle collided with enemy" + name);
        scoreBoard.OnScoreHit(scorePerHit);
		GameObject FX = Instantiate(deathFX,transform.position,Quaternion.identity);
		FX.transform.SetParent(parent.transform);
		Destroy(gameObject);
	}
}
