﻿using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform turretTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	public float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;


	void Start () {
		turretTransform = transform.Find("Turret");
	}
	
	void Update () {
		// TODO: optimizar el sistema de busqueda de enemigos?
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

		Enemy nearestEnemy = null;
		float dist = Mathf.Infinity;

		foreach(Enemy e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}

		if(nearestEnemy == null) {
			Debug.Log("No hay enemigos en rango");
			return;
		}

		Vector3 dir = nearestEnemy.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation( dir );

		//Debug.Log(lookRot.eulerAngles.y);
		turretTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0 );

		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestEnemy);
		}

	}

	void ShootAt(Enemy e) {
		// TODO: que dispare desde la punta de la torre y no desde el centro...
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}
