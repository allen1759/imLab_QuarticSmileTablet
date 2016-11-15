using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Page {

	protected GameObject page;

	protected Director director;
	protected double startTime;
	private double pauseTime;
	protected Text remainingTimeText;

	protected Page (Director director)
	{
		this.director = director;
	}

	public GameObject GetPage()
	{
		return page;
	}

	public abstract void Update ();

	public virtual void OnPause ()
	{
		pauseTime = Timer.GetInstance ().GetCurrentTime ();
	}

	public virtual void OnResume ()
	{
		startTime += Timer.GetInstance ().GetCurrentTime () - pauseTime;
	}

	/**
	 * Some action should be executed immediately after Page is no need,
	 * cannot wait for automatic garbage collcection.
	 */
	public virtual void End ()
	{
	}
}
