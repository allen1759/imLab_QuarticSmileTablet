using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmailNoButtonClickListener : ButtonClickListener {

	Director director;

	public EmailNoButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("EMAIL_NO");
	}
}
