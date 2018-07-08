using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // SerializedField
    [SerializeField] private GameObject mEnemyPrefab;

    // Private
    private float mHasSpawnedY = 0.0f; 

	// Use this for initialization
	void Start () {
        SpawnInRange(1.0f, 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Hero").transform.position.y + 10.0f > mHasSpawnedY) {
            SpawnInRange(mHasSpawnedY, mHasSpawnedY + 20.0f);
        }
	}

    void SpawnInRange(float startY, float endY) {
        int startRow = Util.ConvertPositionYToRow(startY);
        int endRow = Util.ConvertPositionYToRow(endY);

        int row = startRow + Random.Range(4, 7);
        while (row <= endRow) {
            for (int column = 0; column < 5; ++column) {
                if (Random.Range(0, 2) == 0) {
                    var type = (EnemyDefine.EnemyType)Random.Range(0, (int)EnemyDefine.EnemyType.Size);
                    var position = Vector3.zero;
                    position.x = Util.ConvertColumnToPositionX(column);
                    position.y = Util.ConvertRowToPositionY(row);
                    Spawn(type, position);
                }
            }
            row += Random.Range(3, 5);
        }

        mHasSpawnedY = endY;
    }

    void Spawn(EnemyDefine.EnemyType type, Vector3 position) {
        var enemy = Instantiate(mEnemyPrefab, position, Quaternion.identity);
        enemy.GetComponent<Enemy>().Setup(type);
    }
}
