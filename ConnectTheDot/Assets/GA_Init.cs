using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA_Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameAnalyticsSDK.GameAnalytics.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
