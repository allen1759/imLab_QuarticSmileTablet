using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LibraryButtonClickListener : ButtonClickListener {

	Director director;
	Button button;

	public LibraryButtonClickListener (Director director, Button button)
	{
		this.director = director;
		this.button = button;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("LIB");
		// change button image
	}
}
