using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DAL
{
  public  class DReply
    {
        private string columns = " id,parentld,info,time,name ";
        private Reply DReader(SqlDataReader dr)
        {
            Reply info = new Reply();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);

            info.Parentld = dr.IsDBNull(1) ? 0 : dr.GetInt32(1); 
            info.Info = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.Time = dr.IsDBNull(3) ? DateTime.Now : dr.GetDateTime(3); 
            info.Name = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
           
            return info;
        }
        ///<summary>
        ///增
        ///</summary>
        /// <param name="info"></param>
        /// <returns></returns>

        public bool Insert(Reply info)
        {
            string sql = "INSERT INTO [tb_reply] ([parentld] , [info], [time],[name]) VALUES(@parentld, @info, @time, @name)";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@parentld",info.Parentld),
               
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@name",info.Name)
              
               
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
            string sql = "delete from tb_reply where id=@id ";

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
        /// ///改
        ///</summary>
        /// <param name="info"></param>
        /// <returns></returns>
        
            public bool Update(Reply info)
        {
            string sql = "Update [tb_reply] SET [parentld]=@parentld,[info]=@info,[time]=@time,[name]=@name where [id]=@id";
            sql = String.Format(sql  /*补充内容*/);
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",info.Id),
                new SqlParameter("@parentld",info.Parentld),
               
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@name",info.Name)
              
               
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
            public Reply GetreplyById(int id)
            {
                string sql = "SELECT * FROM [tb_reply] where [id]=@id  order by [time] desc";

                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)))
                {
                   Reply re = new Reply();
                    if (dr.HasRows && dr.Read())
                    {
                        re = DReader(dr);
                    }
                    return re;
                }
            }
            /// <summary>
            /// 按parentld查找
            /// </summary>
            /// <returns></returns>
            public IList<Reply> GetreplyByparentld(int parentld)
            {
                string sql = "SELECT * FROM [tb_reply] where [parentld]=@parentld  order by [time] desc";

                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@parentld", parentld)))
                {
                    IList<Reply> info = new List<Reply>();
                    if (dr.HasRows)
                    {
                        while (dr.Read()) { info.Add(DReader(dr)); }
                    }
                    return info;
                }
            }
            public IList<Reply> GetAll()
            {
                IList<Reply> info = new List<Reply>();

                string sql = "SELECT * FROM [tb_reply] order by [time] desc";
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
