using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocultar_mini_map : MonoBehaviour {
	public GameObject minimap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ocultar () {
		minimap.SetActive (false);
	}

	public void mostrar () {
		minimap.SetActive (true);
	}
}
