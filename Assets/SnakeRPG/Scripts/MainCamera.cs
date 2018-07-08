using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move() {
        var hero = GameObject.Find("Hero");
        if (hero) {
            var position = transform.position;
            position.y = hero.transform.position.y + 1.5f;
            transform.position = position;
        }
    }
}
