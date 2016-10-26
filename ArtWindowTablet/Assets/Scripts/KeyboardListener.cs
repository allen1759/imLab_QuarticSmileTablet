using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardListener {

	InputField emailField;

	public KeyboardListener (InputField emailField)
	{
		this.emailField = emailField;
	}

	public void OnClick (string key)
	{
		Debug.Log (key);
		if (key == "<") {
			if (emailField.text.Length > 0)
				emailField.text = emailField.text.Substring (0, emailField.text.Length - 1);
		}
		else
			emailField.text += key;
	}	
}
