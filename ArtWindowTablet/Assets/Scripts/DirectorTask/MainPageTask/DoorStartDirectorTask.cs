using UnityEngine;
using System.Collections;

public class DoorStartDirectorTask : DirectorTask {

	public void Action (Director director)
	{
		director.CreateDoorNavigationPage ();
	}
}
