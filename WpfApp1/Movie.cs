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
