//
// Copyright (c) 2017 Geri Borbás http://www.twitter.com/_eppz
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EPPZ.Rate
{


	public class Rate : MonoBehaviour
	{


		// Singleton.
		static Rate _instance;
		void Awake() { _instance = this; }

		// Internal.
		Plugin.Rate _plugin;
		Plugin.Rate plugin
		{
			get
			{
				// Create plugin instance (of whichever platform) lazy.
				if (_plugin == null)
				{ _plugin = Plugin.Rate.NativePluginInstance(); }
				return _plugin;
			}
		}

		public string _iOS_App_ID;
		public string _Android_App_ID;

		static int _rateEventCount;


	#region Features

		public static string iOS_App_ID()
		{ return _instance._iOS_App_ID; }

		public static string Android_App_ID()
		{ return _instance._Android_App_ID; }

		public static bool RequestReviewAtEveryEvent(int frequency)
		{
			_rateEventCount++; // Gets reset on every session
			bool now = (_rateEventCount % frequency == 0);
			if (now)
			{ RequestReviewIfAppropriate(); }
			return now;
		}

		public static void RequestReviewIfAppropriate()
		{ _instance.plugin.RequestReviewIfAppropriate(); }

		public static void OpenAppStoreRatingPage()
		{ _instance.plugin.OpenAppStoreRatingPage(); }

		public static bool IsSandboxEnvironment()
		{ return _instance.plugin.IsSandboxEnvironment(); }

	#endregion

	
	}
}
