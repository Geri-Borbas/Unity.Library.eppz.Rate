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


namespace EPPZ.Rate.Plugin
{


	public class Rate_Android : Rate
	{

		
	#region Features

		public override void RequestReviewIfAppropriate()
		{
			// TODO: Lookup / implement `requestReview` counterpart.
		}

		public override void OpenAppStoreRatingPage()
		{	
			Debug.Log("EPPZ.Rate.Plugin.Rate_Android.OpenAppStoreRatingPage()");

			// Select URL.
			string URL = "https://play.google.com/store/apps/details?id={0}";

			// Inject App ID.
			URL = string.Format(URL, EPPZ.Rate.Rate.Android_App_ID());

			// Open.
			Debug.Log("Application.OpenURL(`"+URL+"`)");
			Application.OpenURL(URL);
		}

	#endregion


	}
}
