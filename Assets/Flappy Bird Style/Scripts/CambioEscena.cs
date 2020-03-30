using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {

	public static int reloj;
	public bool escena2;
	public static int tiempoLim = 1;

	private IEnumerator coroutine;


	void Awake()
	{
		//Ensure the script is not deleted while loading
		DontDestroyOnLoad(this);

		//Make sure there are copies are not made of the GameObject when it isn't destroyed
		if (FindObjectsOfType(GetType()).Length > 1)
			//Destroy any copies
			Destroy(gameObject);
	
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	public void EscenaSelect()
	{
		SceneManager.LoadScene(1);
		escena2 = true;
		Debug.Log ("Oprimiendo");
		reloj = 0;
		coroutine = contar();
		StartCoroutine(coroutine);

	}


	void contarSeleccion (){
		reloj = reloj+ 1;

		Debug.Log ("Conteo" + reloj);
		if (reloj > tiempoLim) {
			escena2 = false;
			StopCoroutine(coroutine);
			SceneManager.LoadScene(0);
			reloj = 0;
		}

	}

	public IEnumerator contar(){

		while (escena2) {
			yield return new WaitForSeconds (1);
			contarSeleccion ();
		}
	}






}
