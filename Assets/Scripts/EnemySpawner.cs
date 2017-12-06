using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour {

	public LootEnemy.TypeEnemy typeEnemy;
	public LootEnemy lootEnemy = new LootEnemy();
	// public bool boss;

	public static int maxEnemies = 25;
	public int nbEnemiesSpawned = 0;

	public float minX = -1f;
	public float maxX = 49f;
	public float minY = -2f;
	public float maxY = 48f;
	public float minSpawnDistance = 1f;

	public static Poolable smallEnemyPrefab;
	public static Poolable bigEnemyPrefab;
	public static Poolable smallBossEnemyPrefab;
	public static Poolable bigBossEnemyPrefab;

	public Poolable[] enemyPrefabs = new Poolable[] {
		smallBossEnemyPrefab, bigBossEnemyPrefab,
		smallEnemyPrefab, bigEnemyPrefab
	};

	public LayerMask layerMask;

	void OnEnable() {
		StartCoroutine (SpawnCoroutine ());
	}

	void OnDisable() {
		StopAllCoroutines ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void SpawnEnemy() {
		Vector2 position = GetNewPosition ();

		if (!Physics2D.OverlapCircle (position, minSpawnDistance, layerMask)) {
			this.typeEnemy = lootEnemy.Choose ();
			Debug.Log ("Type Enemy : " + this.typeEnemy.ToString ());

			GameObject obj = enemyPrefabs[(int)this.typeEnemy].GetInstance ();
			Debug.Log ("Tout va bien");
			obj.transform.position = position;
			obj.transform.rotation = transform.rotation;


			nbEnemiesSpawned++;
			Debug.Log (nbEnemiesSpawned);
		}
	}

	Vector3 GetNewPosition() {
		Vector3 tmp = transform.position;
		tmp.x = UnityEngine.Random.Range (minX, maxX);
		tmp.y = UnityEngine.Random.Range (minY, maxY);
		return tmp;
	}

	IEnumerator SpawnCoroutine() {
		while (nbEnemiesSpawned < maxEnemies) {
			SpawnEnemy ();
			yield return new WaitForSeconds (10f);
		}
	}
}
