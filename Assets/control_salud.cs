using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class control_salud : MonoBehaviour
	{
	public float m_StartingHealth;         // The amount of health the flyer starts with.
		//[SerializeField] private GameObject m_FlyerExplosionPrefab;     // A prefab of the flyer exploded into parts.
	public Image m_HealthBar;                     // Reference to the image used as a health bar.
		//[SerializeField] private AudioSource m_ExplosionAudio;          // Reference to the audio source used to play the explosion sound.
		//[SerializeField] private AudioSource m_ThrusterAudio;           // Reference to the audio source used to play the sound of the flyer engines.
		//[SerializeField] private GameObject[] m_FlyerUIGameObjects;     // All the gameobjects containing UI for the flyer (to be turned off on death).
		//[SerializeField] private Renderer[] m_FlyerRenderers;           // All the renderers for the flyer (to be turned off on death).
		//[SerializeField] private Collider[] m_FlyerColliders;           // All the colliders for the flyer (to be turned off on death).


		 float m_CurrentHealth;                                  // How much health the flyer currently has.
		//bool m_IsDead;                                          // Whether the flyer is currently dead.


		


		//public bool IsDead { get { return m_IsDead; } }


		void Start ()
		{
			// Turn all the visual and physical components of the flyer on.


			// The flyer is not dead and it's health is reset.
			//m_IsDead = false;
			m_CurrentHealth = m_StartingHealth;
			m_HealthBar.fillAmount = 0f;
		}


		

		public void TakeDamage(int damage)
		{
			// Decrement the current health by the damage but make sure it stays between the min and max.
		m_CurrentHealth -=Mathf.Abs(damage);
			m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 1f, m_StartingHealth);
		Debug.Log (m_CurrentHealth );
			// Set the health bar to show the normalised health amount.
			m_HealthBar.fillAmount = m_CurrentHealth / m_StartingHealth;

			// If the current health is approximately equal to zero the flyer is dead so destroy it.
			//
		}

			
	}
