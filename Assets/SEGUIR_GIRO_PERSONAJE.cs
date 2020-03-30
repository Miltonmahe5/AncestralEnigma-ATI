using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEGUIR_GIRO_PERSONAJE : MonoBehaviour {
	public GameObject personaje;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.transform.rotation.y);
	}
}
