using UnityEngine;
using System.Collections;

public class EmailConfirmEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEndPage ();
	}
}
