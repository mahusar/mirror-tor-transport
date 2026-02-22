using Mirror;
using UnityEngine;

public class Server : MonoBehaviour
{
    void Start()
    {
        // Get the Transport component (Telepathy by default)
        var transport = NetworkManager.singleton.GetComponent<TelepathyTransport>();

        if (transport != null)
        {
            transport.port = 7777;
            Debug.Log($"Port set to {transport.port}");
        }
        else
        {
            Debug.LogError("No TelepathyTransport found on NetworkManager!");
            return;
        }

        NetworkManager.singleton.networkAddress = "127.0.0.1";
        NetworkManager.singleton.StartServer();

        Debug.Log("Server started on localhost:7777");
        Debug.Log("Waiting for connections via .onion...");
    }
}