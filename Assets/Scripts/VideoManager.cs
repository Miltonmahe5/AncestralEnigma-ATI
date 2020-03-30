using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;



public class VideoManager : MonoBehaviour {

	public string Scene;
	VideoPlayer video;

	// Use this for initialization
	void Start () {
	
		video = gameObject.GetComponent<VideoPlayer> ();
		video.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!video.isPlaying) {
			SceneManager.LoadScene (Scene);
		}
		
	}
}
