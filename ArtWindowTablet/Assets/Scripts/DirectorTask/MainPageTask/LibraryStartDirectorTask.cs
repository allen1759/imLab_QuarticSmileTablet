using UnityEngine;
using System.Collections;

public class LibraryStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateLibraryNavigationPage ();
	}
}

