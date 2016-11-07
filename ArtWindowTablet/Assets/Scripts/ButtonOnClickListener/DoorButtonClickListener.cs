using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorButtonClickListener : ButtonClickListener {

	Director director;
	MainPage mainPage;

	public DoorButtonClickListener (Director director, MainPage mainPage)
	{
		this.director = director;
		this.mainPage = mainPage;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("DOOR");
		mainPage.SetNavigationButtonClick (Place.DOOR);
	}
}
