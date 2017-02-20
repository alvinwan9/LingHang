using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Member_Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindYearList();
            type = "全部";
        }
        DataListBind();
    }
    protected void AllLBtn_Click(object sender, EventArgs e)
    {
        AllLi.Attributes["style"] = "background-color:#5fc132;";
        ManagerLi.Attributes["style"] = "background-color:#111c24;";
        SkillerLi.Attributes["style"] = "background-color:#111c24;";
        SpecialerLi.Attributes["style"] = "background-color:#111c24;";
        TesterLi.Attributes["style"] = "background-color:#111c24;";
        type = "全部";
        DataListBind();
    }
    protected void ManagerLBtn_Click(object sender, EventArgs e)
    {
        AllLi.Attributes["style"] = "background-color:#111c24;";
        ManagerLi.Attributes["style"] = "background-color:#5fc132;";
        SkillerLi.Attributes["style"] = "background-color:#111c24;";
        SpecialerLi.Attributes["style"] = "background-color:#111c24;";
        TesterLi.Attributes["style"] = "background-color:#111c24;";
        type = "主管";
        DataListBind();
    }
    protected void SkillerLBtn_Click(object sender, EventArgs e)
    {
        AllLi.Attributes["style"] = "background-color:#111c24;";
        ManagerLi.Attributes["style"] = "background-color:#111c24;";
        SkillerLi.Attributes["style"] = "background-color:#5fc132;";
        SpecialerLi.Attributes["style"] = "background-color:#111c24;";
        TesterLi.Attributes["style"] = "background-color:#111c24;";
        type = "开发";
        DataListBind();
    }
    protected void SpecialerLBtn_Click(object sender, EventArgs e)
    {
        AllLi.Attributes["style"] = "background-color:#111c24;";
        ManagerLi.Attributes["style"] = "background-color:#111c24;";
        SkillerLi.Attributes["style"] = "background-color:#111c24;";
        SpecialerLi.Attributes["style"] = "background-color:#5fc132;";
        TesterLi.Attributes["style"] = "background-color:#111c24;";
        type = "特效";
        DataListBind();
    }
    protected void TesterLBtn_Click(object sender, EventArgs e)
    {
        AllLi.Attributes["style"] = "background-color:#111c24;";
        ManagerLi.Attributes["style"] = "background-color:#111c24;";
        SkillerLi.Attributes["style"] = "background-color:#111c24;";
        SpecialerLi.Attributes["style"] = "background-color:#111c24;";
        TesterLi.Attributes["style"] = "background-color:#5fc132;";
        type = "测试";
        DataListBind();
    }
    protected void YearList_TextChanged(object sender, EventArgs e)
    {
        DataListBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataListBind();
    }
    private void BindYearList()
    {
        int nowYear = Convert.ToInt32(DateTime.Now.Year);
        List<string> info = new List<string>();
        info.Add("全部");
        for (int i = nowYear; i > 2009; i--)
        {
            info.Add(i + "");
        }
        YearList.DataSource=info;
        YearList.DataBind();
    }
    private static string  type; 
    private string GetMemberType()
    {
        if (type.Equals("全部"))
        {
            return "";
        }
        return type;
    }
    private int GetYear()
    {
        if (YearList.Text.Equals("全部"))
        {
            return 0;
        }
        return Convert.ToInt32(YearList.Text);
    }
    private string GetName()
    {
        if (MemberNameText.Value.Equals("请输入姓名....."))
        {
            return "";
        }
        return MemberNameText.Value;
    }
    private void DataListBind()
    {
        string type = GetMemberType();
        int year = GetYear();
        string name = GetName();
        DAL.DMember list=new DAL.DMember();
        if (type.Equals(""))
        {
            ManagerList.DataSource = list.GetMemberByManyInfo("", "主管", name, year);
            ManagerList.DataBind();
            AndroiderList.DataSource = list.GetMemberByManyInfo(type + "%Android", "", name, year);
            AndroiderList.DataBind();
            ASPNETerList.DataSource = list.GetMemberByManyInfo(type+"%.NET", "", name, year);
            ASPNETerList.DataBind();
            PHPerList.DataSource = list.GetMemberByManyInfo(type+"%PHP", "", name, year);
            PHPerList.DataBind();
            JavaerList.DataSource = list.GetMemberByManyInfo(type+"%JAVA", "", name, year);
            JavaerList.DataBind();
            PSerList.DataSource = list.GetMemberByManyInfo(type+"%美工", "", name, year);
            PSerList.DataBind();
            UIerList.DataSource = list.GetMemberByManyInfo(type+"%UI", "", name, year);
            UIerList.DataBind();
            TesterList.DataSource = list.GetMemberByManyInfo("测试", "", name, year);
            TesterList.DataBind();
        }
        if (type.Contains("主管"))
        {
            ManagerList.DataSource = list.GetMemberByManyInfo("", "主管", name, year);
            ManagerList.DataBind();
            AndroiderList.DataSource = null;
            AndroiderList.DataBind();
            ASPNETerList.DataSource = null;
            ASPNETerList.DataBind();
            PHPerList.DataSource = null;
            PHPerList.DataBind();
            JavaerList.DataSource = null;
            JavaerList.DataBind();
            PSerList.DataSource = null;
            PSerList.DataBind();
            UIerList.DataSource = null;
            UIerList.DataBind();
            TesterList.DataSource = null;
            TesterList.DataBind();
        }
        if (type.Contains("开发"))
        {
            ManagerList.DataSource = null;
            ManagerList.DataBind();
            AndroiderList.DataSource = list.GetMemberByManyInfo(type + "%Android", "", name, year);
            AndroiderList.DataBind();
            ASPNETerList.DataSource = list.GetMemberByManyInfo(type + "%.NET", "", name, year);
            ASPNETerList.DataBind();
            PHPerList.DataSource = list.GetMemberByManyInfo(type + "%PHP", "", name, year);
            PHPerList.DataBind();
            JavaerList.DataSource = list.GetMemberByManyInfo(type + "%JAVA", "", name, year);
            JavaerList.DataBind();
            PSerList.DataSource = null;
            PSerList.DataBind();
            UIerList.DataSource = null;
            UIerList.DataBind();
            TesterList.DataSource = null;
            TesterList.DataBind();
        }
        if (type.Contains("特效"))
        {
            ManagerList.DataSource = null;
            ManagerList.DataBind();
            AndroiderList.DataSource = null;
            AndroiderList.DataBind();
            ASPNETerList.DataSource = null;
            ASPNETerList.DataBind();
            PHPerList.DataSource = null;
            PHPerList.DataBind();
            JavaerList.DataSource = null;
            JavaerList.DataBind();
            PSerList.DataSource = list.GetMemberByManyInfo(type + "%美工", "", name, year);
            PSerList.DataBind();
            UIerList.DataSource = list.GetMemberByManyInfo(type + "%UI", "", name, year);
            UIerList.DataBind();
            TesterList.DataSource = list.GetMemberByManyInfo("测试", "", name, year);
            TesterList.DataBind();
        }
        if (type.Contains("测试"))
        {
            ManagerList.DataSource = null;
            ManagerList.DataBind();
            AndroiderList.DataSource = null;
            AndroiderList.DataBind();
            ASPNETerList.DataSource = null;
            ASPNETerList.DataBind();
            PHPerList.DataSource = null;
            PHPerList.DataBind();
            JavaerList.DataSource = null;
            JavaerList.DataBind();
            PSerList.DataSource = null;
            PSerList.DataBind();
            UIerList.DataSource = null;
            UIerList.DataBind();
            TesterList.DataSource = list.GetMemberByManyInfo("测试", "", name, year);
            TesterList.DataBind();
        }
    }
    
}