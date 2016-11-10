using UnityEngine;
using System.Collections;

public class LakeStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateLakeNavigationPage ();
	}
}

