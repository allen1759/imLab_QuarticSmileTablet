using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MediaPool {
	//
	private static MediaPool instance = null; 

	// Assets in main page
	GameObject mainPage;
	Sprite mainPageImage;
	Sprite doorButtonImage, libraryButtonImage, cossButtonImage, lakeButtonImage;
	Sprite originButtonImage, conceptButtonImage, artcenterButtonImage, deptButtonImage;

	// Assets in navigation page
	Sprite doorNavigationPageImage, libraryNavigationPageImage, cossNavigationPageImage, lakeNavigationPageImage;

	Sprite originPageImage, conceptPageImage, webPageImage;

	private MediaPool ()
	{
		//mainPage = (GameObject)Resources.Load ("Media/MainPage");
		// Assets in main page
		mainPageImage = Resources.Load<Sprite> ("Media/page_image/main_page_image");

		doorButtonImage = Resources.Load<Sprite> ("Media/buttons/door_button");
		libraryButtonImage = Resources.Load<Sprite> ("Media/buttons/library_button");
		cossButtonImage = Resources.Load<Sprite> ("Media/buttons/coss_button");
		lakeButtonImage = Resources.Load<Sprite> ("Media/buttons/lake_button");

		originButtonImage = Resources.Load<Sprite> ("Media/buttons/origin_button");
		conceptButtonImage = Resources.Load<Sprite> ("Media/buttons/concept_button");
		artcenterButtonImage = Resources.Load<Sprite> ("Media/buttons/artcenter_button");
		deptButtonImage = Resources.Load<Sprite> ("Media/buttons/dept_button");

		doorNavigationPageImage = Resources.Load<Sprite> ("Media/page_image/door_navigation_page_image");
		libraryNavigationPageImage = Resources.Load<Sprite> ("Media/page_image/library_navigation_page_image");
		cossNavigationPageImage = Resources.Load<Sprite> ("Media/page_image/coss_navigation_page_image");
		lakeNavigationPageImage = Resources.Load<Sprite> ("Media/page_image/lake_navigation_page_image");

		originPageImage = Resources.Load<Sprite> ("Media/page_image/origin_page_image");
		conceptPageImage = Resources.Load<Sprite> ("Media/page_image/concept_page_image");
		webPageImage = Resources.Load<Sprite> ("Media/page_image/web_page_image");
		//object2
		//object3
	}

	public static MediaPool GetInstance()
	{
		if (instance == null)
			instance = new MediaPool ();
		return instance;
	}

//	public GameObject GetMainpage ()
//	{
//		return mainPage;
//	}

	public Sprite GetMainPageImage ()
	{
		return mainPageImage;
	}

	public Sprite GetDoorButtonImage ()
	{
		return doorButtonImage;
	}

	public Sprite GetLibraryButtonImage ()
	{
		return libraryButtonImage;
	}

	public Sprite GetCossButtonImage ()
	{
		return cossButtonImage;
	}

	public Sprite GetLakeButtonImage ()
	{
		return lakeButtonImage;
	}

	public Sprite GetOriginButtonImage ()
	{
		return originButtonImage;
	}

	public Sprite GetConceptButtonImage ()
	{
		return conceptButtonImage;
	}

	public Sprite GetArtcenterButtonImage ()
	{
		return artcenterButtonImage;
	}

	public Sprite GetDeptButtonImage ()
	{
		return deptButtonImage;
	}

	public Sprite GetDoorNavigationImage ()
	{
		return doorNavigationPageImage;
	}

	public Sprite GetLibraryNavigationImage ()
	{
		return libraryNavigationPageImage;
	}

	public Sprite GetCossNavigationImage ()
	{
		return cossNavigationPageImage;
	}

	public Sprite GetLakeNavigationImage ()
	{
		return lakeNavigationPageImage;
	}

	public Sprite GetOriginImage ()
	{
		return originPageImage;
	}

	public Sprite GetConceptImage ()
	{
		return conceptPageImage;
	}

	public Sprite GetWebPageImage ()
	{
		return webPageImage;
	}
	// public Gamobjet ...
}
