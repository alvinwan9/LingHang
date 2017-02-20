using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
public partial class BackState_UserDelete : System.Web.UI.Page
{
    static int id;
    DMember info = new DMember();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();            
        }
        
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument.ToString());
        info.Delete(id);

        DataList1.DataSource = info.GetAll();
        DataList1.DataBind();
    }


}