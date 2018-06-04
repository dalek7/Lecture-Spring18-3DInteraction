using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

// Used for 717300@Hallym Univ.
// https://forum.unity.com/threads/simple-udp-implementation-send-read-via-mono-c.15900/

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port; 

    // infos
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; // clean up this from time to time!

    private Rigidbody rb;
	private bool bdisplay = true;

    // start from shell
    private static void Main()
    {
        UDPReceive receiveObj = new UDPReceive();
        receiveObj.init();

        string text = "";
        do
        {
            text = Console.ReadLine();
        }
        while (!text.Equals("exit"));
    }

    // start from unity3d
    public void Start()
    {
        init();
    }

    // OnGUI
    void OnGUI()
    {
		if (bdisplay) 
		{
			Rect rectObj = new Rect (40, 10, 200, 400);
			GUIStyle style = new GUIStyle ();
			style.alignment = TextAnchor.UpperLeft;
			GUI.Box (rectObj, "# UDPReceive\n127.0.0.1 " + port + " #\n"
			+ "shell> nc -u 127.0.0.1 : " + port + " \n"
			+ "\nLast Packet: \n" + lastReceivedUDPPacket
			+ "\n\nAll Messages: \n" + allReceivedUDPPackets
                , style);
		}
    }

    // init
    private void init()
    {
        rb = GetComponent<Rigidbody>();
        print("UDPSend.init()");
        
		port = 12345;

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
		
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);
                print(">> " + text);

				if(text.Trim().ToLower().Equals("a"))
                {
                    Vector3 movement = new Vector3(-100, 0, 0);
                    rb.AddForce(movement);
                }
				else if (text.Trim().ToLower().Equals("d"))
                {
                    Vector3 movement = new Vector3(100, 0, 0);
                    rb.AddForce(movement);
                }
				else if(text.Trim().ToLower().Equals("w"))
				{
					Vector3 movement = new Vector3(0, 0, 100);
					rb.AddForce(movement);
				}
				else if(text.Trim().ToLower().Equals("s"))
				{
					Vector3 movement = new Vector3(0, 0, -100);
					rb.AddForce(movement);
				}
				else if(text.Trim().ToLower().Equals("j"))
				{
					Vector3 movement = new Vector3(0, 300, 0);
					rb.AddForce(movement);
				}
                // latest UDPpacket
                lastReceivedUDPPacket = text;
                allReceivedUDPPackets = allReceivedUDPPackets + text;
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    // getLatestUDPPacket
    // cleans up the rest
    public string getLatestUDPPacket()
    {
        allReceivedUDPPackets = "";
        return lastReceivedUDPPacket;
    }

    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }
}