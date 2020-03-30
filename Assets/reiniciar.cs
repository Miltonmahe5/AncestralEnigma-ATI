using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciar : MonoBehaviour {

	public string scene;

	public void fun_reiniciar (){
		
			SceneManager.LoadScene (scene);
		master.tiempo = 25f;

		}
	}
	
