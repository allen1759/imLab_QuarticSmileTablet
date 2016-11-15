using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EndPage : Page {

	const double LIFE_TIME = 60.0;

	RestartButtonClickListener restartButtonClickListener;

	public EndPage (Director director) : base (director)
	{
		SetupComponents ();
		SetupButtonListener ();
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)).ToString ();

		// same action when restart button click
		if (LIFE_TIME - elapsedTime <= 0) {
			director.SendStateCommand ("RESTART");
			director.AssignTask (new DestroyCurrentPageDirectorTask ());
		}
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetEndingPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener ()
	{
		Button backButton = page.transform.FindChild ("BackButton").gameObject.GetComponent<Button> ();
		restartButtonClickListener = new RestartButtonClickListener (director);
		backButton.onClick.AddListener (restartButtonClickListener.OnClick);
	}
}
