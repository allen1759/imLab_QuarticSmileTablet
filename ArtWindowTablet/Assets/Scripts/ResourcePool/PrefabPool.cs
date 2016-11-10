using UnityEngine;
using System.Collections;

public class PrefabPool {
	//
	private static PrefabPool instance = null; 

	GameObject mainPage;
	GameObject navigationPage;
	GameObject locationPage;
	GameObject videoPage, webPage;
	GameObject wormholePage;
	GameObject confirmPage, fbConfirmPage, emailConfirmPage, emailInputPage;
	GameObject endingPage;
	//

	private PrefabPool ()
	{
		mainPage = (GameObject)Resources.Load ("Prefabs/MainPage");

		navigationPage = (GameObject)Resources.Load ("Prefabs/NavigationPage");
		videoPage = (GameObject)Resources.Load ("Prefabs/VideoPage");
		webPage = (GameObject)Resources.Load ("Prefabs/WebPage");

		wormholePage = (GameObject)Resources.Load ("Prefabs/WormholePage");

		confirmPage = (GameObject)Resources.Load ("Prefabs/ConfirmPage");
		emailInputPage = (GameObject)Resources.Load ("Prefabs/EmailInputPage");

		endingPage = (GameObject)Resources.Load ("Prefabs/EndingPage");
	}

	public static PrefabPool GetInstance()
	{
		if (instance == null)
			instance = new PrefabPool ();
		return instance;
	}

	public GameObject GetMainPage ()
	{
		return mainPage;
	}

	public GameObject GetNavigationPage ()
	{
		return navigationPage;
	}

//	public GameObject GetLocationPage ()
//	{
//		return locationPage;
//	}

	public GameObject GetVideoPage ()
	{
		return videoPage;
	}

	public GameObject GetWebPage ()
	{
		return webPage;
	}

	public GameObject GetWormholePage ()
	{
		return wormholePage;
	}

	public GameObject GetConfirmPage ()
	{
		return confirmPage;
	}

//	public GameObject GetFBConfirmPage ()
//	{
//		return fbConfirmPage;
//	}
//
//	public GameObject GetEmailConfirmPage ()
//	{
//		return emailConfirmPage;
//	}

	public GameObject GetEmailInputPage ()
	{
		return emailInputPage;
	}

	public GameObject GetEndingPage ()
	{
		return endingPage;
	}
}
