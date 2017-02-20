using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Example
    {
        private int id;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string mainGroup;

        public string MainGroup
        {
            get { return mainGroup; }
            set { mainGroup = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string pic;

        public string Pic
        {
            get { return pic; }
            set { pic = value; }
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Example() { }

        public Example(Example info)
        {
            this.id = info.id;
            this.name = info.name;
            this.mainGroup = info.mainGroup;
            this.time = info.time;
            this.url = info.url;
            this.pic = info.pic;
            this.info = info.info;
            this.type = info.type;

        }
    }
}
