using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LakeButtonClickListener : ButtonClickListener {

	Director director;
	Button button;

	public LakeButtonClickListener (Director director, Button button)
	{
		this.director = director;
		this.button = button;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("Lake");
		// change button image
	}
}
