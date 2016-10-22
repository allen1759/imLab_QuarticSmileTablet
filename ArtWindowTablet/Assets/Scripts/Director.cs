using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour, 
						StateControllerListener/*,
						WormholeImageListener*/ {
	
	Stack<Page> pageStack;

	StateController stateController;

	DirectorTask directorTask;
	System.Object directorTaskLock;

	// Use this for initialization
	void Start () {
		// Pre-loading
		PrefabPool.GetInstance ();
		MediaPool.GetInstance ();

		stateController = new StateController ("192.168.137.1", 50000);
		stateController.SetListener (this);

		pageStack = new Stack<Page> ();
		pageStack.Push (new MainPage (this));
//		pageStack.Push (new DoorNavigationPage (this));

		directorTask = null;
		directorTaskLock = new System.Object ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		lock (directorTaskLock) {
			if (directorTask != null) {
				directorTask.Action (this);
				directorTask = null;
			}
		}
		if (pageStack.Count == 0)
			Debug.Log ("NO PAGE IN DIRECTOR!!");
		else
			pageStack.Peek ().Update ();
	}

	private void AssignTask (DirectorTask newTask)
	{
		lock (directorTaskLock) {
			directorTask = newTask;
		}
	}

	public void CreateDoorNavigationPage ()
	{
		pageStack.Push (new DoorNavigationPage (this));
	}
	
	public void CreateLibraryNavigationPage ()
	{
		pageStack.Push (new LibraryNavigationPage (this));
	}

	public void CreateCossNavigationPage ()
	{
		pageStack.Push (new CossNavigationPage (this));
	}

	public void CreateLakeNavigationPage ()
	{
		pageStack.Push (new LakeNavigationPage (this));
	}

	public void CreateOriginPage ()
	{
		pageStack.Push (new OriginPage (this));
	}

	public void CreateConceptPage ()
	{
		pageStack.Push (new ConceptPage (this));
	}

	public void CreateDeptPage ()
	{
		pageStack.Push (new WebPage (this));
	}

	public void CreateArtcenterPage ()
	{
		pageStack.Push (new WebPage (this));
	}

	public void DestroyCurrentPage ()
	{
		if (pageStack.Count == 0) {
			Debug.Log ("Cannot pop empty pageStack");
		} 
		else if (pageStack.Count == 1) {
			Debug.Log ("It exists only one page in stack");
		}
		else {
			Destroy (pageStack.Peek ().GetPage ());
			pageStack.Pop ();
		}
	}

	public void SendStateCommand (string command)
	{
		stateController.SendMessage (command);
	}

	public void OnNewStateCommandReceived (string command)
	{
		if (string.Compare (command, "LAKE_TO_DOOR", false) == 0) {
		}
		if (string.Compare (command, "DOOR_TO_LIB", false) == 0) {
		}
		if (string.Compare (command, "SOCIAL_TO_LAKE", false) == 0) {
		}
		if (string.Compare (command, "LIB_TO_SOCIAL", false) == 0) {
		}

		if (string.Compare (command, "DOOR_START", false) == 0) {
			AssignTask (new DoorStartDirectorTask ());
		}
		if (string.Compare (command, "LIB_START", false) == 0) {
			AssignTask (new LibraryStartDirectorTask ());
		}
		if (string.Compare (command, "SOCIAL_START", false) == 0) {
			AssignTask (new CossStartDirectorTask ());
		}
		if (string.Compare (command, "LAKE_START", false) == 0) {
			AssignTask (new LakeStartDirectorTask ());
		}

		if (string.Compare (command, "DOOR_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}
		if (string.Compare (command, "LIB_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}
		if (string.Compare (command, "SOCIAL_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}
		if (string.Compare (command, "LAKE_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}

		if (string.Compare (command, "COSS_FLY_START", false) == 0) {
			AssignTask (new OriginStartDirectorTask ());
		}
		if (string.Compare (command, "COSS_FLY_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}
		if (string.Compare (command, "DEMO_VIDEO_START", false) == 0) {
			AssignTask (new ConceptStartDirectorTask ());
		}
		if (string.Compare (command, "DEMO_VIDEO_END", false) == 0) {
		}
		// web? dept?
		if (string.Compare (command, "WEB_START", false) == 0 ) {
		}
		if (string.Compare (command, "DEPT_START", false) == 0 ) {
			AssignTask (new DeptStartDirectorTask ());
		}
		if (string.Compare (command, "ARTCENTER_START", false) == 0 ) {
			AssignTask (new ArtcenterStartDirectorTask ());
		}
		if (string.Compare (command, "WEB_END", false) == 0) {
			AssignTask (new DestroyCurrentPageDirectorTask ());
		}

		if (string.Compare (command, "WORMHOLE_START", false) == 0) {
		}

		if (command.Length > 11 && string.Compare (command.Substring (0, 11), "EMAIL_SUCC_", false) == 0) {
		}
		if (string.Compare (command, "EMAIL_FAILED", false) == 0) {
		}
	}

	void OnDestroy ()
	{
		stateController.StopThread ();
		Debug.Log ("destroy");
	}
}

