﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class DoorNavigationPage : Page {

	const double LIFE_TIME = 30.0;

	private bool endSession;

	private BackButtonClickListener backButtonClickListener;

	public DoorNavigationPage (Director director) : base (director)
	{
		SetupComponents ();
		SetupButtonListener ();
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Math.Max (Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)), 0).ToString ();

		// same action when back button click
		if (LIFE_TIME - elapsedTime <= 0 && !endSession) {
			director.SendStateCommand ("BACK");
			endSession = true;
		}
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetNavigationPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);	

		// Setup background
		Image doorNavigationPage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
		doorNavigationPage.sprite = MediaPool.GetInstance ().GetDoorNavigationImage ();

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
		endSession = false;
	}

	private void SetupButtonListener ()
	{
		Button backButton = page.transform.FindChild ("BackButton").gameObject.GetComponent<Button> ();
		backButtonClickListener = new BackButtonClickListener (director);
		backButton.onClick.AddListener (backButtonClickListener.OnClick);
	}
}
