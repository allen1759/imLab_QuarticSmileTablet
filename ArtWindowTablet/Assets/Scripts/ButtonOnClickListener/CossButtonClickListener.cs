using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CossButtonClickListener : ButtonClickListener {

	Director director;
	Button button;

	public CossButtonClickListener (Director director, Button button)
	{
		this.director = director;
		this.button = button;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("SOCIAL");
		// change button image
	}
}
