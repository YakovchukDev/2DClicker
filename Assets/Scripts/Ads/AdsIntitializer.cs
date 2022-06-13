using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsIntitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] private bool _testMode;
        [SerializeField] private string _androidGameId;
        [SerializeField] private string _iosGameId;

        private void Awake()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
            string gameId = (Application.platform == RuntimePlatform.Android) ? _androidGameId : _iosGameId;
            Advertisement.Initialize(gameId, _testMode, this);
        }
        public void OnInitializationComplete()
        {
            Debug.Log("Initialize completed");
        }
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"{error}  Message:{message}");
        }
    }
}
