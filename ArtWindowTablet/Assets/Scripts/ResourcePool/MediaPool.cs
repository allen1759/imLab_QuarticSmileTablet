﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MediaPool {
	//
	private static MediaPool instance = null; 

	// Assets in main page
	GameObject mainPage;
	Sprite mainPageImage;
	Sprite doorButtonImage, libraryButtonImage, cossButtonImage, lakeButtonImage;
	Sprite doorButtonClickImage, libraryButtonClickImage, cossButtonClickImage, lakeButtonClickImage;
	Sprite originButtonImage, conceptButtonImage, artcenterButtonImage, deptButtonImage;

	// Assets in navigation page
	Sprite doorNavigationPageImage, libraryNavigationPageImage, cossNavigationPageImage, lakeNavigationPageImage;

	Sprite originPageImage, conceptPageImage, webPageImage;

	Sprite fbConfirmPageImage, emailConfirmPageImage;

	Sprite endPageImage;

	List<Sprite> arrowAnimation;

	private MediaPool ()
	{
		// Assets in main page
		mainPageImage = Resources.Load<Sprite> ("Media/page_image/main_page_image");

		doorButtonImage = Resources.Load<Sprite> ("Media/buttons/door_button");
		libraryButtonImage = Resources.Load<Sprite> ("Media/buttons/library_button");
		cossButtonImage = Resources.Load<Sprite> ("Media/buttons/coss_button");
		lakeButtonImage = Resources.Load<Sprite> ("Media/buttons/lake_button");

		doorButtonClickImage = Resources.Load<Sprite> ("Media/buttons/door_button_click");
		libraryButtonClickImage = Resources.Load<Sprite> ("Media/buttons/library_button_click");
		cossButtonClickImage = Resources.Load<Sprite> ("Media/buttons/coss_button_click");
		lakeButtonClickImage = Resources.Load<Sprite> ("Media/buttons/lake_button_click");

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

		fbConfirmPageImage = Resources.Load<Sprite> ("Media/page_image/fb_confirm_page_image");
		emailConfirmPageImage = Resources.Load<Sprite> ("Media/page_image/email_confirm_page_image");

		endPageImage = Resources.Load<Sprite> ("Media/page_image/end_page_image");

		arrowAnimation = new List<Sprite> ();
		for (int i = 0; i < 9; ++i)
			arrowAnimation.Add (Resources.Load<Sprite> ("Media/arrow/" + i.ToString ()));
	}

	public static MediaPool GetInstance()
	{
		if (instance == null)
			instance = new MediaPool ();
		return instance;
	}

	public Sprite GetMainPageImage ()
	{
		return mainPageImage;
	}

	public Sprite GetDoorButtonImage (bool isClick)
	{
		if (isClick)
			return doorButtonClickImage;
		else
			return doorButtonImage;
	}

	public Sprite GetLibraryButtonImage (bool isClick)
	{
		if (isClick)
			return libraryButtonClickImage;
		else
			return libraryButtonImage;
	}

	public Sprite GetCossButtonImage (bool isClick)
	{
		if (isClick)
			return cossButtonClickImage;
		else
			return cossButtonImage;
	}

	public Sprite GetLakeButtonImage (bool isClick)
	{
		if (isClick)
			return lakeButtonClickImage;
		else
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

	public Sprite GetFBConfirmPageImage ()
	{
		return fbConfirmPageImage;
	}

	public Sprite GetEmailConfirmPageImage ()
	{
		return emailConfirmPageImage;
	}

	public Sprite GetEndPageImage ()
	{
		return endPageImage;
	}

	public List<Sprite> GetArrowAnimation ()
	{
		return arrowAnimation;
	}
}