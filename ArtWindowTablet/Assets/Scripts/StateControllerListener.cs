using UnityEngine;
using System.Collections;

public interface StateControllerListener {

	void OnNewStateCommandReceived (string command);
}
