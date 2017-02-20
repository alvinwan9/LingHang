using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class DExample
    {
        private string colums = "id,name,mainGroup,time,url,pic,info,type";

        private Example DReader(SqlDataReader dr)
        {
            Example info = new Example();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
            info.Name = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
            info.MainGroup = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.Time = dr.IsDBNull(3) ? DateTime.Now : dr.GetDateTime(3);
            info.Url = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
            info.Pic = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
            info.Info = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
            info.Type = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);

            return info;
        }


        /// <summary>
        /// 查找所有
        /// </summary>
        /// <returns></returns>
        public IList<Example> GetAll()
        {
            IList<Example> info = new List<Example>();

            string sql = "SELECT * FROM [tb_example] order by [time] desc";
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Example GetExampleById(int id)
        {
            string sql = "SELECT * FROM tb_example WHERE id=@id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                Example example = new Example();

                if (dr.HasRows && dr.Read())
                {
                    example = DReader(dr);
                }
                return example;
            }

        }
        /// <summary>
        /// 根据项目名称查找，类型，负责组查找
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="mainGroup"></param>
        /// <returns></returns>
        public IList<Example> GetExampleByAll(string name,string type,string mainGroup)
        {

            string sql = "SELECT * FROM tb_example WHERE name LIKE @name  AND type LIKE @type AND mainGroup LIKE @mainGroup ";
            IList<Example> info = new List<Example>();

            SqlParameter[] parms = new SqlParameter[]
            {
                 new SqlParameter("@name","%" + name+ "%"),
                  new SqlParameter("@type","%" + type+ "%"),
                   new SqlParameter("@mainGroup","%" + mainGroup+ "%")
            };
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insret(Example info)
        {
            string sql = "INSERT INTO tb_example (name,mainGroup,time,url,pic,info,type) VALUES(@name,@mainGroup,@time,@url,@pic,@info,@type)";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name",info.Name),
                new SqlParameter("@mainGroup",info.MainGroup),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@url",info.Url),
                new SqlParameter("@pic",info.Pic),
                new SqlParameter ("@info",info.Info),
                new SqlParameter("@type",info.Type)
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
            string sql = "DELETE FROM tb_example where id=@id";

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
        public bool Update(Example info)
        {
            string sql = "UPDATE tb_example SET name=@name,mainGroup=@mainGroup,time=@time,url=@url,pic=@pic,info=@info,type=@type WHERE id=@id";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",info.Id),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@mainGroup",info.MainGroup),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@url",info.Url),
                new SqlParameter("@pic",info.Pic),
                new SqlParameter ("@info",info.Info),
                new SqlParameter("@type",info.Type)
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
