using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class StateController 
{
	private TcpClient clientSocket;
	private NetworkStream serverStream;

	private StateControllerListener listener;

	private bool isConnected;

	private string serverName;
	private int serverPort;

	private Thread thread;
	private bool threadStarted;

	public StateController (string name, int port) {

		serverName = name;
		serverPort = port;

		isConnected = false;

		threadStarted = true;
		thread = new Thread (Receiving);
		thread.Start ();
	}

	~StateController() 
	{
		threadStarted = false;
		thread.Join ();
	}

	public void StopThread()
	{
		threadStarted = false;
	}

	public void SetListener (StateControllerListener listener)
	{
		this.listener = listener;
	}
	
	public void SendMessage (string command)
	{
		if (isConnected) {
			byte[] sendBuffer = System.Text.Encoding.ASCII.GetBytes (command);
			serverStream.Write (sendBuffer, 0, sendBuffer.Length);
			serverStream.Flush ();
			Debug.Log (command);
		}
	}

	public void Receiving () 
	{
		while (threadStarted) {
			isConnected = false;

			clientSocket = new TcpClient();
			IAsyncResult result = clientSocket.BeginConnect(serverName, serverPort, null, null );
			bool success = result.AsyncWaitHandle.WaitOne(1000, false);
			Debug.Log(success);

			Debug.Log("Connect:" + clientSocket.Connected);
			while(clientSocket.Connected && threadStarted){
				isConnected = true;
				serverStream = clientSocket.GetStream();

				serverStream.ReadTimeout = 600000;
				int commandSize;

				byte[] readBuffer = new byte[clientSocket.ReceiveBufferSize];
				try{
					commandSize = serverStream.Read(readBuffer, 0, clientSocket.ReceiveBufferSize);
				}catch(IOException se){
					Debug.Log("ex: " + se.ToString());
					break;
				}

				byte[] command = new byte[commandSize];
				System.Array.Copy(readBuffer, command, commandSize);

				string commandString = System.Text.Encoding.ASCII.GetString(command); 
				Debug.Log (commandString);

				if (listener != null)
					listener.OnNewStateCommandReceived (commandString);

				if (!threadStarted)
					break;
			}
			if (serverStream != null)
				serverStream.Close ();
			clientSocket.Close();

		}
		return;
	}

}