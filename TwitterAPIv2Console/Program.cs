using TwitterAPIv2.Clients;
using TwitterAPIv2.Core;
using TwitterAPIv2.DTO.RecentSearch;
using TwitterAPIv2.Models.Blocks;
using TwitterAPIv2.Models.FilteredStream;
using TwitterAPIv2.Models.Followers;
using TwitterAPIv2.Models.Following;
using TwitterAPIv2.Models.HideReplies;
using TwitterAPIv2.Models.Likes;
using TwitterAPIv2.Models.RecentSearch;
using TwitterAPIv2.Models.SampledStream;
using TwitterAPIv2.Models.Timeline;
using TwitterAPIv2.Models.TweetMetrics;
using TwitterAPIv2.Models.Tweets;
using TwitterAPIv2.Models.Users;
using TwitterAPIv2.Services;
using TwitterAPIv2.Services.Blocks;
using TwitterAPIv2.Services.FilteredStream;
using TwitterAPIv2.Services.HideReply;
using TwitterAPIv2.Services.Likes;
using TwitterAPIv2.Services.RecentSearch;
using TwitterAPIv2.Services.SampledStream;
using TwitterAPIv2.Services.Timeline;
using TwitterAPIv2.Services.Tweet;
using TwitterAPIv2.Services.TweetMetrics;
using TwitterAPIv2.Services.Users;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace TwitterAPIv2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string _ConsumerKey = ConfigurationManager.AppSettings.Get("ConsumerKey");
            string _ConsumerSecret = ConfigurationManager.AppSettings.Get("ConsumerSecret");
            string _AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
            string _AccessTokenSecret = ConfigurationManager.AppSettings.Get("AccessTokenSecret");

            OAuthInfo oAuthInfo = new OAuthInfo
            {
                AccessSecret = _AccessTokenSecret,
                AccessToken = _AccessToken,
                ConsumerSecret = _ConsumerSecret,
                ConsumerKey = _ConsumerKey
            };

            TimelineService timeLineService = new TimelineService(oAuthInfo, false);

            UserTweetTimelineModel timelineModel = timeLineService.GetUserTweetsTimeline("373097188", null, false, false, 100, null, null, null, null);

            UserMentionedTimelineModel userMentionedTimeline =
                timeLineService.GetUserMentionedTimeline("38906681", null, 10, null, null, null, null);

            //HideReplyService hideRepliesService = new HideReplyService(oAuthInfo);
            //HideReplyModel model = hideRepliesService.HideReply("1296341968176451585");

            // Sampled Stream Service Test
            SampledStreamService streamService = new SampledStreamService(oAuthInfo);
            streamService.DataReceivedEvent += StreamService_DataReceivedEvent;
            streamService.StartStream("https://api.twitter.com/2/tweets/sample/stream?expansions=attachments.poll_ids,attachments.media_keys,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,referenced_tweets.id,referenced_tweets.id.author_id", 100, 5);

            // Recent Search 
            RecentSearchService searchService = new RecentSearchService(oAuthInfo);

            List<RecentSearchResultsModel> resultsModels = searchService.SearchTweets("iphone", 100, 3);

            TweetService tweetsService = new TweetService(oAuthInfo);
            TweetModel tweetModel = tweetsService.GetTweet("1349116955505160200");
            // Counts Lookup
            tweetsService.GetTweetCounts("BTC", DateTime.Now, TweetService.CountsGranularity.Hour, "", DateTime.Now.AddDays(-1), "");

            Console.WriteLine(tweetModel.data.text);
            Console.WriteLine(tweetModel.data.organic_metrics.impression_count);
            Console.WriteLine(tweetModel.data.organic_metrics.like_count);

            Console.ReadLine();

            List<string> tids = new List<string>();
            tids.Add("1293779846691270658"); // social opinion tweet
            tids.Add("1293779846691270658"); // social opinion tweet
            TweetsModel tweetModels = tweetsService.GetTweets(tids);

            //// User(s)
            UserService userService = new UserService(oAuthInfo);
            UserModel userModel = userService.GetUser("socialopinions");

            UserService userService2 = new UserService(oAuthInfo);
            UserModel userModel2 = userService2.GetUser("Ronak0212");

            List<string> users = new List<string>();
            users.Add("Ronak0212");
            users.Add("socialopinions");
            UsersModel usersResults = userService.GetUsers(users);

            UserService myUserService = new UserService(oAuthInfo);

            FollowersModel followers = myUserService.GetFollowers("958676983", "100", null);

            FollowingModel following = myUserService.GetFollowing("38906681", "100", null);

            // Metrics  
            List<string> ids = new List<string>();
            ids.Add("1258736674844094465"); // social opinion tweet
            TweetMetricsService service = new TweetMetricsService(oAuthInfo);
            List<TweetMetricModel> metricModels = service.GetTweetMetrics(ids);

            // testing Filtered Stream
            FilteredStreamService filteredStreamService = new FilteredStreamService(oAuthInfo);

            List<FilteredStreamRule> rules = filteredStreamService.CreateRule(
                new MatchingRule { tag = "testing #iPhone", Value = "#iphone" });

            filteredStreamService.DataReceivedEvent += FilteredStreamService_DataReceivedEvent;
            filteredStreamService.StartStream("https://api.twitter.com/2/tweets/search/stream?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,public_metrics,possibly_sensitive,referenced_tweets,source,text,withheld&expansions=author_id&user.fields=created_at,description,entities,id,location,name,pinned_tweet_id,profile_image_url,protected,public_metrics,url,username,verified,withheld", 10, 5);


            // Likes Lookup
            LikesService likesService = new LikesService(oAuthInfo);

            List<LikesModel> listOfTweets = likesService.GetUsersLikedTweets("38906681", 5, 1);

            List<TwitterAPIv2.Models.Likes.User> listOfUsersWhoLikedATweet = likesService.GetLikingUsers("1402547535391121409");

            bool hasLiked = likesService.LikeTweet("958676983", "1402590400557240324");
            bool unliked = likesService.UnLikeTweet("958676983", "1402590400557240324");

            // Blocks Service
            BlocksService blocksService = new BlocksService(oAuthInfo);

            List<BlocksModel> lists = blocksService.GetBlocks("958676983", 10);

            bool blockedResult = blocksService.Block("958676983", "34655603");

            bool nowBlocked = blocksService.UnBlock("958676983", "34655603");


        }

        private static void StreamService_DataReceivedEvent(object sender, EventArgs e)
        {
            SampledStreamService.DataReceivedEventArgs eventArgs = e as SampledStreamService.DataReceivedEventArgs;
            SampledStreamModel model = eventArgs.StreamDataResponse;
        }

        private static void FilteredStreamService_DataReceivedEvent(object sender, EventArgs e)
        {
            FilteredStreamService.DataReceivedEventArgs eventArgs = e as FilteredStreamService.DataReceivedEventArgs;
            FilteredStreamModel model = eventArgs.FilteredStreamDataResponse;
        }
    }
}
