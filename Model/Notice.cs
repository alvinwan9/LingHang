using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Notice : AModel
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string info;
        public string Info
        {
            get { return info;}
            set { info = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public Notice() { }
        public Notice(Notice info)
        {
            this.id = info.id;
            this.title = info.title;
            this.info = info.info;
            this.time = info.time;
            this.author = info.author;
        }
    }
}