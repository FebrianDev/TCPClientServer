using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Client : MonoBehaviour
{
    #region private members

    private TcpClient _connection;
    private Thread _clientReceiveThread;

    #endregion

    [SerializeField] private GameObject msgParent;
    [SerializeField] private InputField inputField;

    private float i = 0;
    private int _idClient;

    private string _data;
    private bool _add = false;
    private void Start()
    {
        _idClient = Random.Range(1, 100000);
        ConnectToTcpServer();
    }

    private void Update()
    {
        if(_data != null)
            InstantiateMessage(_data, i);
    }

    public void BtnSend()
    {
        SendMessage();
    }
    
    // Setup socket connection. 	
    private void ConnectToTcpServer()
    {
        try
        {
            _clientReceiveThread = new Thread(ListenForData) {IsBackground = true};
            _clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    private void ListenForData()
    {
        try
        {
            _connection = new TcpClient("127.0.0.1", 3000); // connect to host & port server
            var bytes = new byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (var stream = _connection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        
                        // Convert byte array to string message. 						
                        var serverMessage = Encoding.ASCII.GetString(incommingData);
                        _data = serverMessage;
                        _add = true;
                        
                        Debug.Log("server message received as: " + serverMessage);
                        
                        i++;
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    // Send message to server using socket connection. 	
    private void SendMessage()
    {
        if (_connection == null) return;
        
        try
        {
            // Get a stream object for writing. 			
            var stream = _connection.GetStream();
            
            if (stream.CanWrite && (inputField.text != null || inputField.text != ""))
            {
                var clientMessage = $"Client {_idClient} : {inputField.text}";

                // Convert string message to byte array.                 
                var clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                    
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void InstantiateMessage(string textmsg, float y)
    {
        if (_add)
        {
            var obj = Instantiate(msgParent, transform);
            obj.transform.parent = gameObject.transform;
            obj.transform.position = obj.transform.position + new Vector3(0, y * -60, 0);
            obj.GetComponent<Text>().text = textmsg;
            _add = false;
        }
    }
}