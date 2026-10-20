using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    internal class Movie : IContent
    {
        private Video video;

        public Movie(Video video)
        {
            this.video = video;
        }

        public string Title { get => video.Title; }
        public int Length { get => video.Length; }

        public int GetLength()
        {
            return video.Length;
        }

        public string GetTitle()
        {
            return video.Title;
        }
    }
}
