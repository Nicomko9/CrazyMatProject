using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMap : MonoBehaviour {

	private static int columns = 5;
	private static int rows = 5;
	private int nbMaps = columns * rows;

	public GameObject bigMap;
	public GameObject miniMap;
	public MiniMap currentMap;
	public MiniMap[] miniMaps;
	public MiniMap[,] grid;

	// Use this for initialization
	void Start () {
		// Create the GameObject Big Map
		// bigMap = new GameObject("BigMap");

		// Create the grid of Mini Maps
		CreateGrid ();

		// Create the array of Mini Maps
		CreateMiniMaps ();

		// Initialize the Mini Maps
		InitializeMiniMaps();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateGrid() {
		grid = new MiniMap[columns,rows];
		for (int i = 0; i < columns; i++) {
			for (int j = 0; j < rows; j++) {
				grid [i,j] = new MiniMap();

			}
		}
	}

	void CreateMiniMaps() {
		miniMaps = new MiniMap[nbMaps];
		float posX;
		float posY = transform.position.y;
		float posZ = transform.position.z;
		for (int i = 0; i < rows; i++) {
			posX = transform.position.x;
			posZ += 10;
			for (int j = 0; j < columns; j++) {
				miniMap = Instantiate (miniMap, new Vector3 (posX, posY, posZ), Quaternion.identity);
				miniMaps [i] = miniMap.GetComponent<MiniMap> ();
				miniMaps [i].xPos = posX;
				miniMaps [i].yPos = posY;
				posX -= 10;
			}
		}
	}

	void InitializeMiniMaps() {
		for (int i = 0; i < miniMaps.Length; i++) {
			currentMap = miniMaps [i];
			// Initialize its width
			for (int j = 0; j < rows; j++) {
				float coordX = currentMap.xPos + j;
				// Initialize its height
				for (int k = 0; k < columns; k++) {
					float coordY = currentMap.yPos + k;
					grid [(int)coordX, (int)coordY] = miniMaps [i];
				}
			}
		}
	}
}
