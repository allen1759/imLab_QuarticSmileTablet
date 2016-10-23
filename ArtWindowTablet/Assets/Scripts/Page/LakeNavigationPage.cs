using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class LakeNavigationPage : Page {

	const double LIFE_TIME = 30.0;

	double startTime;
	Text remainingTimeText;

	BackButtonClickListener backButtonClickListener;

	public LakeNavigationPage (Director director)
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
		GameObject pageAsset = PrefabPool.GetInstance ().GetNavigationPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);	

		// Setup background
		Image doorNavigationPage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
		doorNavigationPage.sprite = MediaPool.GetInstance ().GetLakeNavigationImage ();

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener (Director director)
	{
		Button backButton = page.transform.FindChild ("BackButton").gameObject.GetComponent<Button> ();
		backButtonClickListener = new BackButtonClickListener (director);
		backButton.onClick.AddListener (backButtonClickListener.OnClick);
	}
}
