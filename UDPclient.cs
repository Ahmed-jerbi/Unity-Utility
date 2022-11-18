using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPclient : MonoBehaviour
{

    UdpClient clientData;
    public int portData = 801;
    public int receiveBufferSize = 120000;

    public bool showDebug = false;
    IPEndPoint ipEndPointData;
    private object obj = null;
    private System.AsyncCallback AC;
    byte[] receivedBytes;


    void Start()
    {
		InitializeUDPListener();
    }


    public void InitializeUDPListener()
    {
        ipEndPointData = new IPEndPoint(IPAddress.Any, portData);
        clientData = new UdpClient();
        clientData.Client.ReceiveBufferSize = receiveBufferSize;
        clientData.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
        clientData.ExclusiveAddressUse = false;
        clientData.EnableBroadcast = true;
        clientData.Client.Bind(ipEndPointData);
        clientData.DontFragment = true;
        if (showDebug) Debug.Log("BufSize: " + clientData.Client.ReceiveBufferSize);
        AC = new System.AsyncCallback(ReceivedUDPPacket);
        clientData.BeginReceive(AC, obj);
        Debug.Log("UDP - Start Receiving..");
    }

    void ReceivedUDPPacket(System.IAsyncResult result)
    {
        receivedBytes = clientData.EndReceive(result, ref ipEndPointData);
        ParsePacket();
        clientData.BeginReceive(AC, obj);
    } 

    /// <summary>
    /// Handle UDP message
    /// </summary>
    void ParsePacket()
    {
        string test = System.Text.Encoding.ASCII.GetString(receivedBytes);
        Debug.Log("UDP Message:"+test);
        //Do things...
    }

    void OnDestroy()
    {
        if (clientData != null)
        {
            clientData.Close();
            Debug.Log("UDP Client closed.");
        }

    }


}