﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class WebPage : Page {

	const double LIFE_TIME = 30.0;

	double startTime;
	Text remainingTimeText;

	BackButtonClickListener backButtonClickListener;

	GestureController gestureController;

	public WebPage (Director director)
	{
		SetupComponents ();
		SetupButtonListener (director);

		gestureController = new GestureController ("192.168.137.1", 50001);
	}

//	~WebPage ()
//	{
//		gestureController.StopThread ();
//	}

	public override void End ()
	{
		gestureController.StopThread ();
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)).ToString ();

		gestureController.SendGesture ();
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetWebPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);	

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
