using System;
using System.Collections.Generic;
using System.Text;

public class Client : IClient
{
    private List<ITweet> tweets;

    public Client()
    {
        this.Tweets = new List<ITweet>();
    }

    public int TweetsCount => this.Tweets.Count;

    public List<ITweet> Tweets { get; set; }

    public ITweet Tweet(string message)
    {
        ITweet tweet = new Tweet(message);

        this.Tweets.Add(tweet);

        return tweet;
    }
}

