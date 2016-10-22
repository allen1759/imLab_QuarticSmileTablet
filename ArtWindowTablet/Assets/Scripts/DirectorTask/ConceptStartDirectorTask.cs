using UnityEngine;
using System.Collections;

public class ConceptStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateConceptPage ();
	}
}

