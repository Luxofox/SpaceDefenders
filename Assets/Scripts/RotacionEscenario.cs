using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEscenario : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(new Vector3(0, 0.5f, 0));

    }
}
