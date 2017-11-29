using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public enum Type {
		SMALL, BOSS, BIG_BOSS
	}

	public float minY;
	public float maxY;
	public float minSpawnDistance = 2f;

	public Poolable enemyPrefab;

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
		Vector3 position;
		position = GetNewPosition ();
		GameObject obj = enemyPrefab.GetInstance ();
		obj.transform.position = position;
	}

	Vector3 GetNewPosition() {
		Vector3 tmp = transform.position;
		tmp.y = Random.Range (minY, maxY);
		//Type = Random.Range(
		return tmp;
	}

	IEnumerator SpawnCoroutine() {
		SpawnEnemy ();
		yield return new WaitForSeconds (0.1f);
	}
}
