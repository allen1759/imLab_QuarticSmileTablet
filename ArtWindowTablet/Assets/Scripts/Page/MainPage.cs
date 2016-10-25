using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainPage : Page {

	DoorButtonClickListener doorButtonClickListener;
	LibraryButtonClickListener libraryButtonClickListener;
	CossButtonClickListener cossButtonClickListener;
	LakeButtonClickListener lakeButtonClickListener;

	OriginButtonClickListener originButtonClickListener;
	ConceptButtonClickListener conceptButtonClickListener;
	ArtcenterButtonClickListener artcenterButtonClickListener;
	DeptButtonClickListener deptButtonClickListener;
 
	const double FRAME_PERIOD = 0.25;
	Image arrow;
	int arrowAnimationIndex;
	double arrowAnimationTime;
	List<Sprite> arrowAnimation;

	public MainPage (Director director)
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetMainPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);

		// setup image in the unity
//		Image mainPageImage = page.transform.FindChild ("BackgroundImage").gameObject.GetComponent<Image> ();
//		mainPageImage.sprite = MediaPool.GetInstance ().GetMainPageImage ();

		Button doorButton = page.transform.FindChild ("Location/DoorButton").gameObject.GetComponent<Button> ();
//		doorButton.image.sprite = MediaPool.GetInstance ().GetDoorButtonImage ();

		Button libraryButton = page.transform.FindChild ("Location/LibraryButton").gameObject.GetComponent<Button> ();
//		libraryButton.image.sprite = MediaPool.GetInstance ().GetLibraryButtonImage ();

		Button cossButton = page.transform.FindChild ("Location/CossButton").gameObject.GetComponent<Button> ();
//		cossButton.image.sprite = MediaPool.GetInstance ().GetCossButtonImage ();

		Button lakeButton = page.transform.FindChild ("Location/LakeButton").gameObject.GetComponent<Button> ();
//		lakeButton.image.sprite = MediaPool.GetInstance ().GetLakeButtonImage ();

		Button originButton = page.transform.FindChild ("Sidebar/OriginButton").gameObject.GetComponent<Button> ();
//		originButton.image.sprite = MediaPool.GetInstance ().GetOriginButtonImage ();

		Button conceptButton = page.transform.FindChild ("Sidebar/ConceptButton").gameObject.GetComponent<Button> ();
//		conceptButton.image.sprite = MediaPool.GetInstance ().GetConceptButtonImage ();

		Button artcenterButton = page.transform.FindChild ("Sidebar/ArtcenterButton").gameObject.GetComponent<Button> ();
//		artcenterButton.image.sprite = MediaPool.GetInstance ().GetArtcenterButtonImage ();

		Button deptButton = page.transform.FindChild ("Sidebar/DeptButton").gameObject.GetComponent<Button> ();
//		deptButton.image.sprite = MediaPool.GetInstance ().GetDeptButtonImage ();

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

		arrow = page.transform.FindChild ("Arrow").gameObject.GetComponent<Image> ();
		arrowAnimationIndex = 0;
		arrowAnimationTime = Timer.GetInstance ().GetCurrentTime ();
		arrowAnimation = MediaPool.GetInstance ().GetArrowAnimation ();
		arrow.sprite = arrowAnimation[arrowAnimationIndex];
	}

	public override void Update ()
	{
		double currentTime = Timer.GetInstance ().GetCurrentTime ();
		if (currentTime - arrowAnimationTime > FRAME_PERIOD) {
			arrow.sprite = arrowAnimation[arrowAnimationIndex];
			arrowAnimationIndex = (arrowAnimationIndex + 1) % arrowAnimation.Count;
			arrowAnimationTime = currentTime;
		}
	}
}
