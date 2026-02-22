using Mirror;
using UnityEngine;

public class Connect : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            string onion= "*******.onion"; // replace
            NetworkManager.singleton.networkAddress = onion;
            NetworkManager.singleton.StartClient();
        }
    }
}