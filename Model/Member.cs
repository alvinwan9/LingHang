using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Member
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

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int joinYear;

        public int JoinYear
        {
            get { return joinYear; }
            set { joinYear = value; }
        }

        private string userPic;

        public string UserPic
        {
            get { return userPic; }
            set { userPic = value; }
        }

        private string qq;

        public string QQ
        {
            get { return qq; }
            set { qq = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string dept;

        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        private string duty;

        public string Duty
        {
            get { return duty; }
            set { duty = value; }
        }

        private int isFinish;

        public int IsFinish
        {
            get { return isFinish; }
            set { isFinish = value; }
        }

        
        public Member() { }

        public Member(Member info)
        {
            this.id = info.id;
            this.name = info.name;
            this.sex = info.sex;
            this.joinYear = info.joinYear;
            this.userPic = info.userPic;
            this.qq = info.qq;
            this.password = info.password;
            this.tel = info.tel;
            this.dept = info.dept;
            this.duty = info.duty;
            this.isFinish = info.isFinish;

        }
    }

}
