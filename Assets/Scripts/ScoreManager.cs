using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int lives = 20;
	public int money = 100;

	public Text moneyText;
	public Text livesText;

	public void LoseLife(int l = 1) {
		lives -= l;
		if(lives <= 0) {
			GameOver();
		}
	}

	public void GameOver() {
		Debug.Log("Game Over");
		// TODO: crear pantalla de game over y enviar al jugador a ella.
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Update() {
		// FIXME: esto no necesariamente tiene que actualizarse cada frame...
		moneyText.text = "Money: $" + money.ToString();
		livesText.text = "Lives: "  + lives.ToString();


	}

}
