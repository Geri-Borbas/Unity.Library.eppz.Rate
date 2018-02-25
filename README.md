# eppz.Rate [![Build Status](https://travis-ci.org/eppz/Unity.Test.eppz.png?branch=master)](https://travis-ci.org/eppz/Unity.Test.eppz)
> part of [**Unity.Library.eppz**](https://github.com/eppz/Unity.Library.eppz)


⭐ App Store rate mechanisms native iOS plugin for Unity.


## Simple usage

```csharp
// iOS 10.3+ `SKStoreReviewController` API.
Rate.RequestReviewIfAppropriate();

// Opens App Store (can be hooked to buttons).
Rate.OpenAppStoreRatingPage();
```

> The plugin works with iOS 7.0. 8.0, 9.0, 10.0 and 11.0.


## Detect TestFlight runtime environment

This plugin also hold a simple test to **determine if the build is running in a TestFlight runtime**. It actually lookup the string `sandboxReceipt` in [`[NSBundle appStoreReceiptURL]`](https://developer.apple.com/documentation/foundation/nsbundle/1407276-appstorereceipturl). This means that it returns true in every sandbox environment including develoment / simulator builds as well. Most probably you'll use this for tagging your analytics.

```
bool isTestFlightBuild = Rate.IsSandboxEnvironment();
```

> While this plugin is still called `Rate`, later on it is gonna be renamed to something that better reflects its content. It seems this will be a collection of native one-liners, or similar.


## License

> Licensed under the [MIT license](http://en.wikipedia.org/wiki/MIT_License).
