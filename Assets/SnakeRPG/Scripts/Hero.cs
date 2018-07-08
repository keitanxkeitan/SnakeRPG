using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    // Private
    private float mAttackTime = 0.0f;
    private GameObject mTargetEnemy = null;
    private int mHitAfterglow = 0;
    private GameObject mSlider = null;
    private GameObject mSlider1 = null;

	// Use this for initialization
	void Start () {
        Util.ResizeGameObjectAccordingToResolution(gameObject, 0.04f);
        mSlider = GameObject.Find("Slider");
        mSlider1 = GameObject.Find("Slider (1)");
    }
	
	// Update is called once per frame
	void Update () {
        HitAfterglow();

        Move();

        Attack();
	}

    void HitAfterglow() {
        if (mHitAfterglow > 0) {
            mSlider.SetActive(true);
            mSlider1.SetActive(true);
        } else {
            mSlider.SetActive(false);
            mSlider1.SetActive(false);
        }

        --mHitAfterglow;
    }

    void Move() {
        var motion = Vector3.up * 0.05f;
        if (Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                var prevScreenPosition = touch.position - touch.deltaPosition;
                var currScreenPosition = touch.position;
                var prevWorldPosition = Camera.main.ScreenToWorldPoint(prevScreenPosition);
                var currWorldPosition = Camera.main.ScreenToWorldPoint(currScreenPosition);
                var deltaWorldPosition = currWorldPosition - prevWorldPosition;
                motion.x += deltaWorldPosition.x;
            }
        }
        GetComponent<CharacterController>().Move(motion);

        float halfScreenWidth = Screen.width / 2 * 0.01f;
        float halfSpriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 * 0.01f;
        if (transform.position.x < - halfScreenWidth + halfSpriteWidth) {
            var position = transform.position;
            position.x = - halfScreenWidth + halfSpriteWidth;
            transform.position = position;
        }
        if (transform.position.x > halfScreenWidth - halfSpriteWidth) {
            var position = transform.position;
            position.x = halfScreenWidth - halfSpriteWidth;
            transform.position = position;
        }
    }

    void Attack() {
        if (mAttackTime > 0.0f)
        {
            var slider = GameObject.Find("Slider (1)");
            slider.GetComponent<Slider>().value = mAttackTime / 1.0f;
            slider.transform.position = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(transform.position - Vector3.up * Screen.width / 5 * 0.01f * 0.5f);
        }

        if (mAttackTime >= 1.0f) {
            mTargetEnemy.GetComponent<Enemy>().InformAttack(1.0f);
            mAttackTime = 0.0f;
        }
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
        if (hit.normal.y < 0.5f) {
            if (mTargetEnemy != hit.gameObject) {
                mAttackTime = 0.0f;
                mTargetEnemy = hit.gameObject;
            }
            var enemy = hit.gameObject.GetComponent<Enemy>();
            enemy.InformHit();
            mAttackTime += Time.deltaTime;
            mHitAfterglow = 1;
        }
	}

    public void InformAttack(float attackPower) {
        iTween.ShakePosition(GameObject.Find("Main Camera"), iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
    }
}
