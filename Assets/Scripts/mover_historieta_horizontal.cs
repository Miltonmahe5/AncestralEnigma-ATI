using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover_historieta_horizontal : MonoBehaviour {
	public GameObject info;
	float posicion_antigua;
	float posicion_actual;
	float i=0;
	public Button izquierdo;
	public Button derecho;
	public GameObject boton_izq;
	public GameObject boton_der;
	public GameObject boton_cambio_escena;
	// Use this for initialization
	void Start () {
		boton_izq.SetActive(true);
		boton_der.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(i==1){
			info.transform.Translate (Vector3.left *4f);
		}
		if(i==2){
			info.transform.Translate (Vector3.right *4f);
		}
		posicion_actual= info.GetComponent<RectTransform> ().localPosition.x;

		if (posicion_actual >= 0) {
			boton_izq.SetActive (false);
			izquierdo.interactable = false;
			boton_der.SetActive (true);
			i = 0;
		} else {
			boton_izq.SetActive (true);
			izquierdo.interactable = true;
		
		}
		if (posicion_actual <= -806) {
			boton_der.SetActive (false);
			derecho.interactable = false;
			boton_izq.SetActive (true);
			boton_cambio_escena.SetActive (true);
			i = 0;
		} else {
			boton_der.SetActive (true);
			derecho.interactable = true;
			boton_cambio_escena.SetActive (false);

		}

	}

	public void mov_abajo () {

		i = 1;
	}
	public void mov_arriba () {

		i = 2;
	}
	public void volver_cero () {

		i = 0;
	}
}
