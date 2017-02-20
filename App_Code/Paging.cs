using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Paging 的摘要说明
/// </summary>
public class Paging
{
    /// <summary>
    /// 数据集合
    /// </summary>
    private IList<Object> list;
    /// <summary>
    /// 总页码数
    /// </summary>
    private int totalPage;
    /// <summary>
    /// 当前页码
    /// </summary>
    private int currentPage;
    /// <summary>
    /// 每页显示的个数
    /// </summary>
    private int pageSize;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="list"></param>
    /// <param name="pagesize"></param>
	public Paging(IList<Object> list,int pagesize)
	{
        this.list = list;
        int total=list.Count;
        this.pageSize = pagesize;
        this.totalPage = total / pagesize + (total % pagesize > 0 ? 1 : 0);
        this.currentPage = 1;
	}
    public int GetCurrentPage()
    {
        return currentPage;
    }
    public int GetTotalPage()
    {
        return totalPage;
    }
    public bool NextPage()
    {
        if (currentPage != totalPage)
        {
            currentPage++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool PrePage()
    {
        if (currentPage != 1)
        {
            currentPage--;
            return true;
        }
        else
        {
            return false;
        }
    }
    public IList<Object> GetCurrentList()
    {
        List<Object> bindList = new List<Object>();
        int n = (currentPage == totalPage||totalPage==0 ? list.Count : currentPage * pageSize);
        for (int i = pageSize * (currentPage - 1); i < n; i++)
        {
            bindList.Add(list[i]);
        }
        return bindList;
    }
}