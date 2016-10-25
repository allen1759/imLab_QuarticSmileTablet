using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class GestureController {

	private TcpClient clientSocket;
	private NetworkStream serverStream;

	private string serverName;
	private int serverPort;

	private bool isConnected;

	private Thread thread;
	private bool startThread;

	const int WIDTH = 3860, HEIGHT = 2160;
	Vector2 monitorPosition = new Vector2 (WIDTH / 2.0f, HEIGHT / 2.0f);
	Vector2 prePos = new Vector2 (WIDTH / 2.0f, HEIGHT / 2.0f);

	const float CLICK_THRESHOLD = 0.1f;
	bool isTouch = false;
	float touchTime = 0.0f;


	public GestureController (string name, int port) 
	{
		serverName = name;
		serverPort = port;

		startThread = true;
		thread = new Thread (Connect);
		thread.Start ();
	}

	~GestureController () 
	{
		startThread = false;
		thread.Join ();
	}

	public void SendMessage (string command) {
		if (isConnected) {
			byte[] sendBuffer = System.Text.Encoding.ASCII.GetBytes (command);
			serverStream.Write (sendBuffer, 0, sendBuffer.Length);
			serverStream.Flush ();
			Debug.Log (command);
		}
	}

	public void StopThread() {
		startThread = false;
	}


	public void Connect() {
		
		while (startThread) {

			isConnected = false;

			clientSocket = new TcpClient();
			IAsyncResult result = clientSocket.BeginConnect(serverName, serverPort, null, null );
			bool success = result.AsyncWaitHandle.WaitOne(1000, false);
			Debug.Log(success);

			Debug.Log("Connect Gesture:" + clientSocket.Connected);
			while(clientSocket.Connected && startThread){
				isConnected = true;
				serverStream = clientSocket.GetStream();

				serverStream.ReadTimeout = 600000;
				int commandSize;

				byte[] readBuffer = new byte[clientSocket.ReceiveBufferSize];
				try {
					commandSize = serverStream.Read(readBuffer, 0, clientSocket.ReceiveBufferSize);
				}
				catch(IOException se) {
					Debug.Log("Gesture " + se.ToString ());
					break;
				}
			}
			if (serverStream != null)
				serverStream.Close ();
			clientSocket.Close();
		}
	}

	public void SendGesture () 
	{
		if (Input.touchCount == 0)
			return;

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			touchTime = Time.time;
			prePos = Input.GetTouch (0).position;
		}
		else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			if(Time.time - touchTime < CLICK_THRESHOLD)
				SendClickMessage (monitorPosition.x, monitorPosition.y);
		}

		float speed = 0.002f, accerleration = 1.5f;
		Vector2 currPos = new Vector2 ();
		if (Input.touchCount > 0)
			currPos = Input.GetTouch (0).position;

		if (Input.touchCount == 1 && currPos.x >= 260 && currPos.x <= 1650 && currPos.y >= 60 &&currPos.y <= 1000) {

			Vector2 deltaPosition = new Vector2 ();
			deltaPosition = currPos - prePos;
			deltaPosition /= Time.deltaTime;

			monitorPosition.x += speed * ComputePow (deltaPosition.x, accerleration);
			monitorPosition.y -= speed * ComputePow (deltaPosition.y, accerleration);

			if (monitorPosition.x >= WIDTH)
				monitorPosition.x = WIDTH - 1;
			if (monitorPosition.x < 0)
				monitorPosition.x = 0;
			if (monitorPosition.y >= HEIGHT)
				monitorPosition.y = HEIGHT - 1;
			if (monitorPosition.y < 0)
				monitorPosition.y = 0;

			SendDragMessage (monitorPosition.x, monitorPosition.y);

			prePos = currPos;
		}

	}

	private float ComputePow(float a, float p)
	{
		bool neg = false;
		if (a < 0) {
			neg = true;
			a = -a;
		}

		if (neg)
			return -Mathf.Pow (a, p);
		else
			return Mathf.Pow (a, p);
	}
		


	private void SendClickMessage(float xf, float yf)
	{
		int x = (int)xf;
		int y = (int)yf;

		SendMessage ("C" + x.ToString ("0000") + y.ToString ("0000"));
	}

	private void SendDragMessage(float xf, float yf)
	{
		int x = (int)xf;
		int y = (int)yf;

		try
		{
			SendMessage ("D" + x.ToString ("0000") + y.ToString ("0000"));
		}
		catch(Exception ex) {
			Debug.Log (ex.ToString ());
		}
		Debug.Log ("D" + x.ToString ("0000") + y.ToString ("0000"));
	}

}
