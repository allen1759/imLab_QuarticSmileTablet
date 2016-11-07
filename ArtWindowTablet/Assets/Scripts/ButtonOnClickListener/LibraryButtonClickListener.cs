using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LibraryButtonClickListener : ButtonClickListener {

	Director director;
	MainPage mainPage;

	public LibraryButtonClickListener (Director director, MainPage mainPage)
	{
		this.director = director;
		this.mainPage = mainPage;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("LIB");
		mainPage.SetNavigationButtonClick (Place.LIBRARY);
	}
}
