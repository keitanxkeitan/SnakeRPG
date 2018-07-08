using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour {

    // Private
    private float mAttackTime = 0.0f;
    private float mDamage = 0.0f;
    private EnemyParameters mParameters;
    private float mDamageAnimationTime = 0.0f;

	// Use this for initialization
	void Start () {
        Util.ResizeGameObjectAccordingToResolution(gameObject, 0.2f);

        mAttackTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        SelfDestroy();

        Attack();

        mDamageAnimationTime -= Time.deltaTime;
        if (mDamageAnimationTime <= 0.0f) {
            iTween.ColorTo(gameObject, iTween.Hash("color", Color.white, "time", 0.01f));
        }
	}

    public void Setup(EnemyDefine.EnemyType type) {
        var enemySpriteHolder = GameObject.Find("EnemySpriteHolder").GetComponent<EnemySpriteHolder>();
        Debug.Assert(enemySpriteHolder);
        GetComponent<SpriteRenderer>().sprite = enemySpriteHolder.GetSprite(type);
        mParameters = EnemyDefine.GetParameters(type);
    }

    void SelfDestroy() {
        if (transform.position.y < GameObject.Find("Hero").transform.position.y - 10.0f) {
            Destroy(this.gameObject);
        }
    }

    public void InformHit() {
        mAttackTime += Time.deltaTime;
    }

    void Attack() {
        if (mAttackTime > 0.0f) {
            var slider = GameObject.Find("Slider");
            slider.GetComponent<Slider>().value = mAttackTime / mParameters.mAttackTime;
            slider.transform.position = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(transform.position + Vector3.up * Screen.width / 5 * 0.01f * 0.5f);
        }

        if (mAttackTime >= mParameters.mAttackTime) {
            GameObject.Find("Hero").GetComponent<Hero>().InformAttack(mParameters.mAttackPower);
            mAttackTime = 0.0f;
        }
    }

    public void InformAttack(float attackPower) {
        mDamage += attackPower;
        if (mDamage >= mParameters.mLife) {
            Destroy(gameObject);
        }
        iTween.ColorTo(gameObject, iTween.Hash("color", new Color(0.0f, 0.0f, 0.0f, 0.0f), "time", 0.05f, "looptype", iTween.LoopType.pingPong));
        mDamageAnimationTime = 0.5f;
    }
}
