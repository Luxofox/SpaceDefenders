﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGO;

	Transform targetPathNode;
	int pathNodeIndex = 0;

	float speed = 5f;

	public float health = 1f;

	public int moneyValue = 1;

    //encuentra el camino
	void Start () {
		pathGO = GameObject.Find("Path");
	}
    //encuentra el siguiente destino camino
	void GetNextPathNode() {
		if(pathNodeIndex < pathGO.transform.childCount) {
			targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
			pathNodeIndex++;
		}
		else {
			targetPathNode = null;
			ReachedGoal();
		}
	}
	
	void Update () {
		if(targetPathNode == null) {
			GetNextPathNode();
			if(targetPathNode == null) {
				//llego al final
				ReachedGoal();
				return;
			}
		}
        //seguimiento del camino
		Vector3 dir = targetPathNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			// llega al siguiente punto del camino
			targetPathNode = null;
		}
		else {
			// TODO: hacer mas bonita esta transicion?

			// se mueve hacia el siguiente punto
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void ReachedGoal() {
		GameObject.FindObjectOfType<ScoreManager>().LoseLife();
		Destroy(gameObject);
	}

	public void TakeDamage(float damage) {
		health -= damage;
		if(health <= 0) {
			Die();
		}
	}

	public void Die() {
		// TODO: encontrar un modo de hacer esto mas seguro?
		GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
		Destroy(gameObject);
	}
}
