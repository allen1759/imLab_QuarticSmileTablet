using UnityEngine;
using System.Collections;

public interface WormholeImageListener {

	void OnNewImageAvailable(byte[] image1, byte[] image2);
}
