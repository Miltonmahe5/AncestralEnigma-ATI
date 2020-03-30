using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_botones_respuestas : MonoBehaviour {

	//public master mmcs;
	public GameObject botones;
	public GameObject botones_res;
	public master Master;
	public GameObject imagen_tiempo; 
	public GameObject canva_alex;
	public GameObject canva_alex2;
	public GameObject canva_pregunta;
	public static int activar_tiempo;
	//public int escena;

	void Start(){
		botones.SetActive (false);
		botones_res.SetActive (false);
		canva_alex.SetActive (false);
		canva_alex2.SetActive (false);
		canva_pregunta.SetActive (false);
	}

	void OnTriggerStay (Collider col){
		switch (col.tag) {
		case "m1":
			
		//botones_res.SetActive (true);
		//imagen_tiempo.SetActive (false);
			//botones.SetActive (true);

			break;

		}
	}


	void OnTriggerEnter (Collider col){
		switch (col.tag) {
		case "m1":
			
			StartCoroutine (esperar());

			break;

		}
	}

	void OnTriggerExit (Collider col){
		switch (col.tag) {
		case "m1":
			canva_alex.SetActive (false);
			canva_alex2.SetActive (false);
			botones_res.SetActive (false);
			canva_pregunta.SetActive (false);	
			imagen_tiempo.SetActive (true);
			botones.SetActive (false);
				//Master.cambio_preguntas ();

			break;

		}
	}

	IEnumerator esperar(){

		if (master.siguiente_pregunta < master.unansweredQuestions.Count - 1) {
				
			if(canva_alex.transform.GetChild(0).GetComponent<Animator>().enabled==true){
				imagen_tiempo.SetActive (false);
				canva_alex.SetActive (true);
				yield return new WaitForSeconds (3.2f);

				imagen_tiempo.SetActive (true);
				master.tiempo = 30;
				canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = false;
			}
			canva_pregunta.SetActive (true);
			botones.SetActive (true);
			botones_res.SetActive (true);

		} 

		else {
				
			if(canva_alex2.transform.GetChild(0).GetComponent<Animator>().enabled==true){
				imagen_tiempo.SetActive (false);
				canva_alex2.SetActive (true);
				yield return new WaitForSeconds (3.2f);

				imagen_tiempo.SetActive (true);
				master.tiempo = 30;
				canva_alex2.transform.GetChild (0).GetComponent<Animator> ().enabled = false;
			}
			canva_pregunta.SetActive (true);
			botones.SetActive (true);
			botones_res.SetActive (true);

		}




	}
}
