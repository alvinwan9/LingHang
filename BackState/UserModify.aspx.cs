using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class BackState_UserModify : System.Web.UI.Page
{
    DMember info = new DMember();
    static int id;
    static Model.Member member;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Name.Enabled = false;
            Man.Enabled = false;
            Woman.Enabled = false;
            JoinYear.Enabled = false;
            QQ.Enabled = false;
            Tel.Enabled = false;
            Team.Enabled = false;
            Dept.Enabled = false;
            Duty.Enabled = false;
            Submit.Enabled = false;
            Cancel.Enabled = false;
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();

            GetTeam();
            GetYear();
            GetDuty();
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
        int year;
        if (DateTime.Now.Month > 2)
        {
            year = DateTime.Now.Year;
        }
        else
        {
            year = DateTime.Now.Year - 1;
        }

        List<string> value = new List<string>();
        for (int i = year; i > year - 10; i--)
        {
            value.Add(i + "");

        }
        JoinYear.DataSource = value;
        JoinYear.DataBind();
    }

    protected bool IsFinish()
    {
        if (Name.Text != "" && QQ.Text != "" && Tel.Text != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {


        member.Id = id;
        member.Name = Name.Text;
        if (Man.Checked==true)
        {
            member.Sex = Man.Text;
            
        }
        else
        {
            member.Sex = Woman.Text;
        }
        member.JoinYear = Convert.ToInt32(JoinYear.Text);
        member.QQ = QQ.Text;
        member.Tel = Tel.Text;
        member.Dept = Team.Text + "<br/>" + Dept.Text;
        member.Duty = Duty.Text;
        if (IsFinish())
        {
            member.IsFinish = 1;
        }
        else
        {
            member.IsFinish = 0;
        }

        if (info.Update(member))
        {
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");

        }
        else
        {
            Response.Write("<script language='javascript'>alert('修改失败！')</script>");

        }
        DataList1.DataSource = info.GetAll();
        DataList1.DataBind();


    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Name.Enabled = true;
        Man.Enabled = true;
        
        Woman.Enabled = true;
        JoinYear.Enabled = true;
        QQ.Enabled = true;
        Tel.Enabled = true;
        Team.Enabled = true;
        Dept.Enabled = true;
        Duty.Enabled = true;
        Submit.Enabled = true;
        Cancel.Enabled = true;

        id = Convert.ToInt32(e.CommandArgument.ToString());

        member = info.GetMemberById(id);
        Name.Text = member.Name;

        if (member.Sex == "男         ")
        {
            Man.Checked = true;
            
        }
        else if (member.Sex == "女         ")
        {
            Woman.Checked = true;
            
        }
        JoinYear.Text = Convert.ToString(member.JoinYear);
        QQ.Text = member.QQ;
        Tel.Text = member.Tel;

        if (member.Dept == "开发团队" + "<br/>" + ".NET")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = ".NET";

        }
        else if (member.Dept == "开发团队" + "<br/>" + "JAVA")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "JAVA";

        }
        else if (member.Dept == "开发团队" + "<br/>" + "PHP")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "PHP";

        }
        else if (member.Dept == "开发团队" + "<br/>" + "Andriod")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "Andriod";

        }
        else if (member.Dept == "视觉特效" + "<br/>" + "UI")
        {
            Team.Text = "视觉特效";
            GetDept();
            Dept.Text = "UI";

        }
        else if (member.Dept == "视觉特效" + "<br/>" + "美工组")
        {
            Team.Text = "视觉特效";
            GetDept();
            Dept.Text = "美工组";

        }
        else if (member.Dept == "测试团队" + "<br/>" + "　　　")
        {
            Team.Text = "测试团队";
            GetDept();
            Dept.Text = "　　　";

        }



        Duty.Text = member.Duty;


    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        member = info.GetMemberById(id);
        Name.Text = member.Name;
        if (member.Sex == "男         ")
        {
            Man.Checked = true;
            
        }
        else if (member.Sex == "女         ")
        {
            Woman.Checked = true;
            
        }
        JoinYear.Text = Convert.ToString(member.JoinYear);
        QQ.Text = member.QQ;
        Tel.Text = member.Tel;

        Duty.Text = member.Duty;
        if (member.Dept == "开发团队" + "<br/>" + ".NET")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = ".NET";
        }
        else if (member.Dept == "开发团队" + "<br/>" + "JAVA")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "JAVA";
        }
        else if (member.Dept == "开发团队" + "<br/>" + "PHP")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "PHP";
        }
        else if (member.Dept == "开发团队" + "<br/>" + "Andriod")
        {
            Team.Text = "开发团队";
            GetDept();
            Dept.Text = "Andriod";
        }
        else if (member.Dept == "视觉特效" + "<br/>" + "UI")
        {
            Team.Text = "视觉特效";
            GetDept();
            Dept.Text = "UI";
        }
        else if (member.Dept == "视觉特效" + "<br/>" + "美工组")
        {
            Team.Text = "视觉特效";
            GetDept();
            Dept.Text = "美工组";
        }
        else if (member.Dept == "测试团队" + "<br/>" + "")
        {
            Team.Text = "测试团队";
            GetDept();
            Dept.Text = "";
        }



    }
    protected void Team_TextChanged(object sender, EventArgs e)
    {
        GetDept();
    }
}