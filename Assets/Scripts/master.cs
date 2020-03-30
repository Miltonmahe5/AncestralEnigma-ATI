using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class master : MonoBehaviour {
	
	public question[] questions; // VARIALBLE DONDE REDACTAS CADA PREGUNTA
	//public Vector3[] posiciones; // VARIABLE POSICION DONDE APARECE CADA PREGUNTA
	public static List<question> unansweredQuestions; // LISTA DE PREGUNTAS
	//public static List<Vector3> lista_posiciones;
	public GameObject pasar_mision;
	public GameObject mover;
	int puntos=0;
	string puntos_string;
	public static int siguiente_pregunta=0;
	public float m_StartingHealth;         // The amount of health the flyer starts with.
	public Image m_HealthBar;                     // Reference to the image used as a health bar.
	float m_CurrentHealth;                                  // How much health the flyer currently has.

	public GameObject boton_reinicio;
	public GameObject minimap;
	public Text contador;
	public Text fin;
	public static float tiempo = 25f;
	//public master mmcs;
	int numero=0;
	private question currentQuestion;

	[SerializeField]
	private Text factText,factText2;

	[SerializeField]
	private Text EnunTextA, EnunTextB,EnunTextC, EnunTextD,EnunTextA2,EnunTextB2,EnunTextC2, EnunTextD2 ;

	public Text puntaje;

	[SerializeField]
	private Animator animator;


	public GameObject mostrar;
	public GameObject ocultar;
	public GameObject contenedor_canva;
	public GameObject botones;
	public GameObject imagen_correcto;
	public GameObject imagen_incorrecto;
	public GameObject imagen_correcto2;
	public GameObject imagen_incorrecto2;
	public GameObject canva_alex;
	public GameObject imagen_tiempo;
	int control_cambio_pre;

	void Start()

	{

        //variables nuevas
        siguiente_pregunta = 0;
        tiempo = 25;

        botones.SetActive(false);
		contenedor_canva.SetActive (false);
		teletrasportar (questions [siguiente_pregunta].posicion);
		rotar_pregunta (questions [siguiente_pregunta].rot);
		boton_reinicio.SetActive (false);
		contador.text = " " + tiempo;
		fin.enabled = false;	
		m_CurrentHealth = m_StartingHealth;
		m_HealthBar.fillAmount = 1f;
		puntaje.text = "PUNTAJE:" + puntos.ToString();
		pasar_mision.SetActive(false);

		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<question> ();
		}

		SetCurrentQuestion ();

	}

	void SetCurrentQuestion(){	

//		
		//si supera un 9 de las 10 preguntas puede pasar de mision
		if(puntos>=unansweredQuestions.Count-1){
			pasar_mision.SetActive (true);
		}

		//int randomQuestionsIndex = Random.Range (0,unansweredQuestions.Count);
		if(siguiente_pregunta>=unansweredQuestions.Count){
			mover.SetActive (false);
		}

		else{
			currentQuestion = questions [siguiente_pregunta];
			EnunTextA.text = questions [siguiente_pregunta].A;
			EnunTextB.text = questions [siguiente_pregunta].B;
			EnunTextC.text = questions [siguiente_pregunta].C;
			EnunTextD.text = questions [siguiente_pregunta].D;
			EnunTextA2.text = questions [siguiente_pregunta].A;
			EnunTextB2.text = questions [siguiente_pregunta].B;
			EnunTextC2.text = questions [siguiente_pregunta].C;
			EnunTextD2.text = questions [siguiente_pregunta].D;


			//Debug.Log(currentQuestion.Cual_Es_Correcta_ABCD.ToString());
		}


		factText.text = currentQuestion.ENUNCIADO;
		factText2.text = currentQuestion.ENUNCIADO;


	}

	IEnumerator TranstionToNextQuestion()
	{	
		imagen_tiempo.SetActive (false);
		yield return new WaitForSeconds (0.3f );
		fin.enabled = false;
		contador.enabled = true;
		canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
		botones.SetActive(false);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");
		if (control_cambio_pre == 1) {
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				yield return new WaitForSeconds (6f);
			} else {
				yield return new WaitForSeconds (4f);
			}
			control_cambio_pre = 0;
		} else {
			yield return new WaitForSeconds (1f);
		}

		imagen_correcto.SetActive (false);
		imagen_incorrecto.SetActive (false);
		tiempo = 25;
		imagen_tiempo.SetActive (true);	

		SetCurrentQuestion();
