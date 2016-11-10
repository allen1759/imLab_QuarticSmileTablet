using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardListener {

	EmailInputPage emailInputPage;
	InputField emailField;

	public KeyboardListener (EmailInputPage emailInputPage, InputField emailField)
	{
		this.emailInputPage = emailInputPage;
		this.emailField = emailField;
	}

	public void OnClick (string key)
	{
		emailInputPage.ResetTimer ();
//		Debug.Log (key);
		if (key == "<") {
			if (emailField.text.Length > 0)
				emailField.text = emailField.text.Substring (0, emailField.text.Length - 1);
		}
		else
			emailField.text += key;
	}	
}
