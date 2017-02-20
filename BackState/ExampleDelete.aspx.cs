using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.IO;
using System.Data;
using System.Data.OleDb;
public partial class BackState_ExampleDelete : System.Web.UI.Page
{

    static int id;
    DExample info = new DExample();

    public static bool flag = false; 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();
            }
       
    }

    protected bool DeleteImg(string Url)
    {

        FileInfo d_info = new FileInfo(Url);
        d_info.Delete();
        if (System.IO.File.Exists(Url))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {

        id = Convert.ToInt32(e.CommandArgument.ToString());

        Model.Example example = new Model.Example();
        example = info.GetExampleById(id);
        if (!DeleteImg(MapPath(example.Pic)))
        {
            Response.Write("<script language='javascript'>alert('删除失败！')</script>");
        }
        else
        {
            info.Delete(id);
            Response.Write("<script language='javascript'>alert('删除成功！')</script>");
        }

        DataList1.DataSource = info.GetAll();
        DataList1.DataBind();
    }
}