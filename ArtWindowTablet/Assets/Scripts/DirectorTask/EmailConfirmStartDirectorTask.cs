using UnityEngine;
using System.Collections;

public class EmailConfirmStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEmailConfirmPage ();
	}
}
