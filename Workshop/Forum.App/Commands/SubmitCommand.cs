using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

public class SubmitCommand : ICommand
{
    private ISession session;
    private IPostService postservice;

    public SubmitCommand(ISession session, IPostService postservice)
    {
        this.session = session;
        this.postservice = postservice;
    }

    public IMenu Execute(params string[] args)
    {
        string replyText = args[0];

        if (string.IsNullOrWhiteSpace(replyText))
        {
            throw new ArgumentException("Cannot add an empty reply!");
        }

        int postId = int.Parse(args[1]);
        int authorId = this.session.UserId;

        this.postservice.AddReplyToPost(postId, replyText, authorId);

        return this.session.Back();
    }
}
