using UnityEngine;
using System.Collections;

public class CossStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateCossNavigationPage ();
	}
}

