using System;
using System.Collections.Generic;
using System.Text;

public class Tweet : ITweet
{
    public Tweet(string receivedMessage)
    {
        if (string.IsNullOrEmpty(receivedMessage) || string.IsNullOrWhiteSpace(receivedMessage))
        {
            throw new ArgumentException("The received message is invalid!");
        }

        this.Message = receivedMessage;
    }
    public string Message { get; private set; }
}

