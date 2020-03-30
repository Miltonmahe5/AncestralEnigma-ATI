using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_personaje : MonoBehaviour {
	
	int innnn;
	private List<GameObject> modelosTPC;

	// Use this for initialization
	void Start () {
		modelosTPC = new List<GameObject> ();
		foreach (Transform t in transform) {
			modelosTPC.Add (t.gameObject);
			t.gameObject.SetActive (false);
		}

		int marcador = PlayerPrefs.GetInt ("index");

		Debug.Log (marcador);
		modelosTPC [marcador].SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
