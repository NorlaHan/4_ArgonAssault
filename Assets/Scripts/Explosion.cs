using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	[SerializeField] bool isSelfDestruct = false;
	[SerializeField] float timer = 1;
	void Start () {
		if (isSelfDestruct)
		{
			Destroy(gameObject,timer);
		}
	}
}
