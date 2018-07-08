using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteHolder : MonoBehaviour {

    // SerializeField
    [SerializeField] private Sprite[] mSprites;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Sprite GetSprite(EnemyDefine.EnemyType type) {
        return mSprites[(int)type];
    }
}
