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

	private string[] buttonName = new string[] { "1234567890<", "qwertyuiop", "asdfghjkl-", "@zxcvbnm._" };

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

		keyboardListener = new KeyboardListener (inputField);

		float[] startPosX = { -620, -565, -565, -565 }; 
		float startPosY = 150;
		float deltaX = 110, deltaY = -110;
		for(int i = 0; i < buttonName.Length; i += 1) {
			for (int j = 0; j < buttonName [i].Length; j += 1) {
				// Setup keyboard position
				Button keyButton = page.transform.FindChild ("Keyboard/" + key2name (buttonName [i] [j].ToString ())).gameObject.GetComponent<Button> ();
				keyButton.onClick.AddListener (delegate() {
					keyboardListener.OnClick (name2key (keyButton.name));
				});

				keyButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (startPosX[i] + j * deltaX, startPosY + i * deltaY);
			}
		}

		Button sendButton = page.transform.FindChild ("SendButton").gameObject.GetComponent<Button> ();
		emailSendButtonClickListener = new EmailSendButtonClickListener (director);
		sendButton.onClick.AddListener (delegate() {
			emailSendButtonClickListener.OnClick(inputField.text);
		});
	}

	private string key2name (String key) 
	{
		switch (key) {
		case "@":
			return "mouse";

		case ".":
			return "dot";

		case "<":
			return "delete";

		default:
			return key;
		}
	}

	private string name2key (String name) 
	{
		switch (name) {
		case "mouse":
			return "@";

		case "dot":
			return ".";

		case "delete":
			return "<";

		default:
			return name;
		}
	}
}
