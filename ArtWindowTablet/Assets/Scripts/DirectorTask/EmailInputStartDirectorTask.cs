using UnityEngine;
using System.Collections;

public class EmailInputStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEmailInputPage ();
	}
}
