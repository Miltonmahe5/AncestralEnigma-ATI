using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scriptTimer : MonoBehaviour {

    public Text contador;
    public Text fin;
	public static float tiempo = 15f;
	public master mmcs;
	int numero=0;

	// Use this for initialization
	void Start () {
        contador.text = " " + tiempo;
        fin.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
        tiempo -= Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");

        if(tiempo <= 0)
        {
            contador.text = "0";
            fin.enabled = true;
			numero = 1;
			Debug.Log (numero);

        }
		if(numero==1){
			mmcs.cambio_preguntas ();
			tiempo = 15;
			numero = 0;
			fin.enabled = false;
		}
	}
}
