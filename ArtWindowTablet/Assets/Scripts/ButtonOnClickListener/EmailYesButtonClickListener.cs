using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EmailYesButtonClickListener : ButtonClickListener {

	Director director;

	public EmailYesButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.AssignTask (new EmailInputStartDirectorTask ());
	}
}
