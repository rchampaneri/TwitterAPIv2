# TwitterAPIv2 Solution
APIs written in C# that connect to the NEW TwitterAPI

Provides support for the following endpoints:

 * Filtered Stream [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Hide Replies [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Recent Search [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Follows Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Tweet Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * User Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Likes Lookup [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 * Sampled Stream [![v2](https://img.shields.io/endpoint?url=https%3A%2F%2Ftwbadges.glitch.me%2Fbadges%2Fv2)](https://developer.twitter.com/en/docs/twitter-api)
 
 # Prerequisites
* Twitter Developer Account
* Twitter Project and Application in the new Twitter Developer Portal
* Obtain your application key and secret from the Twitter Developer Admin screen
* App.config file in SocialOpinionConsole Project with Application Keys and Secrets from the Twitter Developer Admin screen

# Prerequisites
* Twitter Developer Account
* Twitter Developer Labs Setup (for Labs interfaces)
* Obtain your application key and secret from the Twitter Developer Admin screen
* App.config file in SocialOpinionConsole Project with Application Keys and Secrets from the Twitter Developer Admin screen

# TwitterAPIv2
Contains the C# APIs

# TwitterAPIv2.Tests
Contains unit test cases for SocialOpinionAPI package for twitter API v2.

# TwitterAPIv2Console
Contains examples of how to use the APIs

The following configuration file must exist to ensure the test project works:

**App.config**
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="ConsumerKey" value="key here"/>
    <add key="ConsumerSecret" value="secret here"/>
    <add key="AccessToken" value="access token here"/>
    <add key="AccessTokenSecret" value="access token secret here"/>
  </appSettings>  
</configuration>
```
Alternatively, you can simply assign them in the **Program.cs** file here as string values and bypass loading them from the XML file
```
string _ConsumerKey = "key";
string _ConsumerSecret = "secret";
string _AccessToken = "access token";
string _AccessTokenSecret = "access token secret";
```
## More documentation soon!
