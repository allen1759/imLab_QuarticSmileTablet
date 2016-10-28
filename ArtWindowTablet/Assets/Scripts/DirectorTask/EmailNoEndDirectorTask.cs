using UnityEngine;
using System.Collections;

public class EmailNoEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEndPage ();
	}
}
