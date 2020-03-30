using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class detector_huellas : MonoBehaviour {
	public Button a;
	public Button b;
	public Button c;
	public Button d;

	Button btn1;
	Button btn2;
	Button btn3; 
	Button btn4; 

	int aa=0;
	int bb=0;
	int cc=0;
	int dd=0;

	public Animator animar1;
	public Animator animar2;
	public Animator animar3;
	public Animator animar4;
	public AnimationClip anim1;
	public AnimationClip anim2;

	public string scene;

	bool clicked;

	public Color loadToColor = Color.white;

	// Use this for initialization
	void Start()
	{



		btn1 = a.GetComponent<Button>();
		btn2 = b.GetComponent<Button>();
		btn3 = c.GetComponent<Button>();
		btn4 = d.GetComponent<Button>();

		}


	void Update(){
		
		if(aa==1 && bb==2 && cc==3 && dd==4){
			
			Initiate.Fade(scene,loadToColor,2f);	
		}
	}


	public void cambiar_a_cero(){
		
		aa=0;
		bb=0;
		cc=0;
		dd=0;
		animar1.Play ("rotate_rapido");
		animar2.Play ("rotate_rapido");
		animar3.Play ("rotate_rapido");
		animar4.Play ("rotate_rapido");

	}

	public void cambiar1(){
		
		animar1.Play ("rotate_lento");
		aa = 1;


	}
	public void cambiar2(){
		
		animar2.Play ("rotate_lento");
		bb = 2;
		Debug.Log ("eee");


	}

	public void cambiar3(){
		
		animar3.Play ("rotate_lento");
		cc = 3;


	}
	public void cambiar4(){
		
		animar4.Play ("rotate_lento");
		dd = 4;


	}

}
