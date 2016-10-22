using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArtcenterButtonClickListener : ButtonClickListener {

	Director director;

	public ArtcenterButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("ARTCENTER_START");
	}
}
