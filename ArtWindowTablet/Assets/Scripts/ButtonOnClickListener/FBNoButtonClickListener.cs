using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBNoButtonClickListener : ButtonClickListener {

	Director director;

	public FBNoButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("FB_NO");
		director.AssignTask (new EndPageStartDirectorTask ());
	}
}
