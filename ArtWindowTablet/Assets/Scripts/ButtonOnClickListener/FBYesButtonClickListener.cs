using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBYesButtonClickListener : ButtonClickListener {

	Director director;

	public FBYesButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("FB_YES");
	}
}
