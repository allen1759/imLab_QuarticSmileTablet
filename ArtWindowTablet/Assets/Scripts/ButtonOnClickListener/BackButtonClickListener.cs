using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButtonClickListener : ButtonClickListener {

	Director director;

	public BackButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("BACK");
	}
}
