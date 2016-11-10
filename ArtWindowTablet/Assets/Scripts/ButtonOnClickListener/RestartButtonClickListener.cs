using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartButtonClickListener : ButtonClickListener {

	Director director;

	public RestartButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("RESTART");
		director.AssignTask (new DestroyCurrentPageDirectorTask ());
	}
}
