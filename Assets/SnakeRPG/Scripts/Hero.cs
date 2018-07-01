using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Util.ResizeGameObjectAccordingToResolution(gameObject, 0.04f);
	}
	
	// Update is called once per frame
	void Update () {
        var position = transform.position;
        position.y = -1.0f;
        if(Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if(touch.phase == TouchPhase.Moved)
            {
                var prevScreenPosition = touch.position - touch.deltaPosition;
                var currScreenPosition = touch.position;
                var prevWorldPosition = Camera.main.ScreenToWorldPoint(prevScreenPosition);
                var currWorldPosition = Camera.main.ScreenToWorldPoint(currScreenPosition);
                var deltaWorldPosition = currWorldPosition - prevWorldPosition;
                position.x += deltaWorldPosition.x;
            }
        }
        transform.position = position;
	}
}
