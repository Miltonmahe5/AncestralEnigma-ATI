using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ir_a_escena : MonoBehaviour {

	public string scene;

	public string passw1;

	public Color loadToColor = Color.white;

	public void clickcc (){
		
			//gameObject.GetComponent<AudioSource> ().Play();
			Initiate.Fade(scene,loadToColor,2f);	
			
	}


	public void clickccaQ (){

		string input = GameObject.Find("Psswrd").GetComponent<InputField>().text;
		GameObject mensaje = GameObject.Find("ERROR");
		if (input == passw1) {
			//gameObject.GetComponent<AudioSource> ().Play();

			StartCoroutine("HideUnhideCorrect",mensaje);

		} else {
			
			StartCoroutine("HideUnhideBad",mensaje);
		}


	}

	IEnumerator HideUnhideBad(GameObject ejemplo)
	{
			ejemplo.GetComponent<Text> ().color = new Color (255f, 0f, 0f);
			ejemplo.GetComponent<Text>().text = "CONTRASEÑA ERRÓNEA";
			yield return (new WaitForSeconds(1));
			ejemplo.GetComponent<Text>().text = "";
			


	}
	IEnumerator HideUnhideCorrect(GameObject ejemplo)
	{
		ejemplo.GetComponent<Text> ().color = new Color (0f, 255f, 63f);
		ejemplo.GetComponent<Text>().text = "CONTRASEÑA CORRECTA";
		yield return (new WaitForSeconds(1));
		ejemplo.GetComponent<Text>().text = "";
		Initiate.Fade (scene, loadToColor, 2f);	




	}
}