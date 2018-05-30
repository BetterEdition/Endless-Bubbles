using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
public class AdManager : MonoBehaviour
{
    public static bool adHasBeenInit = false;
    public string adVideoID = "ca-app-pub-2396385345826088/4663849182";
    public string adBannerID = "ca-app-pub-2396385345826088~8220661255";
    public static AdManager Instance { set; get; }

    // Use this for initialization
    void Start()
    {
        InstatiateAdmob();

    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play ads from Editor");
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
#endif
    }
    public void ShowVideo()
    {
#if UNITY_EDITOR
        Debug.Log("Unable to play ads from Editor");
#elif UNITY_ANDROID
        if(Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
            Debug.Log("VideoAd");
        } 
#endif
    }
    public void InstatiateAdmob()
    {
        if (!adHasBeenInit)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
#elif UNITY_ANDROID
            Admob.Instance().initAdmob(adBannerID, adVideoID);
            Admob.Instance().setTesting(true);
            Admob.Instance().loadInterstitial();
            adHasBeenInit = true;
#endif
        }
       
    }
}
