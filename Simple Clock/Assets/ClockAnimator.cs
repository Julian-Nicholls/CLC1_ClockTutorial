using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

	//public variables are used so they can be modified in the editor
	public Transform hours, minutes, seconds;
	public Boolean smoothAnimation;

	//private variables are hidden to prevent bugs
	private const float 
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;

	// Update is called once per frame
	void Update () {

		//this updates the clock with fractional positions, instead of absolute ones
		//for example, at 9:59, the hour hand will be closer to 10

		//else, at 9:59, the hour hand still points directly at 9. 
		if (smoothAnimation) {

			TimeSpan timespan = DateTime.Now.TimeOfDay;

			//I'm not 100% sure why it's rotated negatively around Z
			hours.localRotation = Quaternion.Euler (0f, 0f, (float)timespan.TotalHours * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (0f, 0f, (float)timespan.TotalMinutes * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (0f, 0f, (float)timespan.TotalSeconds * -secondsToDegrees);


		} else {
			
			DateTime time = DateTime.Now;
			hours.localRotation = Quaternion.Euler (0f, 0f, time.Hour * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (0f, 0f, time.Minute * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (0f, 0f, time.Second * -secondsToDegrees);

		}
	}
}
