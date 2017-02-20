using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class DArticle
    {
        private string columns = "id,title,name,info,time,type,isImportant";
        private Article DRead(SqlDataReader dr)
        {
            Article info = new Article();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
            info.Title = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
            info.Name = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.Info = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
            info.Time = dr.IsDBNull(4) ? DateTime.Now : dr.GetDateTime(4);
            info.Type = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
            info.IsImportant = dr.IsDBNull(6) ? 0 : dr.GetInt32(6);
            info.ReadedTotal = dr.IsDBNull(7) ? 0 : dr.GetInt32(7);
            info.QQ = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);

            return info;
        }
        /// <summary>
        /// 查询所有文章
        /// </summary>
        /// <returns></returns>
        public IList<Article> GetAll()
        {
            IList<Article> info = new List<Article>();

            string sql = "SELECT * FROM [tb_article] ";
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
        /// 查找前7篇文章
        /// </summary>
        /// <returns></returns>
        public IList<Article> GetFirstSeven()
        {
            IList<Article> info = new List<Article>();

            string sql = "SELECT top 7 * FROM [tb_article] order by time desc";
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
        public IList<Article> GetTitle(string title)
        {
            IList<Article> info = new List<Article>();

            string sql = "select * from [tb_article] where [title] like @title";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@title", "%" + title + "%")))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 通过QQ号获取文章
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public IList<Article> GetByQQ(string qq)
        {
            IList<Article> info = new List<Article>();

            string sql = "select * from [tb_article] where [qq] = @qq order by time desc ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@qq", qq)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 根据标题和是否标记重点查找
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isImportant"></param>
        /// <returns></returns>
        public IList<Article> GetArticleByTitleAndIsImportant(string title, int isImportant)
        {
            string sql = "SELECT * FROM tb_article WHERE title LIKE @title AND isImportant=@isImportant";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title","%"+title+"%"),
                new SqlParameter("@isImportant",isImportant)
            };

            IList<Article> info = new List<Article>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 获取阅读量前8的文章
        /// </summary>
        /// <returns></returns>
        public IList<Article> GetByTotalReadTop8()
        {
            IList<Article> info = new List<Article>();

            string sql = "SELECT top 8 * FROM [tb_article] order by readedTotal desc";
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
        /// 按标题和所属组查找
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<Article> GetArticleByTitleAndType(string title, string type)
        {
            string sql = "SELECT * FROM tb_article WHERE title LIKE @title AND type=@type";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title","%"+title+"%"),
                new SqlParameter("@type",type)
            };

            IList<Article> info = new List<Article>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;

            }
        }
        /// <summary>
        /// 根据标题、类型、作者模糊查找
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList<Article> GetArticleByTitleOrTypeOrName(string title, string type, string name)
        {
            string sql = "SELECT * FROM tb_article WHERE title LIKE @title or type like @type or name like @name ";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title","%"+title+"%"),
                new SqlParameter("@type","%"+type+"%"),
                new SqlParameter("@name","%"+name+"%")
            };

            IList<Article> info = new List<Article>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DRead(dr)); }
                }
                return info;

            }
        }
        /// <summary>
        /// 按标题，所属组和是否标记重点查询
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="isImportant"></param>
        /// <returns></returns>
        public IList<Article> GetArticleByTitleAndTypeAndIsImportant(string title, string type, int isImportant)
        {
            string sql = "SELECT * FROM tb_article WHERE title like @title AND type like @type AND isImportant=@isImportant order by time desc";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title","%"+title+"%"),
                new SqlParameter("@type","%"+type+"%"),
                new SqlParameter("@isImportant",isImportant)
            };

            IList<Article> info = new List<Article>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
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
        public Article GetArticleById(int id)
        {
            string sql = "SELECT * FROM [tb_article] where id=@id ";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter ("@id",id)))
            {
                Article article = new Article();
                if (dr.HasRows && dr.Read())
                {
                    article = DRead(dr);
                }
                return article;
            }
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(Article info)
        {
            string sql = "INSERT INTO [tb_article] ( [title], [name], [info], [time], [type], [isImportant],[readedTotal],[qq]) VALUES ( @title, @name, @info, @time, @type, @isImportant,0,@qq)";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title",info.Title),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@type",info.Type),
                new SqlParameter("@isImportant",info.IsImportant),
                new SqlParameter("@qq",info.QQ)
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
            string sql = "delete from tb_article where id=@id ";

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
        public bool Update(Article info)
        {
            string sql = "UPDATE [tb_article] SET [title] = @title, [info] = @info, [time] = @time ,[type] = @type, [isImportant]=@isImportant WHERE [id] = @id";

            sql = String.Format(sql  /*补充内容*/);

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@title",info.Title),
                new SqlParameter("@info",info.Info),
                new SqlParameter("@time",info.Time),
                new SqlParameter("@type",info.Type),
                new SqlParameter("@isImportant",info.IsImportant),
                new SqlParameter("@id",info.Id)
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
        /// 阅读量加1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AddReadedMount(int id)
        {
            string sql = "UPDATE [tb_article] SET readedTotal=readedTotal+1 WHERE [id] = @id";

            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)) > 0)
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
