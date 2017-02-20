using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
public partial class BackState_UserInsert : System.Web.UI.Page
{
    DMember info = new DMember();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();
            GetDept();
            GetTeam();
            GetDuty();
            GetYear();
            GetDept();
        }
        
    }
    protected void GetDuty()
    {
        List<string> duty = new List<string> 
            {
                
                "成员",
                "组长",
                "SQA",                
                "主管"
            };
        Duty.DataSource = duty;
        Duty.DataBind();
    }

    protected void GetTeam()
    {


        List<string> team = new List<string> 
            {
                
                "开发团队",
                "视觉特效",
                "测试团队"
            };
        Team.DataSource = team;
        Team.DataBind();

    }

    protected void GetDept()
    {

        if (Team.Text == "开发团队")
        {
            List<string> dept = new List<string> 
            {
               
                ".NET",
                "JAVA",
                "PHP",
                "Android"
            };
            Dept.DataSource = dept;


        }
        else if (Team.Text == "视觉特效")
        {
            List<string> dept = new List<string> 
            {
                
                "UI",
                "美工组"
            };
            Dept.DataSource = dept;

        }
        else if (Team.Text == "测试团队")
        {
            List<string> dept = new List<string> 
            { 
                "　　　"
            };
            Dept.DataSource = dept;

        }


        Dept.DataBind();
    }

    protected void GetYear()
    {
        int year = DateTime.Now.Year;
        List<string> value = new List<string>();
        for (int i = year; i > year - 10; i--)
        {
            value.Add(i + "");

        }
        JoinYear.DataSource = value;
        JoinYear.DataBind();
    }
    protected void Insert_Click(object sender, EventArgs e)
    {
        Model.Member member = new Model.Member();
        member.Name = Name.Text;
        if (Man.Checked)
        {
            member.Sex = Man.Text;
        }
        else
        {
            member.Sex = Woman.Text;
        }

        member.JoinYear = Convert.ToInt32(JoinYear.Text);

        member.QQ = QQ.Text;
        member.Password = Password.Text;
        member.Tel = Tel.Text;
        member.Dept = Team.Text +"<br/>"+ Dept.Text;
        member.Duty = Duty.Text;
        if (IsFinish())
        {
            member.IsFinish = 1;
        }
        else
        {
            member.IsFinish = 0;
        }



        if (info.Insert(member))
        {
            Response.Write("<script language='javascript'>alert('添加成功！')</script>");

        }
        else
        {
            Response.Write("<script language='javascript'>alert('添加失败！')</script>");

        }
        DataList1.DataSource = info.GetAll();
        DataList1.DataBind();


    }

    protected bool IsFinish()
    {
        if (Name.Text != "" && QQ.Text != "" && Password.Text != "" && Tel.Text != "" )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Name.Text = "";
        Man.Checked = true;
        JoinYear.Text = Convert.ToString(DateTime.Now.Year);
        Password.Text = "";
        Tel.Text = "";
        Team.Text = "开发团队";
        GetDept();
        Dept.Text = ".NET";
        Duty.Text = "成员";
    }
    protected void Team_TextChanged(object sender, EventArgs e)
    {
        GetDept();
    }
}