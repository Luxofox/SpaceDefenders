using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	float spawnCD = 0.25f;
	float spawnCDremaining = 5;
    int n = 1;

    [System.Serializable]
	public class WaveComponent {
		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}

	public WaveComponent[] waveComps;

	void Start () {
	
	}
	
	void Update () {
		spawnCDremaining -= Time.deltaTime;
		if(spawnCDremaining < 0) {
			spawnCDremaining = spawnCD;

			bool didSpawn = false;

			// recorre la lista de enemigos hasta encontrar algo que spawnear
			foreach(WaveComponent wc in waveComps) {
				if(wc.spawned < wc.num) {
					// crea enemigo
					wc.spawned++;
					Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

					didSpawn = true;
                    break;
				}
                if (n != 0)
                {
                    FindObjectOfType<AudioManager>().Play("EnemySpawn");
                    n = 0;
                }
                
            }
            
            if (didSpawn == false) {
				// se tiene que completar la oleada
				// TODO: crear mas oleadas de enemigos

				if(transform.parent.childCount > 1) {
					transform.parent.GetChild(1).gameObject.SetActive(true);
				}
				else {
                    /* Se terminan las oledas, envez de destruir los wave objects podriamos ponerlos inactivos
                     * cuando nos quedamos sin waves y despues iniciamos desde el principio doblando la vida de enemigos? 
                     */
                }

                Destroy(gameObject);
			}
            
        }
        
    }
}
