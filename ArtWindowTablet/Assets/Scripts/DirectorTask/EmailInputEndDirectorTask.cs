using UnityEngine;
using System.Collections;

public class EmailInputEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEndPage ();
	}
}
