using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class DLeaveMsg
    {
        private string columns = " id,name,theme,info,time,link,isReply ";
        private LeaveMsg DReader(SqlDataReader dr)
        {
            LeaveMsg info = new LeaveMsg();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
            info.Name = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
            info.Theme = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.Info = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
            info.Time = dr.IsDBNull(4) ? DateTime.Now : dr.GetDateTime(4);
            info.Link = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
            info.IsReply = dr.IsDBNull(6) ? 0 : dr.GetInt32(6);
            return info;
        }

        ///<summary>
        ///增
        ///</summary>
        /// <param name="info"></param>
        /// <returns></returns>

        public bool Insert(LeaveMsg info)
        {
            string sql = "INSERT INTO [tb_leaveMsg] ([name], [theme], [info], [time], [link], [isReply]) VALUES(@name, @theme, @info, @time, @link, @isReply)";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name",info.Name),
                new SqlParameter("@theme",info.Theme),
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@link",info.Link),
                new SqlParameter("@isReply",info.IsReply)
               
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

        ///<summary>
        ///删
        ///</summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = "delete from tb_leaveMsg where id=@id ";

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
        ///<summary>
        ///改
        ///</summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(LeaveMsg info)
        {
            string sql = "Update [tb_leaveMsg] SET [name]=@name,[theme]=@theme,[info]=@info,[time]=@time,[link]=@link,[isReply]=@isReply where [id]=@id";
            sql = String.Format(sql  /*补充内容*/);
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",info.Id),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@theme",info.Theme),
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@link",info.Link),
                new SqlParameter("@isReply",info.IsReply)
               
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
        /// 按id查找
        /// </summary>
        /// <returns></returns>
        public LeaveMsg GetleaveMsgById(int id)
        {
            string sql = "SELECT * FROM [tb_leaveMsg] where [id]=@id  order by [time] desc";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                LeaveMsg leavemsg = new LeaveMsg();
                if (dr.HasRows && dr.Read())
                {
                    leavemsg = DReader(dr);
                }
                return leavemsg;
            }
        }
             /// <summary>
        /// 按theme查找
        /// </summary>
        /// <returns></returns>
        public IList<LeaveMsg> GetleaveMsgByTheme(string theme)
        {
            IList<LeaveMsg> info = new List<LeaveMsg>();
       
            string sql = "SELECT * FROM [tb_leaveMsg] where [theme]=@theme order by [time] desc";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@theme", theme)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 按是否回复查找
        /// </summary>
        /// <returns></returns>
        public IList<LeaveMsg> GetleaveMsgByIsReply(int isReply)
        {
            IList<LeaveMsg> info = new List<LeaveMsg>();
       
            string sql = "SELECT * FROM [tb_leaveMsg] where [isReply]=@isReply order by [time] desc";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@isReply", isReply)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }
        public IList<LeaveMsg> GetAll()
        {
            IList<LeaveMsg> info = new List<LeaveMsg>();

            string sql = "SELECT * FROM [tb_leaveMsg] order by [time] desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }
    }
}
