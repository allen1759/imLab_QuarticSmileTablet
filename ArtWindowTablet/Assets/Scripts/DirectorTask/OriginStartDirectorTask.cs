using UnityEngine;
using System.Collections;

public class OriginStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateOriginPage ();
	}
}

