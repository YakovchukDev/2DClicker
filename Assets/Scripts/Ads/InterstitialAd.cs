using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public static InterstitialAd This;
        [SerializeField] private string _androidUnitId = "Interstitial_Android";
        [SerializeField] private string _iosUnitId = "Interstitial_iOS";

        private void Awake()
        {
            This = this;
        }

        public void LoadAd()
        {
            Advertisement.Load((Application.platform == RuntimePlatform.Android) ? _androidUnitId : _iosUnitId, this);
        }

        public void ShowAd()
        {
            Advertisement.Show((Application.platform == RuntimePlatform.Android) ? _androidUnitId : _iosUnitId, this);
        }
        public void OnUnityAdsAdLoaded(string placementId) { }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

        public void OnUnityAdsShowStart(string placementId) { }

        public void OnUnityAdsShowClick(string placementId) { }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            LoadAd();
        }
    }
}