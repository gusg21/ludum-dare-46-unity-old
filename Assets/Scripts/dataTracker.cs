using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataTracker : MonoBehaviour
{
    static int smallWood = 0;
    static int bigWood = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addBigWood()
    {
        bigWood++;
        
    }

    public static void addSmallWood()
    {
        smallWood++;
        Debug.Log(smallWood);
    }
}
