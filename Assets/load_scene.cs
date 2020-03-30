using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class load_scene : MonoBehaviour {
	
	// Use this for initialization
	public void carga (string nombre_escena) {
		
		SceneManager.LoadScene (nombre_escena);
	}
	

}
