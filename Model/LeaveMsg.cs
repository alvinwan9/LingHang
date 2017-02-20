using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LeaveMsg : AModel
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
       
        private string theme;

          public string Theme
        {
            get { return theme; }
            set { theme = value; }
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

          private string link;

          public string Link
          {
              get { return link; }
              set { link = value; }
          }
          private int isReply;

          public int IsReply
          {
              get { return isReply; }
              set { isReply = value; }
          }

          public LeaveMsg()
          {
              this.time = DateTime.Now;
              this.isReply = 0;
          }
          public LeaveMsg(LeaveMsg info)
          {
              this.id = info.id;
              this.name = info.name;
              this.theme = info.theme;
              this.info = info.info;
              this.time = info.time;
              this.link = info.link;
              this.isReply = info.isReply;
          }

    }
}
    