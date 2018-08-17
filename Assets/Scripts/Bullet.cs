using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 15f;
	public Transform target;
	public float damage = 1f;
	public float radius = 0;

	void Start () {
	
	}
	
	void Update () {
		if(target == null) {
			// salio del rango
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			// bala alzanda al enemigo
			DoBulletHit();
		}
		else {
			// TODO: hacer mas fluido esta animacion

			// movimiento de la bala
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void DoBulletHit() {
        //bala normal
		if(radius == 0) {
			target.GetComponent<Enemy>().TakeDamage(damage);
		}
		else {
            //bala explosiva
			Collider[] cols = Physics.OverlapSphere(transform.position, radius);
            //añadir explosion de bala de area?
			foreach(Collider c in cols) {
				Enemy e = c.GetComponent<Enemy>();
				if(e != null) {
					
					e.GetComponent<Enemy>().TakeDamage(damage);
				}
			}
		}

		// TODO: crear explosion para enemigos?

		Destroy(gameObject);
	}
}
