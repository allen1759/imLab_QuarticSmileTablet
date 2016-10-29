using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class WormholePage : Page {

	Director director;

	const double LIFE_TIME = 9.0;

	double startTime;
	Text remainingTimeText;

	public WormholePage (Director director)
	{
		this.director = director;
		SetupComponents ();
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)).ToString ();

		if (LIFE_TIME - elapsedTime <= 0)
			director.AssignTask (new WormholeEndDirectorTask());
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetWormholePage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}
}
