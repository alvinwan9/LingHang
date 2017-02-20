using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class BackState_UserSelect : System.Web.UI.Page
{
    DMember info = new DMember();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();
            GetYear();
            GetTeam();
            GetDuty();
            GetDept();
        }
        
    }

    protected void GetDuty()
    {
        List<string> duty = new List<string> 
            {
                "全部",
                "主管",
                "SQA",
                "组长",
                "成员"
            };
        SearchDuty.DataSource = duty;
        SearchDuty.DataBind();
    }
    protected void GetTeam()
    {


        List<string> team = new List<string> 
            {
                "全部",
                "开发团队",
                "视觉特效团队",
                "测试团队"
            };
        SearchTeam.DataSource = team;
        SearchTeam.DataBind();

    }

    protected void GetDept()
    {

        if (SearchTeam.Text == "开发团队")
        {
            List<string> dept = new List<string> 
            {
               
                ".NET",
                "JAVA",
                "PHP",
                "Android"
            };
            SearchDept.DataSource = dept;


        }
        else if (SearchTeam.Text == "视觉特效团队")
        {
            List<string> dept = new List<string> 
            {
                
                "UI",
                "美工组"
            };
            SearchDept.DataSource = dept;

        }
        else if (SearchTeam.Text == "测试团队")
        {
            List<string> dept = new List<string> 
            { 
                "　　　"
            };
            SearchDept.DataSource = dept;

        }
        else 
        {
            List<string> dept = new List<string> 
            {
               "全部",
                ".NET",
                "JAVA",
                "PHP",
                "Android",
                "UI",
                "美工组"
            };
            SearchDept.DataSource = dept;

        }


        SearchDept.DataBind();
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
        value.Add("全部");
        for (int i = year; i > year - 10; i--)
        {
            value.Add(i + "");

        }
        SearchJoinYear.DataSource = value;
        SearchJoinYear.DataBind();
    }


    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (SearchDuty.Text == "全部" && SearchName.Text == "" && SearchJoinYear.Text == "全部" && SearchDept.Text == "全部")
        {
            DataList1.DataSource = info.GetAll();
            //Response.Write("0");
           
        }
        else if (!SearchName.Text.Equals(""))
        {
            if (SearchJoinYear.Text != "全部")
            {
                DataList1.DataSource = info.GetMemberByNameAndJoinYear(SearchName.Text, Convert.ToInt32(SearchJoinYear.Text));
                //Response.Write("1");
            }
            else
            {
                DataList1.DataSource =info.GetMemberByName(SearchName.Text);
               // Response.Write("2");


            }
        }
        else if (SearchJoinYear.Text != "全部")
        {
                DataList1.DataSource = info.GetMemberByNameAndJoinYear("", Convert.ToInt32(SearchJoinYear.Text));
                //Response.Write("3");

           
        }
        else if (SearchDept.Text != "全部")
        {
            if (SearchDuty.Text != "全部")
            {
                DataList1.DataSource = info.GetMemberByDeptAndDuty(SearchDept.Text, SearchDuty.Text);
               // Response.Write("4");

            }
            else
            {
                DataList1.DataSource = info.GetMemberByDeptAndDuty(SearchDept.Text, "");
                //Response.Write("5");

            }
        }
        else if (SearchDuty.Text != "全部")
        {

            DataList1.DataSource = info.GetMemberByDeptAndDuty("", SearchDuty.Text);
           // Response.Write("6");

        }
        DataList1.DataBind();


    }



    protected void Cancel_Click(object sender, EventArgs e)
    {
        SearchDuty.Text = "全部" ;
        SearchName.Text = "" ;
        SearchJoinYear.Text = "全部";
        SearchDept.Text = "全部";
    }
    protected void SearchTeam_TextChanged(object sender, EventArgs e)
    {
        GetDept();
    }
}