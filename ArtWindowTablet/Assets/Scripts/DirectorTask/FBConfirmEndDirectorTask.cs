using UnityEngine;
using System.Collections;

public class FBConfirmEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEmailConfirmPage ();
	}
}
