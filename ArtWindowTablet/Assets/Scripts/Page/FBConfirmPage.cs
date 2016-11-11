using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FBConfirmPage : Page {

	Director director;

	const double LIFE_TIME = 60.0;

	double startTime;
	Text remainingTimeText;

	FBYesButtonClickListener fbYesButtonClickListener;
	FBNoButtonClickListener fbNoButtonClickListener;

	public FBConfirmPage (Director director)
	{
		this.director = director;
		SetupComponents ();
		SetupButtonListener (director);
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Math.Max (Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)), 0).ToString ();

		// same action when no button click
		if (LIFE_TIME - elapsedTime <= 0) {
			director.SendStateCommand ("FB_NO");
			director.AssignTask (new EndPageStartDirectorTask ());
		}
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetConfirmPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// Setup background
		Image confirmPage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
		confirmPage.sprite = MediaPool.GetInstance ().GetFBConfirmPageImage ();

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener (Director director)
	{
		Button yesButton = page.transform.FindChild ("YesButton").gameObject.GetComponent<Button> ();
		fbYesButtonClickListener = new FBYesButtonClickListener (director);
		yesButton.onClick.AddListener (fbYesButtonClickListener.OnClick);

		Button noButton = page.transform.FindChild ("NoButton").gameObject.GetComponent<Button> ();
		fbNoButtonClickListener = new FBNoButtonClickListener (director);
		noButton.onClick.AddListener (fbNoButtonClickListener.OnClick);
	}
}
