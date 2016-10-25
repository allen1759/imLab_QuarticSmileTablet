using UnityEngine;
using System.Collections;

public class WormholeEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateFBConfirmPage ();
	}
}
