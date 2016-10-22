using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardListener {

	Director director;
	InputField emailField;

	public KeyboardListener (Director director, InputField emailField)
	{
		this.director = director;
		this.emailField = emailField;
	}

	public void OnClick (string key)
	{
		director.SendStateCommand ("DOOR");
		// change button image
	}	
}
