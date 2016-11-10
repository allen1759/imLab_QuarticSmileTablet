using UnityEngine;
using System.Collections;

public abstract class Page {

	protected GameObject page;

	public GameObject GetPage()
	{
		return page;
	}

	public abstract void Update ();

	public virtual void OnResume ()
	{
	}

	/**
	 * Some action should be executed immediately after Page is no need,
	 * cannot wait for automatic garbage collcection.
	 */
	public virtual void End ()
	{
	}
}
