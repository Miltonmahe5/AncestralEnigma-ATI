﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccionar_A : MonoBehaviour {
	public master mmcs;
	//public int escena;
	void OnTriggerEnter (Collider col){
		switch (col.tag) {
		case "m1":
			//SceneManager.LoadScene (nombre_escena);
			mmcs.userSelectA ();

			break;

		}
	}
}
