using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake Sourdough Bread", "The Home Baker", 620);
        video1.AddComment(new Comment("Maria", "This finally made my starter work!"));
        video1.AddComment(new Comment("James", "Great explanation of the folding technique."));
        video1.AddComment(new Comment("Priya", "My loaf came out perfect, thank you."));
        videos.Add(video1);

        Video video2 = new Video("Beginner Guitar Lesson 1", "Six String Studio", 845);
        video2.AddComment(new Comment("Tyler", "I learned my first chord today!"));
        video2.AddComment(new Comment("Anna", "Please make more of these."));
        video2.AddComment(new Comment("Devon", "The pace was perfect for me."));
        video2.AddComment(new Comment("Sofia", "Subscribed immediately."));
        videos.Add(video2);

        Video video3 = new Video("Top 10 Hiking Trails in Utah", "Wander Outdoors", 1180);
        video3.AddComment(new Comment("Ben", "Zion is on my list now."));
        video3.AddComment(new Comment("Grace", "Beautiful drone footage."));
        video3.AddComment(new Comment("Marcus", "Did the third trail last weekend, amazing."));
        videos.Add(video3);

        Video video4 = new Video("Understanding C# Inheritance", "Code With Sam", 930);
        video4.AddComment(new Comment("Lena", "Best explanation of polymorphism I've seen."));
        video4.AddComment(new Comment("Omar", "The examples really helped."));
        video4.AddComment(new Comment("Chloe", "Could you cover interfaces next?"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}
