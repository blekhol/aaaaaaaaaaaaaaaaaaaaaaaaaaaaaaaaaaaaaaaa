using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    internal class Series : IContent
    {
        private string title;
        private List<Video> videos = [];

        public Series(string title, Video video)
        {
            this.title = title;
            this.videos.Add(video);
        }

        public Series(string title, List<Video> videos)
        {
            this.title = title;
            this.videos = videos;
        }

        public string Title { get => title; }
        public int Length { get => GetLength(); }

        public int GetLength()
        {
            return videos.Sum(v => v.Length);
        }

        public string GetTitle()
        {
            return title;
        }
    }
}
