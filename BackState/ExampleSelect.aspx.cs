using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
public partial class BackState_ExampleSelect : System.Web.UI.Page
{
    DExample info = new DExample();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();

            GetDept();
        }
    }

    protected void GetDept()
    {
        List<string> dept = new List<string> 
            {
                "全部",
                "UI",
                "美工组",
                "PHP",
                "JAVA",
                ".NET",
                "Android"
            };
        SearchByDept.DataSource = dept;
        SearchByDept.DataBind();
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (SearchByName.Text == "" && SearchByType.Text == "" && SearchByDept.Text == "全部")
        {
            DataList1.DataSource = info.GetAll();
        }
        if (SearchByName.Text != "")
        {
            if (SearchByType.Text != "" && SearchByDept.Text != "全部")
            {
                DataList1.DataSource = info.GetExampleByAll(SearchByName.Text, SearchByType.Text, SearchByDept.Text);
            }
            else if (SearchByType.Text == "" && SearchByDept.Text != "全部")
            {
                DataList1.DataSource = info.GetExampleByAll(SearchByName.Text, "", SearchByDept.Text);
            }
            else if (SearchByDept.Text == "全部" && SearchByType.Text != "")
            {
                DataList1.DataSource = info.GetExampleByAll(SearchByName.Text, SearchByType.Text, "");
            }
            else if (SearchByType.Text == "" && SearchByDept.Text == "全部")
            {
                DataList1.DataSource = info.GetExampleByAll(SearchByName.Text, "", "");
                
            }
        }
        if (SearchByType.Text != "")
        {
            if (SearchByDept.Text != "全部")
            {
                DataList1.DataSource = info.GetExampleByAll("", SearchByType.Text, SearchByDept.Text);
            }
            else
            {
                DataList1.DataSource = info.GetExampleByAll("", SearchByType.Text, "");
            }
        }
        if (SearchByDept.Text != "全部")
        {
            DataList1.DataSource = info.GetExampleByAll("", "", SearchByDept.Text);
        }
        DataList1.DataBind();
    }
    protected void Candel_Click(object sender, EventArgs e)
    {
        SearchByName.Text = "";
        SearchByDept.Text = "全部";
        SearchByType.Text = "";

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id;
        Model.Example newexample = new Model.Example();
        id = Convert.ToInt32(e.CommandArgument.ToString());
        newexample = info.GetExampleById(id);

        if (newexample.Pic != "")
        {
            ShowImg.ImageUrl = newexample.Pic;
            Show.Attributes["style"] = "dispaly:block;;margin-left:auto;margin-top:20px;margin-right:auto;width:50%";
        }
        else
        {
            ShowImg.ImageUrl = "~/FrontState/ExampleShow/ExampleImg/暂无图片.jpg";
            Show.Attributes["style"] = "dispaly:block;;margin-left:auto;margin-top:20px;margin-right:auto;width:50%";
        }
    }
}