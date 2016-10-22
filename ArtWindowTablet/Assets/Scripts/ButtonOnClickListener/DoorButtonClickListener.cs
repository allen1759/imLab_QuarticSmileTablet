using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorButtonClickListener : ButtonClickListener {

	Director director;
	Button button;

	public DoorButtonClickListener (Director director, Button button)
	{
		this.director = director;
		this.button = button;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("DOOR");
		// change button image
	}
}
