using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	private static Instantiator instance = null;

	public static Instantiator GetInstance ()
	{
		return instance;
	}

	public GameObject InstantiatePrefab(GameObject prefab)
	{
		return Instantiate (prefab);
	}

	void Awake()
	{
		if (instance == null) {
			instance = this;
		}
	}

}
