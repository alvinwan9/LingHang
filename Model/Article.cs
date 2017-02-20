using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Article:AModel
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

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
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

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private int isImportant;
        public int IsImportant
        {
            get { return isImportant; }
            set { isImportant = value; }
        }

        private int readedTotal;
        public int ReadedTotal
        {
            get { return readedTotal; }
            set { readedTotal = value; }
        }

        private string qq;
        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }

        public Article()
        {
            time = DateTime.Now;
            readedTotal = 0;
            isImportant = 0;
        }
        public Article(Article info)
        {
            this.id = info.Id;
            this.title = info.Title;
            this.name = info.Name;
            this.info = info.Info;
            this.time = info.Time;
            this.type = info.Type;
            this.isImportant = info.IsImportant;
            this.readedTotal = info.ReadedTotal;
            this.qq = info.QQ;
        }
    }
}
