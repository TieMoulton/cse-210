using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments = new List<Comment>();

    public void AddComment(string commenter, string text)
    {
        comments.Add(new Comment { Commenter = commenter, Text = text });
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video
        {
            Title = "Video 1",
            Author = "Author 1",
            Length = 120
        };
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "Nice content.");

        Video video2 = new Video
        {
            Title = "Video 2",
            Author = "Author 2",
            Length = 180
        };
        video2.AddComment("User3", "Interesting topic.");

        videos.Add(video1);
        videos.Add(video2);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.Commenter}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