//		
//		//perdiste, intenta de nuevo
//		}
		if (siguiente_pregunta <= unansweredQuestions.Count - 1) {
			teletrasportar (questions [siguiente_pregunta].posicion);
			rotar_pregunta (questions [siguiente_pregunta].rot);

		} 
		else {
			
			contador.enabled = false;
			fin.text=puntos.ToString();
			fin.enabled = true;
			//mover.SetActive (true);
			boton_reinicio.SetActive (true);
			minimap.SetActive (false);


		}
	}

	public void userSelectA()
	{	
		control_cambio_pre = 1;
		tiempo = 100;
		imagen_tiempo.SetActive (false);
		canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
		botones.SetActive(false);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");
		//contenedor_canva.SetActive (false);
		if (currentQuestion.Cual_Es_Correcta_ABCD=="A") {
			puntos++;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_correcto.SetActive (true);
				imagen_incorrecto.SetActive (false);
			} else {
				imagen_correcto2.SetActive (true);
				imagen_incorrecto2.SetActive (false);
			}
			puntaje.text = "PUNTAJE: " + puntos.ToString();
			siguiente_pregunta++;
			//Debug.Log (puntos);
			} 
		else {
			puntos--;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_incorrecto.SetActive (true);
				imagen_correcto.SetActive (false);
			}
			else {
				imagen_correcto2.SetActive (false);
				imagen_incorrecto2.SetActive (true);

			}
			//TakeDamage (1);
			puntaje.text = "PUNTAJE: "+ puntos.ToString();
			siguiente_pregunta++;
			//Debug.Log (puntos);
			}

		StartCoroutine (TranstionToNextQuestion());

	}
	public void userSelectB()
	{	
		control_cambio_pre = 1;
		tiempo = 100;
		imagen_tiempo.SetActive (false);
		canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
		botones.SetActive(false);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");
		//contenedor_canva.SetActive (false);
		if (currentQuestion.Cual_Es_Correcta_ABCD == "B") {
			puntos++;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_correcto.SetActive (true);
				imagen_incorrecto.SetActive (false);

			}
			else {
				imagen_correcto2.SetActive (true);
				imagen_incorrecto2.SetActive (false);

			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;
		}
		else {
			puntos--;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_incorrecto.SetActive (true);
				imagen_correcto.SetActive (false);
				}

			else {
				imagen_correcto2.SetActive (false);
				imagen_incorrecto2.SetActive (true);

			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;

		}

		StartCoroutine (TranstionToNextQuestion());

	}
	public void userSelectC()
	{	
		control_cambio_pre = 1;
		tiempo = 100;
		imagen_tiempo.SetActive (false);
		canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
		botones.SetActive(false);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");
		//contenedor_canva.SetActive (false);
		if (currentQuestion.Cual_Es_Correcta_ABCD == "C") {
			puntos++;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_correcto.SetActive (true);
				imagen_incorrecto.SetActive (false);

			}
			else {
				imagen_correcto2.SetActive (true);
				imagen_incorrecto2.SetActive (false);

			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;

		} 


		else {
			puntos--;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_incorrecto.SetActive (true);
				imagen_correcto.SetActive (false);

			}
			else {
				
					imagen_correcto2.SetActive (false);
					imagen_incorrecto2.SetActive (true);

				
			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;

		}

		StartCoroutine (TranstionToNextQuestion());

	}
	public void userSelectD()
	{	
		control_cambio_pre = 1;
		tiempo = 100;
		imagen_tiempo.SetActive (false);
		canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
		botones.SetActive(false);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");
		//contenedor_canva.SetActive (false);
		if (currentQuestion.Cual_Es_Correcta_ABCD == "D") {
			puntos++;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_correcto.SetActive (true);
				imagen_incorrecto.SetActive (false);

			} 
			else {
				imagen_correcto2.SetActive (true);
				imagen_incorrecto2.SetActive (false);

			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;

		} 
		else {
			puntos--;
			if (siguiente_pregunta < unansweredQuestions.Count - 1) {
				imagen_incorrecto.SetActive (true);
				imagen_correcto.SetActive (false);

			}
			else {
				imagen_correcto2.SetActive (false);
				imagen_incorrecto2.SetActive (true);

			}
			puntaje.text = "PUNTAJE: " + puntos.ToString ();
			siguiente_pregunta++;

		}

		StartCoroutine (TranstionToNextQuestion());

	}

	public void cambio_preguntas (){
		siguiente_pregunta++;
		StartCoroutine (TranstionToNextQuestion());
	}

	void Update () {
//
//		Debug.Log ("hori"+Input.GetAxis("Horizontal"));
//		Debug.Log ("verti"+Input.GetAxis("Vertical"));

		tiempo -= Time.deltaTime;

		contador.text = " " + tiempo.ToString("f0");

		if(tiempo <= 0)
		{
			contador.text = "0";
			fin.enabled = true;
			numero = 1;
			Debug.Log (numero);

		}
		if (numero == 1) {
			canva_alex.transform.GetChild (0).GetComponent<Animator> ().enabled = true;
			cambio_preguntas ();
			contador.enabled = false;
			tiempo = 25;
			numero = 0;

		}

	}
	void teletrasportar(Vector3 pos){
		mover.transform.position = pos;
		//Debug.Log(mover.transform.rotation);
	}
	void rotar_pregunta(float rotacion){
		Quaternion rota = mover.transform.localRotation;
		//mover.transform.localRotation=rota*Quaternion.Euler(0,-90,0);
		mover.transform.localRotation=Quaternion.Euler(0,rotacion,0);
		//Debug.Log (mover.transform.localRotation);
	}
	public void TakeDamage(int damage)
	{
		// Decrement the current health by the damage but make sure it stays between the min and max.
		m_CurrentHealth -=Mathf.Abs(damage);
		m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0f, m_StartingHealth);
		Debug.Log (m_CurrentHealth );
		// Set the health bar to show the normalised health amount.
		m_HealthBar.fillAmount = m_CurrentHealth / m_StartingHealth;

		// If the current health is approximately equal to zero the flyer is dead so destroy it.
		//
	}

	public void Mostrar(){
	
		mostrar.SetActive (false);
		ocultar.SetActive (true);
		contenedor_canva.SetActive (true);
		contenedor_canva.GetComponent<Animator> ().Play("appear_canva");
		botones.SetActive(true);
	
	}

	public void Ocultar(){

		ocultar.SetActive (false);
		mostrar.SetActive (true);
		contenedor_canva.GetComponent<Animator> ().Play("fade out_canva");

//		if (contenedor_canva.GetComponent<Animator> ().isActiveAndEnabled==false) {
//			contenedor_canva.SetActive (false);
//		}

		botones.SetActive(false);


	}

}
