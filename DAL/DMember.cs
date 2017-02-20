using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class DMember
    {
        private string columns = "id,name,sex,joinYear,userPic,qq,password,tel,dept,duty,isFinish";

        private Member DReader(SqlDataReader dr)
        {
            Member info = new Member();

            info.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
            info.Name = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
            info.Sex = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
            info.JoinYear = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
            info.UserPic = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
            info.QQ = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
            info.Password = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
            info.Tel = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
            info.Dept = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
            info.Duty = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);
            info.IsFinish = dr.IsDBNull(10) ? 0 : dr.GetInt32(10);

            return info;
        }


        /// <summary>
        /// 查找所有
        /// </summary>
        /// <returns></returns>
        public IList<Member> GetAll()
        {
            IList<Member> info = new List<Member>();

            string sql = "SELECT * FROM tb_member";
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
        public Member GetMemberById(int id)
        {
            string sql = "SELECT * FROM tb_member WHERE id=@id";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                Member member = new Member();

                if (dr.HasRows && dr.Read())
                {
                    member = DReader(dr);
                }
                return member;
            }
        }
        /// <summary>
        /// 得到当年主管的信息
        /// </summary>
        /// <returns></returns>
        public Member GetMemberOfManagerNow()
        {
            string sql = "SELECT * FROM tb_member WHERE duty like '%主管%' order by joinYear desc";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql,null))
            {
                Member member = new Member();

                if (dr.HasRows && dr.Read())
                {
                    member = DReader(dr);
                }
                return member;
            }
        }
        /// <summary>
        /// 根据姓名查找
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IList<Member> GetMemberByName(string name)
        {
            string sql = "SELECT * FROM tb_member WHERE name LIKE @name";
            IList<Member> info = new List<Member>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@name", "%"+name+"%")))
            {
                
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }

        }
        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="duty"></param>
        /// <param name="name"></param>
        /// <param name="joinYear"></param>
        /// <returns></returns>
        public IList<Member> GetMemberByManyInfo(string dept,string duty, string name, int joinYear)
        {
            string sql = "SELECT * FROM tb_member WHERE name LIKE @name AND dept LIKE @dept And duty LIKE @duty ";

            SqlParameter[] parms;

            if (joinYear != 0)
            {
                sql += " AND joinYear=@joinYear";
                parms = new SqlParameter[]
                {
                    new SqlParameter("@name","%"+name+"%"),
                    new SqlParameter("@dept","%"+dept+"%"),
                    new SqlParameter("@duty","%"+duty+"%"),
                    new SqlParameter("@joinYear",joinYear)
                };
            }
            else
            {
                parms = new SqlParameter[]
                {
                    new SqlParameter("@name","%"+name+"%"),
                    new SqlParameter("@dept","%"+dept+"%"),
                    new SqlParameter("@duty","%"+duty+"%")
                };
            }
            IList<Member> info = new List<Member>();
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
        /// 
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public Member GetMemberByQQ(string qq)
        {
            string sql = "SELECT * FROM tb_member WHERE qq=@qq";

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@qq", qq)))
            {
                Member member = new Member();

                if (dr.HasRows && dr.Read())
                {
                    member = DReader(dr);
                }
                return member;
            }

        }
        /// <summary>
        /// 根据加入年份，姓名查找
        /// </summary>
        /// <param name="name"></param>
        /// <param name="joinYear"></param>
        /// <returns></returns>
        public  IList<Member> GetMemberByNameAndJoinYear(string name, int joinYear)
        {
            string sql = "SELECT * FROM tb_member WHERE name LIKE @name AND joinYear=@joinYear";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name","%"+name+"%"),
                new SqlParameter("@joinYear",joinYear)
            };

            IList<Member> info = new List<Member>();
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
        /// 能否登录
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CanLogin(string qq, string password)
        {
            string sql = "SELECT * FROM tb_member WHERE qq=@qq AND password=@password";
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@qq",qq),
                new SqlParameter("@password",password)
            };

            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, parms))
            {
                if (dr.HasRows && dr.Read())
                {
                    return true;
                }
                return false;
            }
        }



        /// <summary>
        /// 根据职位查找
        /// </summary>
        /// <param name="duty"></param>
        /// <returns></returns>
        public IList<Member> GetMemberByDuty(string duty)
        {
            string sql = "SELECT * FROM tb_member WHERE duty=@duty";

            IList<Member> info = new List<Member>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, new SqlParameter("@duty", duty)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read()) { info.Add(DReader(dr)); }
                }
                return info;
            }
        }
        /// <summary>
        /// 根据部门,职位查找
        /// </summary>
        /// <param name="dept"></param>
        /// <param name="duty"></param>
        /// <returns></returns>
        public IList<Member> GetMemberByDeptAndDuty(string dept, string duty)
        {
            string sql = "SELECT * FROM tb_member WHERE dept LIKE @dept AND duty LIKE @duty";

            IList<Member> info = new List<Member>();
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@dept", "%"+dept+"%"),
                new SqlParameter("@duty", "%"+duty+"%")
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
        /// 判断资料是否完整
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool IsFinish(Member info)
        {
            if (info.IsFinish == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(Member info)
        {
            string sql = "INSERT INTO [tb_member]([name], [sex], [joinYear], [userPic], [qq], [password], [tel], [dept], [duty], [isFinish]) VALUES (@name, @sex, @joinYear, @userPic, @qq, @password, @tel, @dept, @duty, @isFinish)";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@name",info.Name),
                new SqlParameter("@sex",info.Sex ),
                new SqlParameter ("@joinYear",info.JoinYear),
                new SqlParameter("@userPic",info.UserPic ),
                new SqlParameter("@qq",info.QQ),
                new SqlParameter ("@password",info.Password),
                new SqlParameter ("@tel",info.Tel), 
                new SqlParameter("@dept",info.Dept),
                new SqlParameter("@duty",info.Duty),
                new SqlParameter("@isFinish",info.IsFinish)
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
            string sql = "DELETE FROM tb_member where id=@id";

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
        public bool Update(Member info)
        {
            string sql = "UPDATE tb_member SET name=@name,sex=@sex,joinYear=@joinYear,userPic=@userPic,qq=@qq,password=@password,tel=@tel,dept=@dept,duty=@duty,isFinish=@isFinish WHERE id=@id";

            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@id",info.Id),
                new SqlParameter("@name",info.Name),
                new SqlParameter("@sex",info.Sex ),
                new SqlParameter ("@joinYear",info.JoinYear),
                new SqlParameter("@userPic",info.UserPic ),
                new SqlParameter("@qq",info.QQ),
                new SqlParameter ("@password",info.Password),
                new SqlParameter ("@tel",info.Tel),
                new SqlParameter("@dept",info.Dept),
                new SqlParameter("@duty",info.Duty),
                new SqlParameter("@isFinish",info.IsFinish)
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
