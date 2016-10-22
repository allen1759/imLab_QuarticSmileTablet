using UnityEngine;
using System;
using System.Collections;

public class Timer : MonoBehaviour {
	
	private static Timer instance = null;
	private double currentTime;

	public static Timer GetInstance ()
	{
		return instance;
	}

	void Awake ()
	{
		if (instance == null) {
			instance = this;
			currentTime = 0.0;
		}
	}

	void Update ()
	{
		currentTime += Convert.ToDouble (Time.deltaTime);
	}

	public double GetCurrentTime ()
	{
		return currentTime;
	}
}

