using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class WormholePage : Page, WormholeImageListener {

	const double LIFE_TIME = 90.0;

	WormholeImageReceiver wormholeReceiver;

	public WormholePage (Director director) : base (director)
	{
		SetupComponents ();

		wormholeReceiver = new WormholeImageReceiver ();
		wormholeReceiver.SetListener (this);
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

	public void OnNewImageAvailable(byte[] image1, byte[] image2)
	{
		director.LoadImage (image1, image2);
		director.AssignTask (new WormholeEndDirectorTask ());
	}
}
