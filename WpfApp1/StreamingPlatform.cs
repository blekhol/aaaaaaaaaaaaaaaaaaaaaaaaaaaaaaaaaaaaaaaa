using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    internal class StreamingPlatform
    {
        private List<IContent> tartalmak = [];

        public StreamingPlatform()
        {
        }

        public List<IContent> Tartalmak { get => tartalmak; }

        public void AddContent(IContent content)
        {
            tartalmak.Add(content);
        }

        public IContent Leghosszabb()
        {
            return tartalmak.MaxBy(v => v.GetLength());
        }


    }
}
