using UnityEngine;
using System.Collections;


public class TowerSpot : MonoBehaviour {

  
	void OnMouseUp() {
		Debug.Log("click en sitio de torre");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if(bm.selectedTower != null && !MenuPausaScript.GameIsPaused) {
			ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
			if(sm.money < bm.selectedTower.GetComponent<Tower>().cost) {
                //TODO: crear mensaje que diga al usuario que no tiene suficiente dinero
				Debug.Log("no hay suficiente dinero");
				return;
			}

			sm.money -= bm.selectedTower.GetComponent<Tower>().cost;

			// FIXME: estoy asumiendo que es un objeto perteneciente a un padre (es decir, es un hijo) por esto no se colocan bien
			Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
			Destroy(transform.parent.gameObject);
		}
	}

}
