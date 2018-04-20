using System.Collections.Generic;

public interface IClient
{
    ITweet Tweet(string message);

    List<ITweet> Tweets { get;  }
}