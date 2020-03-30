using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class botones : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void CargaNivel (string pNombreNivel){
		SceneManager.LoadScene (pNombreNivel);
	}

	public void CargaNivel2 (string pNombreNivel2){
		SceneManager.LoadScene (pNombreNivel2);
	}
}

