using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OriginButtonClickListener : ButtonClickListener {

	Director director;

	public OriginButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("DEMO_VIDEO");
	}
}
