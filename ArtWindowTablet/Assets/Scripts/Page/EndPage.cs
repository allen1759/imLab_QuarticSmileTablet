using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EndPage : Page {

	const double LIFE_TIME = 30.0;

	double startTime;
	Text remainingTimeText;

	RestartButtonClickListener restartButtonClickListener;

	public EndPage (Director director)
	{
		SetupComponents ();
		SetupButtonListener (director);
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)).ToString ();
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetEndingPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// Setup background
//		Image confirmPage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
//		confirmPage.sprite = MediaPool.GetInstance ().GetEndPageImage ();

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener (Director director)
	{
		Button backButton = page.transform.FindChild ("BackButton").gameObject.GetComponent<Button> ();
		restartButtonClickListener = new RestartButtonClickListener (director);
		backButton.onClick.AddListener (restartButtonClickListener.OnClick);
	}
}
