using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Util.ResizeGameObjectAccordingToResolution(gameObject, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
