using UnityEngine;
using System.Collections;

public abstract class Page {

	protected GameObject page;

	public GameObject GetPage()
	{
		return page;
	}

	public abstract void Update ();

	public virtual void End ()
	{
	}
}
