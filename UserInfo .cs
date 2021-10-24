﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class UserInfo
    {
       
        private UserInfo() { }

        private static UserInfo _instance = new UserInfo();

        public static UserInfo Instance
        {
            get
            {
                return _instance;
            }
        }

        string cns = AppConfigurtaionServices.Configuration.GetConnectionString("cns");
        public string UserCheck(string UserName)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select password from userinfo where username=@username;";
                return cn.ExecuteScalar<string>(sql,new {username=UserName});
            }

        }
        public Model.UserInfo GetModel(string UserName)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select * from userinfo where username=@username";
                return cn.QueryFirstOrDefault<Model.UserInfo>(sql, new { UserName = UserName });
            }
        }
        public IEnumerable<Model.UserInfo> GetAll()
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {

                string sql = "select *from userinfo";
                return cn.Query<Model.UserInfo>(sql);
            }
        }
        public int GetCount()
        {
            using (IDbConnection cn=new MySqlConnection(cns))
            {


                string sql = "select count(1) from userinfo";
                return cn.ExecuteScalar<int>(sql);

            }
        }
        public IEnumerable<Model.UserInfo> GetPage(Model.Page page)
        {
            using(IDbConnection cn=new MySqlConnection(cns))
            {

                string sql = "with a as(select roe_number() over(order by username) as num,userinfo.*from userinfo)";
                sql += "select * from a where num between (@pageIndex-1)*@pageSize+1 and @pageIndex*@pageSize;";
                return cn.Query<Model.UserInfo>(sql, page);
            }

        }
        public int Add(Model.UserInfo user)
        {
            using(IDbConnection cn=new MySqlConnection(cns))
            {

                string sql = "insert into userinfo values(@username,@passWord，@qq，@email，@type，@userimg);";
                return cn.Execute(sql, user);

            }
           
        }
        public int Update(Model.UserInfo user)
        {
            using(IDbConnection cn = new MySqlConnection(cns))
            {

                string sql = "update userinfo set password=@password,qq=@qq,email=@email,type=@type,userimg=@userImg where username=@userName";
                return cn.Execute(sql, user);
            }


        }
        public int Delete(string username)
        {
            using(IDbConnection cn=new MySqlConnection(cns))
            {

                string sql = "delete from userinfo where username@userName";
                return cn.Execute(sql, new { username = username });

            }
        }

    }

}
