using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
public partial class BackState_ExampleModify : System.Web.UI.Page
{
    DExample info = new DExample();
    static int id;
    static Model.Example example;
    static string pictureName = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataList1.DataSource = info.GetAll();
            DataList1.DataBind();

            GetYear();
            GetMonth();
            GetMainGroup();
            GetDay( Convert.ToInt32(Year.Text),Convert.ToInt32( Month.Text));
        }
    }
    protected void GetMainGroup()
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
        MainGroup.DataSource = dept;
        MainGroup.DataBind();
    }

    protected int IsLeapYear(int year)
    {
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            return 1;
        }
        else
        {
            return 0;
        }
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
        Year.DataSource = value;
        Year.DataBind();
        
    }
    protected void GetMonth()
    {
        List<string> value = new List<string>();
        for (int i = 1; i <13; i++)
        {
            value.Add(i + "");

        }
        Month.DataSource = value;
        Month.DataBind();

        

    }
    protected void GetDay(int year, int month)
    {
        int day = 0;
        switch (month)
        {
            case 2: day = 28 + IsLeapYear(year); break;
            case 4:
            case 6:
            case 9:
            case 11:
                day = 30; break;
            default: day = 31; break;
        }
        List<string> value = new List<string>();
        for (int i = 1; i < day + 1; i++)
        {
            value.Add(i + "");

        }
        Day.DataSource = value;
        Day.DataBind();
    }

    /// <summary>
    /// 文件上传（asp:FileUpload的对象myControl，服务器地址severUrl）
    /// </summary>
    /// <param name="myControl"></param>
    /// <param name="severUrl"></param>
    /// <returns></returns>
    public bool SaveImg(System.Web.UI.WebControls.FileUpload myControl, string severUrl)
    {
        //获取文件的后缀名picLastName
        string localUrl = myControl.PostedFile.FileName;//获取上传的文件路径（本地路径）
        int index = localUrl.LastIndexOf(".");
        string picLastName = localUrl.Substring(index);

        if (picLastName != ".jpeg" && picLastName != ".jpg" && picLastName != ".gif" && picLastName != ".png" && picLastName != ".bmp")
        {
            Response.Write("<script language='javascript'>alert('图片格式不正确！')</script>");
            return false;
        }

        int size = myControl.PostedFile.ContentLength;
        if (size >( 1024*1024 )|| size < 1)
        {
            Response.Write("<script language='javascript'>alert('图片大小必须在1MB以内！')</script>");
            return false;
        }

        //上传后的文件名
        ;
        //根据上传时间给文件命名
        pictureName = DateTime.Now.ToString("yyyyMMddhhmmss") + picLastName;

        try
        {
            myControl.SaveAs(severUrl + "/" + pictureName);

            return true;
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('图片上传失败')</script>");
            return false;
        }
    }


        
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument.ToString());

        example = info.GetExampleById(id);
        Name.Text = example.Name;
        MainGroup.Text = example.MainGroup;
        Year.Text = example.Time.Year+"";
        Month.Text = example.Time.Month + "";
        GetDay(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text));
        Day.Text = example.Time.Day + "";
        Url.Text = example.Url;
        Type.Text = example.Type;
        Info.Text = example.Info;
        if (example.Pic != "")
        {
            ShowImg.ImageUrl = example.Pic;
            Show.Attributes["style"] = "dispaly:block;float:left;margin-left:100px;margin-top:20px";
        }
        else
        {
            ShowImg.ImageUrl = "~/FrontState/ExampleShow/ExampleImg/暂无图片.jpg";
            Show.Attributes["style"] = "dispaly:block;float:left;margin-left:100px;margin-top:20px";
        }




    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        example.Id = id;
        example.Name = Name.Text;
        example.MainGroup = MainGroup.Text;
        DateTime time = Convert.ToDateTime(Year.Text + "-" + Month.Text + "-" + Day.Text);
        example.Time = time;
        example.Url = Url.Text;
        example.Type = Type.Text;
        example.Info = Info.Text;
        

        if (Pic.HasFile)
        {

            if (SaveImg(Pic, MapPath("~/FrontState/ExampleShow/ExampleImg")))
            {
                example.Pic = "~/FrontState/ExampleShow/ExampleImg/" + pictureName;
                if (info.Update(example))
                {
                    Response.Write("<script language='javascript'>alert('修改成功！')</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('修改失败！')</script>");

                }
                example.Pic = "~/FrontState/ExampleShow/ExampleImg/" + pictureName;

            }
        }
        else
        {
            if (info.Update(example))
            {
                Response.Write("<script language='javascript'>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('修改失败！')</script>");

            }

        }

        
        DataList1.DataSource = info.GetAll();
        DataList1.DataBind();
        if (example.Pic != "")
        {
            ShowImg.ImageUrl = example.Pic;
            Show.Attributes["style"] = "dispaly:block;float:left;margin-left:100px;margin-top:20px";
        }
        else
        {
            ShowImg.ImageUrl = "~/FrontState/ExampleShow/ExampleImg/暂无图片.jpg";
            Show.Attributes["style"] = "dispaly:block;float:left;margin-left:100px;margin-top:20px";
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        example = info.GetExampleById(id);
        Name.Text = example.Name;
        MainGroup.Text = example.MainGroup;
        Year.Text = example.Time.Year + "";
        Month.Text = example.Time.Month + "";
        GetDay(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text));
        Day.Text = example.Time.Day + "";
        Url.Text = example.Url;
        Type.Text = example.Type;
        Info.Text = example.Info;
        
    }
    protected void Month_TextChanged(object sender, EventArgs e)
    {
        GetDay(Convert.ToInt32(Year.Text), Convert.ToInt32(Month.Text));
    }
}