﻿using UnityEngine;
using UnityEngine.Advertisements;


public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iOSGameId;
    [SerializeField] private bool _testMode;

    private string _gameId;

    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;

        Advertisement.Initialize(_gameId, _testMode);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
