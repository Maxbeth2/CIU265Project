using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataSender : MonoBehaviour, ArduinoEvent 
{
    private string serverURL = "http://localhost:5000/write"; // Replace with your Flask server URL

    private void OnApplicationQuit() {
        ShutOffVibrations();
    }

    void Start()
    {
        Debug.Log("Starting...");   
        activateRelay(17);
    }



    public void PerformEvent(int relayNum)
    {
        activateRelay(relayNum);
    }

    public void activateRelay(int relayNum)
    {   
        // print(relayNum);
        StartCoroutine(SendDataToServer(relayNum));
    }

    public void DropMagazines()
    {
        StartCoroutine(RotateServo());
    }

    

    public void ShutOffVibrations()
    {
        StartCoroutine(SendDataToServer(17));
    }

    float timePassed = 0f;
    List<int> relayList = new List<int>{0, 1, 2, 3};

    int currentRelay = 0; 

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            Debug.Log("Space pressed");
            ShutOffVibrations();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {   
            Debug.Log("Enter pressed");
            DropMagazines();
        }

        // timePassed += Time.deltaTime;
        // if (timePassed > 2f)
        // {   
            
        //     timePassed = 0f;
        //     if (currentRelay < relayList.Count)
        //     {
        //         activateRelay(relayList[currentRelay]);
                
        //         currentRelay++;

        //         if (currentRelay == relayList.Count)
        //         {
        //             currentRelay = 0;
        //         }
        //     }
        // }

    }



    IEnumerator SendDataToServer(int relayNum)
    {   
        Debug.Log("Sending data to server...");
        // Create a POST request
        UnityWebRequest request = new UnityWebRequest(serverURL, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        // Create JSON data to send (replace with your data)
        string jsonData = "{\"relay\": " + relayNum + "}";
        print(jsonData);
        // Convert JSON data to a byte array
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Attach the data to the request
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        // Send the request
        yield return request.SendWebRequest();

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.DataProcessingError))
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Data sent successfully.");
        }
    }

    IEnumerator RotateServo()
    {   
        Debug.Log("Sending data to server...");
        // Create a POST request
        UnityWebRequest request = new UnityWebRequest("http://localhost:5000/rotate_servo");
        request.SetRequestHeader("Content-Type", "application/json");

        // Create JSON data to send (replace with your data)
        string jsonData = "{\"relay\": " + 7 + "}";
        print(jsonData);
        // Convert JSON data to a byte array
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Attach the data to the request
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        // Send the request
        yield return request.SendWebRequest();

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.DataProcessingError))
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Data sent successfully.");
        }
    }

    public void PerformEvent()
    {
        throw new System.NotImplementedException();
    }

}
