using UnityEngine;
using System.Collections;

public class DestroyCurrentPageDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
	}
}


