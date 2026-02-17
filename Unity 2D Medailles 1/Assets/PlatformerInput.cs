using UnityEngine;

public class PlatformerInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("Omhoog");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Links");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Omlaag");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("Rechts");
        }
    }
    }
