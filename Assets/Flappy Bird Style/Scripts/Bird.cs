using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{

	public Sprite[] extremofilosSprites = new Sprite[6];
	public Sprite extreJugador;
	SpriteRenderer m_SpriteRenderer;

	public bool isDead = false;


	public float upForce;					//Upward force of the "flap".
	public static int winner = 0;			//Has the player collided with a wall?

	public int player;

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		//anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

		m_SpriteRenderer = GetComponent<SpriteRenderer>();


		//asigna 
		if (player == 1){

			m_SpriteRenderer.sprite = extremofilosSprites [SelectorJugador.jugador1Pos]; 

		}

		if (player == 2){

			m_SpriteRenderer.sprite = extremofilosSprites [SelectorJugador.jugador2Pos]; 

		}




	}

	void Update()
	{

	


		if (player == 1){
			//Don't allow control if the bird has died.
			if (isDead == false) 
			{
				//Look for input to trigger a "flap".
				if (Input.GetKeyDown((KeyCode.W))) 
				{
					//...tell the animator about it and then...
					//anim.SetTrigger("Flap");
					//...zero out the birds current y velocity before...
					rb2d.velocity = Vector2.zero;
					//	new Vector2(rb2d.velocity.x, 0);
					//..giving the bird some upward force.
					rb2d.AddForce(new Vector2(0, upForce));
				}
			}



		}

		if (player == 2){
			//Don't allow control if the bird has died.
			if (isDead == false) 
			{
				//Look for input to trigger a "flap".
				if (Input.GetKeyDown((KeyCode.UpArrow))) 
				{
					//...tell the animator about it and then...
					//anim.SetTrigger("Flap");
					//...zero out the birds current y velocity before...
					rb2d.velocity = Vector2.zero;
					//	new Vector2(rb2d.velocity.x, 0);
					//..giving the bird some upward force.
					rb2d.AddForce(new Vector2(0, upForce));
				}
			}



		}


	}


	public void movePlayer(){
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(new Vector2(0, upForce));
		
	}




		// If the bird collides with something set it to dead...
		//is


	void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;

		if (other.gameObject.name == "limite"){
			Destroy(gameObject);


		}

	
		// If the bird collides with something set it to dead...
		//isDead = true;
		//...tell the Animator about it...
		//anim.SetTrigger ("Die");
		//...and tell the game control about it.
		//GameControl.instance.BirdDied ();
	}
}
