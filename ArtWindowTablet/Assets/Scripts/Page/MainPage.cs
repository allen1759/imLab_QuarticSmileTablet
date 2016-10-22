﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainPage : Page {

	DoorButtonClickListener doorButtonClickListener;
	LibraryButtonClickListener libraryButtonClickListener;
	CossButtonClickListener cossButtonClickListener;
	LakeButtonClickListener lakeButtonClickListener;

	OriginButtonClickListener originButtonClickListener;
	ConceptButtonClickListener conceptButtonClickListener;
	ArtcenterButtonClickListener artcenterButtonClickListener;
	DeptButtonClickListener deptButtonClickListener;

	public MainPage (Director director)
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetMainPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		Image mainPageImage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
		mainPageImage.sprite = MediaPool.GetInstance ().GetMainPageImage ();

		Button doorButton = page.transform.FindChild ("Location/DoorButton").gameObject.GetComponent<Button> ();
		doorButton.image.sprite = MediaPool.GetInstance ().GetDoorButtonImage ();

		Button libraryButton = page.transform.FindChild ("Location/LibraryButton").gameObject.GetComponent<Button> ();
		libraryButton.image.sprite = MediaPool.GetInstance ().GetLibraryButtonImage ();

		Button cossButton = page.transform.FindChild ("Location/COSSButton").gameObject.GetComponent<Button> ();
		cossButton.image.sprite = MediaPool.GetInstance ().GetCossButtonImage ();

		Button lakeButton = page.transform.FindChild ("Location/LakeButton").gameObject.GetComponent<Button> ();
		lakeButton.image.sprite = MediaPool.GetInstance ().GetLakeButtonImage ();

		Button originButton = page.transform.FindChild ("Sidebar/OriginButton").gameObject.GetComponent<Button> ();
		originButton.image.sprite = MediaPool.GetInstance ().GetOriginButtonImage ();

		Button conceptButton = page.transform.FindChild ("Sidebar/ConceptButton").gameObject.GetComponent<Button> ();
		conceptButton.image.sprite = MediaPool.GetInstance ().GetConceptButtonImage ();

		Button artcenterButton = page.transform.FindChild ("Sidebar/ArtcenterButton").gameObject.GetComponent<Button> ();
		artcenterButton.image.sprite = MediaPool.GetInstance ().GetArtcenterButtonImage ();

		Button deptButton = page.transform.FindChild ("Sidebar/DeptButton").gameObject.GetComponent<Button> ();
		deptButton.image.sprite = MediaPool.GetInstance ().GetDeptButtonImage ();

		// buttons on the map
		doorButtonClickListener = new DoorButtonClickListener (director, doorButton);
		doorButton.onClick.AddListener (doorButtonClickListener.OnClick);

		libraryButtonClickListener = new LibraryButtonClickListener (director, libraryButton);
		libraryButton.onClick.AddListener (libraryButtonClickListener.OnClick);

		cossButtonClickListener = new CossButtonClickListener (director, cossButton);
		cossButton.onClick.AddListener (cossButtonClickListener.OnClick);

		lakeButtonClickListener = new LakeButtonClickListener (director, lakeButton);
		lakeButton.onClick.AddListener (lakeButtonClickListener.OnClick);

		// buttons on the side bar
		originButtonClickListener = new OriginButtonClickListener (director);
		originButton.onClick.AddListener (originButtonClickListener.OnClick);

		conceptButtonClickListener = new ConceptButtonClickListener (director);
		conceptButton.onClick.AddListener (conceptButtonClickListener.OnClick);

		artcenterButtonClickListener = new ArtcenterButtonClickListener (director);
		artcenterButton.onClick.AddListener (artcenterButtonClickListener.OnClick);

		deptButtonClickListener = new DeptButtonClickListener (director);
		deptButton.onClick.AddListener (deptButtonClickListener.OnClick);
	}

	public override void Update ()
	{
	}
}
