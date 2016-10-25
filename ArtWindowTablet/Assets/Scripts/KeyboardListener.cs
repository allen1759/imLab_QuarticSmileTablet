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
		emailField.text += key;
	}	
}
