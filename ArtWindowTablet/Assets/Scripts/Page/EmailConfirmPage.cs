using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EmailConfirmPage : Page {

	const double LIFE_TIME = 60.0;

	EmailYesButtonClickListener emailYesButtonClickListener;
	EmailNoButtonClickListener emailNoButtonClickListener;

	public EmailConfirmPage (Director director) : base (director)
	{
		SetupComponents ();
		SetupButtonListener ();
	}

	public override void Update ()
	{
		double elapsedTime = Timer.GetInstance ().GetCurrentTime () - startTime;
		remainingTimeText.text = Math.Max (Convert.ToInt32 (Math.Floor (LIFE_TIME - elapsedTime)), 0).ToString ();

		// same action when no button click
		if (LIFE_TIME - elapsedTime <= 0) {
			director.SendStateCommand ("EMAIL_NO");
			director.AssignTask (new EndPageStartDirectorTask ());
		}
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetConfirmPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// Setup background
		Image confirmPage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
		confirmPage.sprite = MediaPool.GetInstance ().GetEmailConfirmPageImage ();

		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener ()
	{
		Button yesButton = page.transform.FindChild ("YesButton").gameObject.GetComponent<Button> ();
		emailYesButtonClickListener = new EmailYesButtonClickListener (director);
		yesButton.onClick.AddListener (emailYesButtonClickListener.OnClick);

		Button noButton = page.transform.FindChild ("NoButton").gameObject.GetComponent<Button> ();
		emailNoButtonClickListener = new EmailNoButtonClickListener (director);
		noButton.onClick.AddListener (emailNoButtonClickListener.OnClick);
	}
}
