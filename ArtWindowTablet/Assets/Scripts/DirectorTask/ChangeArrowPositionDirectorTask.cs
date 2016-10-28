using UnityEngine;
using System.Collections;

public class ChangeArrowPositionDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateConceptPage ();
	}
}


