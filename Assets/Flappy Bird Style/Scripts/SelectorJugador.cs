using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectorJugador : MonoBehaviour {


	public static int jugador1Pos;
	public static int jugador2Pos;

	public Text tiempo;


	public Sprite[] extremofilosImage = new Sprite[6];

	public Text textShowJug1;
	public Text textShowJug2;

	public GameObject jugImagen1;
	public GameObject jugImagen2;

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
		MoveNav1 (0);
		MoveNav2 (0);


	}
	
	// Update is called once per frame
	void Update () {

		tiempo.text = (CambioEscena.tiempoLim - CambioEscena.reloj).ToString();

	}

	void MoveNav1(int change){
		if (change > 0) {
			if (jugador1Pos + change < extremofilosImage.Length - 1) {
				jugador1Pos += change;
			} else {
				jugador1Pos = extremofilosImage.Length - 1;
			}

		} else {
			if (jugador1Pos + change >= 0 ) {
				jugador1Pos += change;
			} else {
				jugador1Pos = 0;
			}
				
		}


		jugImagen1.GetComponent<Image>().sprite = extremofilosImage [jugador1Pos];
		textShowJug1.text = extremofilosImage [jugador1Pos].name;

	}


	public void playerOneUp(){
		MoveNav1 (1);

	}
	public void playerOneDown(){
		MoveNav1 (-1);

	}

	public void playerTwoUp(){
		MoveNav2 (1);

	}
	public void playerTwoDown(){
		MoveNav2 (-1);

	}




	void MoveNav2(int change){
		if (change > 0) {
			if (jugador2Pos + change < extremofilosImage.Length - 1) {
				jugador2Pos += change;
			} else {
				jugador2Pos = extremofilosImage.Length - 1;
			}

		} else {
			if (jugador2Pos + change >= 0 ) {
				jugador2Pos += change;
			} else {
				jugador2Pos = 0;
			}


		}
		jugImagen2.GetComponent<Image>().sprite = extremofilosImage [jugador2Pos];
		textShowJug2.text = extremofilosImage [jugador2Pos].name;

	}
}
