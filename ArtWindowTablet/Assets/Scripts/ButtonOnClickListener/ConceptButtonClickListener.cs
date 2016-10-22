using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConceptButtonClickListener : ButtonClickListener {

	Director director;

	public ConceptButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("COSS_FLY");
	}
}
