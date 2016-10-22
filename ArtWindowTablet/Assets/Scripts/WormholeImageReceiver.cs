using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System;
using System.Net;
using System.Threading;

public class WormholeImageReceiver {
	public WormholeImageListener listener;

	private TcpListener listenSocket;

	private Thread thread;

	// Use this for initialization
	public WormholeImageReceiver () 
	{
		IPEndPoint ipEndPoint = new IPEndPoint (IPAddress.Any, 50011);
		listenSocket = new TcpListener (ipEndPoint);

		thread = new Thread (Receiving);
		thread.Start();
	}

	public void SetListener (WormholeImageListener imageListener)
	{
		listener = imageListener;
	}

	public void Receiving ()
	{
		// Start listening for incoming connection
		listenSocket.Start ();
		// Establish connection
		TcpClient clientSocket = listenSocket.AcceptTcpClient ();

		NetworkStream clientStream = clientSocket.GetStream ();

		// Read image1 size (4 bytes for int)
		byte[] readBuffer = new byte[4];
		clientStream.Read(readBuffer, 0, readBuffer.Length);

		uint image1Size = BitConverter.ToUInt32(readBuffer, 0);
		byte[] image1 = new byte[image1Size];

		int image1byteCount = 0;
		int image1bufferSize = ((Convert.ToInt32(image1Size) / 1400) + 2) * 1400;
		byte[] image1Buffer = new byte[image1bufferSize];
		while (image1byteCount < image1Size)
		{
			int receiveByte = clientStream.Read(image1Buffer, image1byteCount, 1400);
			image1byteCount += receiveByte;
		}
		Array.Copy (image1Buffer, image1, image1Size);

		// Image 2
		clientStream.Read (readBuffer, 0, readBuffer.Length);

		uint image2Size = BitConverter.ToUInt32(readBuffer, 0);
		byte[] image2 = new byte[image2Size];

		int image2byteCount = 0;
		int image2bufferSize = ((Convert.ToInt32(image1Size) / 1400) + 2) * 1400;
		byte[] image2Buffer = new byte[image2bufferSize];
		while (image2byteCount < image2Size)
		{
			int receiveByte = clientStream.Read(image2Buffer, image2byteCount, 1400);
			image2byteCount += receiveByte;
		}
		Array.Copy (image2Buffer, image2, image2Size);

		if (listener != null)
			listener.OnNewImageAvailable(image1, image2);

		clientSocket.Close ();
		listenSocket.Stop ();
	}
}
