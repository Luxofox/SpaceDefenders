using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedTower;

	// ocurre una vez al principio
	void Start () {
	
	}
	
	// Se hace una vez por frame
	void Update () {
	
	}

	public void SelectTowerType(GameObject prefab) {
		selectedTower = prefab;
	}
}
