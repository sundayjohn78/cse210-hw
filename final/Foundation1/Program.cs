using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // Create and add videos to the list
        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.AddComment("User1", "Great video!");
        video1.AddComment("User2", "Nice content.");
        videos.Add(video1);

        Video video2 = new Video("Video 2", "Author 2", 180);
        video2.AddComment("User3", "Informative.");
        video2.AddComment("User4", "I learned a lot.");
        videos.Add(video2);

        // Display details for each video
        foreach (var video in videos)
        {
            video.DisplayDetails();
        }
    }
}
