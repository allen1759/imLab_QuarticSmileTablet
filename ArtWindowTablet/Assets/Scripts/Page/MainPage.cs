using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainPage : Page {

	Director director;

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
	Dictionary<Place, Vector2> arrowPositions;
	Dictionary<Place, Quaternion> arrowRotations;

	public MainPage (Director director)
	{
		this.director = director;

		SetupComponents ();

		SetupButtonListener ();

		SetupArrowAnimation ();
	}

	private void SetupComponents ()
	{
		GameObject pageAsset = PrefabPool.GetInstance ().GetMainPage ();
		page = Instantiator.GetInstance ().InstantiatePrefab (pageAsset);
	}
		
	private void SetupButtonListener ()
	{
		Button doorButton = page.transform.FindChild ("Navigation/DoorButton").gameObject.GetComponent<Button> ();
		Button libraryButton = page.transform.FindChild ("Navigation/LibraryButton").gameObject.GetComponent<Button> ();
		Button cossButton = page.transform.FindChild ("Navigation/CossButton").gameObject.GetComponent<Button> ();
		Button lakeButton = page.transform.FindChild ("Navigation/LakeButton").gameObject.GetComponent<Button> ();

		Button originButton = page.transform.FindChild ("Sidebar/OriginButton").gameObject.GetComponent<Button> ();
		Button conceptButton = page.transform.FindChild ("Sidebar/ConceptButton").gameObject.GetComponent<Button> ();
		Button artcenterButton = page.transform.FindChild ("Sidebar/ArtcenterButton").gameObject.GetComponent<Button> ();
		Button deptButton = page.transform.FindChild ("Sidebar/DeptButton").gameObject.GetComponent<Button> ();

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

	private void SetupArrowAnimation ()
	{
		arrow = page.transform.FindChild ("Arrow").gameObject.GetComponent<Image> ();
		arrowAnimationIndex = 0;
		arrowAnimationTime = Timer.GetInstance ().GetCurrentTime ();
		arrowAnimation = MediaPool.GetInstance ().GetArrowAnimation ();
		arrow.sprite = arrowAnimation[arrowAnimationIndex];

		arrowPositions = new Dictionary<Place, Vector2> ();
		arrowPositions.Add (Place.DOOR, new Vector2 (-48, -40));
		arrowPositions.Add (Place.LIBRARY, new Vector2 (330, 75));
		arrowPositions.Add (Place.COSS, new Vector2 (180, 250));
		arrowPositions.Add (Place.LAKE, new Vector2 (-130, 40));

		arrowRotations = new Dictionary<Place, Quaternion> ();
		arrowRotations.Add (Place.DOOR, Quaternion.Euler (0, 0, 150));
		arrowRotations.Add (Place.LIBRARY, Quaternion.Euler (0, 0, 180));
		arrowRotations.Add (Place.COSS, Quaternion.Euler (0, 0, 330));
		arrowRotations.Add (Place.LAKE, Quaternion.Euler (0, 0, 0));
	}
		
	public override void Update ()
	{
		// test code
//		arrow.GetComponent<RectTransform> ().anchoredPosition = arrowPositions [Place.LIBRARY];
//		arrow.GetComponent<RectTransform> ().rotation = arrowRotations [Place.LIBRARY]; 
//		arrow.GetComponent<RectTransform> ().anchoredPosition = arrowPositions [Place.COSS];
//		arrow.GetComponent<RectTransform> ().rotation = arrowRotations [Place.COSS]; 
//		arrow.GetComponent<RectTransform> ().anchoredPosition = arrowPositions [Place.DOOR];
//		arrow.GetComponent<RectTransform> ().rotation = arrowRotations [Place.DOOR]; 
//		arrow.GetComponent<RectTransform> ().anchoredPosition = arrowPositions [Place.LAKE];
//		arrow.GetComponent<RectTransform> ().rotation = arrowRotations [Place.LAKE]; 

		arrow.GetComponent<RectTransform> ().anchoredPosition = arrowPositions [director.arrowPosition];
		arrow.GetComponent<RectTransform> ().rotation = arrowRotations [director.arrowPosition]; 

		double currentTime = Timer.GetInstance ().GetCurrentTime ();
		if (currentTime - arrowAnimationTime > FRAME_PERIOD) {
			arrow.sprite = arrowAnimation[arrowAnimationIndex];
			arrowAnimationIndex = (arrowAnimationIndex + 1) % arrowAnimation.Count;
			arrowAnimationTime = currentTime;
		}
	}
}
