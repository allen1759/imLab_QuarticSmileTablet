using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeptButtonClickListener : ButtonClickListener {

	Director director;

	public DeptButtonClickListener (Director director)
	{
		this.director = director;
	}

	public void OnClick ()
	{
		director.SendStateCommand ("DEPT_START");
	}
}
