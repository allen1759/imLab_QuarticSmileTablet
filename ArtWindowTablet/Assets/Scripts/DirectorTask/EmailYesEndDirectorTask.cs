using UnityEngine;
using System.Collections;

public class EmailYesEndDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.DestroyCurrentPage ();
		director.CreateEmailInputPage ();
	}
}
