//
// Copyright (c) 2017 Geri Borbás http://www.twitter.com/_eppz
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


namespace EPPZ.Rate.Plugin
{


	public class Rate_iOS : Rate
	{


	#region Import Native implementations

		[DllImport ("__Internal")]
		private static extern void EPPZ_Rate_RequestReviewIfAppropriate();

		[DllImport ("__Internal")]
		private static extern bool EPPZ_Rate_IsSandboxEnvironment();

	#endregion


	#region Features

		public override void RequestReviewIfAppropriate()
		{ EPPZ_Rate_RequestReviewIfAppropriate(); }

		public override void OpenAppStoreRatingPage()
		{
			Debug.Log("EPPZ.Rate.Plugin.Rate_iOS.OpenAppStoreRatingPage()");

			string iOS_7 = ""
				+"itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews"
				+"?id={0}" // App ID
				+"&type=Purple+Software"
				+"&mt=8";

			// string iOS_7 = "itms-apps://itunes.apple.com/app/id<APP_ID>";

			string iOS_8 = ""
				+"itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews"
				+"?id={0}" // App ID
				+"&type=Purple+Software"
				+"&mt=8"
				+"&onlyLatestVersion=true"
				+"&pageNumber=0"
				+"&sortOrdering=1";

			string iOS_11 = ""
				+"itms-apps://itunes.apple.com/us/app/id{0}" // App ID
				+"?action=write-review"
				+"&mt=8";

			// Get iOS (major) version.
			string versionString = UnityEngine.iOS.Device.systemVersion;
			string[] versionTokens = versionString.Split("."[0]);
			int version = int.Parse(versionTokens[0]);

			// Select URL.
			string URL;
			if (version <= 7)
			{ URL = iOS_7; }
			else if (version <= 8)
			{ URL = iOS_8; }
			else
			{ URL = iOS_11; }

			// Inject App ID.
			URL = string.Format(URL, EPPZ.Rate.Rate.iOS_App_ID());

			// Open.
			Debug.Log("Application.OpenURL(`"+URL+"`)");
			Application.OpenURL(URL);
		}

		public override bool IsSandboxEnvironment()
		{ return EPPZ_Rate_IsSandboxEnvironment(); }

	#endregion


	}
}
