using UnityEngine;
using System.Collections;

public class ArtcenterStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateArtcenterPage ();
	}
}


