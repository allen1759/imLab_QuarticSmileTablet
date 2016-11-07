using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CossButtonClickListener : ButtonClickListener {

	Director director;
	MainPage mainPage;

	public CossButtonClickListener (Director director, MainPage mainPage)
	{
		this.director = director;
		this.mainPage = mainPage;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("SOCIAL");
		mainPage.SetNavigationButtonClick (Place.COSS);
	}
}
