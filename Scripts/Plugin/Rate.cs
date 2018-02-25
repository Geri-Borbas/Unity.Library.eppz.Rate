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


	public class Rate
	{


	#region Native setup

		public static Rate NativePluginInstance()
		{
			Rate plugin;

			// Get plugin class for the actual platform.
			#if UNITY_IPHONE
			plugin = (Application.isEditor)
				? (Rate)new Rate_Editor()
				: (Rate)new Rate_iOS();
			#elif UNITY_ANDROID
			plugin = (Application.isEditor)
				? (Rate)new Rate_Editor()
				: (Rate)new Rate_Android();
			#else
			plugin = (Rate)new Rate_Editor();
			#endif

			return plugin;
		}

	#endregion


	#region Features

		public virtual void RequestReviewIfAppropriate() { }
		public virtual void OpenAppStoreRatingPage() { }
		public virtual bool IsSandboxEnvironment() { return false; }

	#endregion
	

	}
}
