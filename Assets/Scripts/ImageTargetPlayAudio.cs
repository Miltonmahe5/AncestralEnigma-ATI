using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		} else {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Stop ();
		}

		// Update is called once per frame
	}
}


