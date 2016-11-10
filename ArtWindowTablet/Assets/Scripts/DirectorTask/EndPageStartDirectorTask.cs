using UnityEngine;
using System.Collections;

public class EndPageStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEndPage ();
	}
}
