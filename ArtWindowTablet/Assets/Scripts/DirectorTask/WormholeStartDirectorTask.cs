using UnityEngine;
using System.Collections;

public class WormholeStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateWormholePage ();
	}
}
