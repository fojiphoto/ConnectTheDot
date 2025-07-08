using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePix;
using Connect.Core;
using System;



namespace Connect.bilal 
{



public class AdsManager : MonoBehaviour
{

    public static AdsManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

        private void OnEnable()
        {
            CustomAD.ShowinterstialAD += ShowinterstitialAd;
        }
        private void OnDisable()
        {
            CustomAD.ShowinterstialAD -= ShowinterstitialAd;
        }

        public void ShowinterstitialAd()
    {
        Gpx.Ads.InterstitialAd(OnInterstitalAdSuccess);
    }
    [AOT.MonoPInvokeCallback(typeof(Gpx.gpxCallback))]
    public static void OnInterstitalAdSuccess()
    {
        Gpx.Log("SUCCESS");
    }


    private static Action onSuccess;
    public void ShowRewardAd(Action success)
    {
        onSuccess = success;
        Gpx.Ads.RewardAd(OnRewardAdSuccess, OnRewardAdFail);
    }

    [AOT.MonoPInvokeCallback(typeof(Gpx.gpxCallback))]
    public static void OnRewardAdSuccess()
    {
        onSuccess?.Invoke();
        onSuccess = null;
    }

    [AOT.MonoPInvokeCallback(typeof(Gpx.gpxCallback))]
    public static void OnRewardAdFail()
    {
        onSuccess = null;
    }

}
}