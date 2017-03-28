namespace Facebook.Unity.Example
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class FacebookShareScore : MonoBehaviour {

		// Custom Share Link
		private string shareLink = "http://www.dripp.com.br/noticias/super-moro-bros/";
		private string shareTitle; //= "Lula é preso após "+lastscore+" dias de perseguição";
		private string shareDescription = "Não perca tempo, baixe Super Moro Bros. e ajude nosso herói a piorar o problema da superlotação!";
		private string shareImage = "http://i.imgsafe.org/d6eb7ff.jpg";

		int lastscore = 0;

		void Start() {
			FB.Init ();
			lastscore = PlayerPrefs.GetInt ("lastscore", 0);
		}

		public void ShareOnFBSDK(){

			FB.Init ();
			shareTitle = "Lula é preso após "+lastscore+" dias de perseguição";
			FB.ShareLink(
				new Uri(this.shareLink),
				this.shareTitle,
				this.shareDescription,
				new Uri(this.shareImage),
				callback: ShareCallback);
		}

		private void ShareCallback (IShareResult result) {
			if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
				Debug.Log("ShareLink Error: "+result.Error);
			} else if (!String.IsNullOrEmpty(result.PostId)) {
				// Print post identifier of the shared content
				Debug.Log(result.PostId);
			} else {
				// Share succeeded without postID
				Debug.Log("ShareLink success!");
			}
		}

		public void ShareScoreOnFB(){

			// Your app’s unique identifier.
			string AppID = "1565455693764515";

			// The link attached to this post.
			string Link = "http://www.dripp.com.br/noticias/super-moro-bros/";

			// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
			string Picture = "http://i.imgsafe.org/d6eb7ff.jpg";

			// The name of the link attachment.
			string Name = "Lula é preso após "+PlayerPrefs.GetInt("lastscore", 0)+" dias de perseguição";

			// The caption of the link (appears beneath the link name).
			//public string Caption = "Perseguição durou "+PlayerPrefs.GetInt("lastscore", 0)+" dias;
			string Description = "Não perca tempo, baixe Super Moro Bros. e ajude nosso herói a piorar o problema da superlotação!";

			// The description of the link (appears beneath the link caption).
			string Caption = "Super Moro Bros. - gratuito na Google Play";
			//GetScore ();
			Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+AppID+ "&link="+
				Link+ "&picture="+Picture+ "&name="+ReplaceSpace(Name)+ "&caption="+
				ReplaceSpace(Caption)+ "&description="+ReplaceSpace(Description)+
				"&redirect_uri=https://facebook.com/");
		}

		string ReplaceSpace (string val) {
			return val.Replace(" ", "%20");
		}

	}
}