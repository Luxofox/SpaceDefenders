using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

    public GameObject MenuPrincipalUI;

    public GameObject optionsMenuUI;
    void Start () {
		
	}
	
	void Update () {
		
	}

    public void CargaNivel(string nombreNivel)
    {
        ScoreManager.Lives = 20;
        ScoreManager.money = 20;
        SceneManager.LoadScene(nombreNivel);
        EnemySpawner.wavesRestantes = 3;

    }
    
    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void Options()
    {
        MenuPrincipalUI.SetActive(false);
        optionsMenuUI.SetActive(true);

    }

    public void Back()
    {
        MenuPrincipalUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

}
