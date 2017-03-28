using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;



public class UIControl : MonoBehaviour {
	public Text tempoui;
	GameObject control;
	public GameObject pausemenu;
	AudioSource audio;
	/*
	//For Google Ads
	private BannerView bannerView;
	private InterstitialAd interstitial;
	private float deltaTime = 0.0f;
	private static string outputMessage = "";

	public static string OutputMessage
	{
		set { outputMessage = value; }
	}
	*/
	// Use this for initialization
	void Start () {
		control = GameObject.Find ("LevelControl");
		audio = control.GetComponent<AudioSource> ();

	
	}
	public void Pause(){
		audio.volume = 0.25f;
		Time.timeScale = 0;
		pausemenu.SetActive (true);
		//RequestBanner ();
		//bannerView.Show ();
	}

	public void Continuar(){
		audio.volume = 1.0f;
		/*
		bannerView.Hide ();
		if (bannerView != null)
			bannerView.Destroy ();
			*/
		pausemenu.SetActive (false);
		Time.timeScale = 1;
	}
	public void Quit() {
		/*
		if (bannerView != null)
			bannerView.Destroy ();
			*/
		Application.Quit ();
	}

	public void MainMenu() {
		Time.timeScale = 1;
		/*
		if (bannerView != null)
			bannerView.Destroy ();
		*/
		SceneManager.LoadScene ("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		LevelControl lc = control.GetComponent<LevelControl> ();
		tempoui.GetComponent<Text> ().text = lc.tempo.ToString("F1");
	
	}
	/*
	//For Google Ads
	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4592480945584537/1136930208";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
		// Register for ad events.
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdLoaded += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());
		}

		private void RequestInterstitial()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-4592480945584537/6214761403";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
		}

		// Returns an ad request with custom ad targeting.
		private AdRequest createAdRequest()
		{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
		}

		private void ShowInterstitial()
		{
		if (interstitial.IsLoaded())
		{
		interstitial.Show();
		}
		else
		{
		print("Interstitial is not ready yet.");
		}
		}

		#region Banner callback handlers

		public void HandleAdLoaded(object sender, EventArgs args)
		{
		print("HandleAdLoaded event received.");
		}

		public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleAdOpened(object sender, EventArgs args)
		{
		print("HandleAdOpened event received");
		}

		void HandleAdClosing(object sender, EventArgs args)
		{
		print("HandleAdClosing event received");
		}

		public void HandleAdClosed(object sender, EventArgs args)
		{
		print("HandleAdClosed event received");
		}

		public void HandleAdLeftApplication(object sender, EventArgs args)
		{
		print("HandleAdLeftApplication event received");
		}

		#endregion

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args)
		{
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		print("HandleInterstitialLeftApplication event received");
		}

		#endregion
		*/
}
