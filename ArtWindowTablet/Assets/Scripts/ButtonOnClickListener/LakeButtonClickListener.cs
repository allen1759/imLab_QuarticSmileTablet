using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LakeButtonClickListener : ButtonClickListener {

	Director director;
	MainPage mainPage;

	public LakeButtonClickListener (Director director, MainPage mainPage)
	{
		this.director = director;
		this.mainPage = mainPage;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("Lake");
		mainPage.SetNavigationButtonClick (Place.LAKE);
	}
}
