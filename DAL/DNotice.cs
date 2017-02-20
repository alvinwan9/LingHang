using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class DNotice
    {
        private string columns = "id,title,info,time,author";
        private Notice DRead(SqlDataReader dr)
        {
            Notice info=new Notice();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
            info.Title = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
            info.Info = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.Time = dr.IsDBNull(3) ? DateTime.Now : dr.GetDateTime(3);
            info.Author = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);

            return info;
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public IList<Notice> GetAll()
        {
            IList<Notice> info = new List<Notice>();

            string sql = "SELECT * FROM [tb_notice]";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }

        public IList<Notice> GetFirstSix()
        {
            IList<Notice> info = new List<Notice>();

            string sql = "SELECT top 6 * FROM [tb_notice] order by time desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 根据id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Notice GetById(int id)
        {
            string sql = "SELECT * FROM tb_notice WHERE id=@id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                Notice info = new Notice();

                if (dr.HasRows && dr.Read())
                {
                    info = DRead(dr);
                }
                return info;
            }
        }
        /// <summary>
        /// 按时间排序
        /// </summary>
        /// <returns></returns>
        public IList<Notice> GetAllByTime()
        {
            IList<Notice> info = new List<Notice>();

            string sql = "select * from [tb_notice] order by [time] desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 按标题查找
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IList<Notice> GetTitle(string title)
        {

            string sql = "select * from tb_notice where title like '%'+ @title+'%'";
            IList<Notice> info = new List<Notice>();
            SqlParameter parm1 = new SqlParameter("@title", title);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parm1))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }

        /// <summary>
        /// 查找最近的公告
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Notice Getnewtime()
        {
            IList<Notice> info = new List<Notice>();

            string sql = "select * from [tb_notice] order by [time] desc";

            using(SqlDataReader dr=SqlHelper.ExecuteReader(SqlHelper.ConnectionString,CommandType.Text,sql,null))
            {
                if (dr.HasRows)
                {
                    if (dr.Read()) { return DRead(dr); }
                }
                return null; 
            }
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(Notice info)
        {
            string sql = "INSERT INTO [tb_notice] ( [title], [info], [time], [author]) VALUES ( @title, @info, @time,@author)";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title",info.Title),
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@author",info.Author)
            };

            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, parms) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = "delete from tb_notice where id=@id ";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",id)
            };

            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, parms) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(Notice info)
        {
            string sql = "update tb_notice set author=@author,time=@time,title=@title, info=@info where id =@id";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",info.Id),
                new SqlParameter("@author",info.Author),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@title",info.Title),
                new SqlParameter("@info",info.Info)
            };

            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, parms) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
