using UnityEngine;
using System.Collections;

public class DeptStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateDeptPage ();
	}
}

