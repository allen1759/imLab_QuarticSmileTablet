using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EmailInputPage : Page {

	const double LIFE_TIME = 30.0;

	double startTime;
	Text remainingTimeText;

	EmailSendButtonClickListener emailSendButtonClickListener;
	KeyboardListener keyboardListener;

	public EmailInputPage (Director director)
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
		GameObject pageAsset = PrefabPool.GetInstance ().GetEmailInputPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);	


		// Link to remainingTimeText
		startTime = Timer.GetInstance ().GetCurrentTime ();
		remainingTimeText = page.transform.FindChild ("RemainingTimeText").gameObject.GetComponent<Text> ();
		remainingTimeText.text = "0";
	}

	private void SetupButtonListener (Director director)
	{
		InputField inputField = page.transform.FindChild ("InputField").gameObject.GetComponent<InputField> ();
		Button keyButton = page.transform.FindChild ("aButton").gameObject.GetComponent<Button> ();
		keyboardListener = new KeyboardListener (inputField);
		keyButton.onClick.AddListener (delegate() {
			keyboardListener.OnClick("a");
		});

		Button sendButton = page.transform.FindChild ("SendButton").gameObject.GetComponent<Button> ();
		emailSendButtonClickListener = new EmailSendButtonClickListener (director);
		sendButton.onClick.AddListener (delegate() {
			emailSendButtonClickListener.OnClick(inputField.text);
		});
	}
}
