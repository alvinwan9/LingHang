using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Reply : AModel
    {
        private int id;

        public int Id
        {
            get { return id;  }
            set { id = value; }
        }
        private int parentld;

        public int Parentld
        {
            get { return parentld;  }
            set { parentld = value; }

        }
        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; }

        }
        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Reply() { }
        public Reply(Reply info)
        {
            this.id = info.id;
            this.parentld = info.parentld;
            this.info = info.info;
            this.time = info.time;
            this.name = info.name;
        }

           


    }
}
