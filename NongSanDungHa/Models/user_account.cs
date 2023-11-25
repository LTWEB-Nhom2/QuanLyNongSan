namespace NongSanDungHa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    public partial class user_account 
    {
        public user_account() { }

        [Key]
        public int user_account_id { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]
        public string user_username { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]

        public string user_password { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]

        public string user_gender { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]
        [EmailAddress(ErrorMessage = "Không đúng định dạng Email")]

        public string user_email { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]

        public string user_phonenumber { get; set; }
       

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]


        public string user_address { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]

        public string user_firstname { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Không được để trống thông tin này")]

        public string user_lastname { get; set; }

        [StringLength(50)]
        public string user_member_tier { get; set; }

        public int? user_point { get; set; }

     
    }
    class ListUserAccount : DBConnection
    {
        DBConnection db;
        public ListUserAccount()
        {
            db = new DBConnection();

        }
        public List<user_account> getData()
        {
            string sql;

            sql = "Select * from user_account";


            List<user_account> list = new List<user_account>();
            SqlConnection con = GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                user_account item = new user_account();
                item.user_account_id = int.Parse(dr["user_account_id"].ToString());
                item.user_username = dr["user_username"].ToString();
                item.user_password = dr["user_password"].ToString();
                item.user_gender = dr["user_gender"].ToString();
                item.user_email = dr["user_email"].ToString();
                item.user_phonenumber = dr["user_phonenumber"].ToString();
                item.user_address = dr["user_address"].ToString();
                item.user_firstname = dr["user_firstname"].ToString();
                item.user_lastname = dr["user_lastname"].ToString();
                item.user_member_tier = dr["user_member_tier"].ToString();
                item.user_point = int.Parse(dr["user_point"].ToString());
                list.Add(item);
            }
            con.Close();
            return list;

        }

        public int CreateUserAccount(user_account a)
        {
            int kt;
            Cmd.CommandText = "select count(*) from user_account where user_username = @user_username";
            Cmd.Parameters.Clear();
            Cmd.Parameters.AddWithValue("@user_username", a.user_username);
            kt = (int)Cmd.ExecuteScalar();
            if (kt < 1)
            {
                Cmd.CommandText = "INSERT INTO user_account (user_username, user_password, user_gender, user_email, user_phonenumber,user_address, user_firstname, user_lastname) VALUES (@user_username, @user_password, @user_gender, @user_email, @user_phonenumber,@user_address, @user_firstname, @user_lastname)";
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("@user_username", a.user_username);
                Cmd.Parameters.AddWithValue("@user_password", a.user_password);
                Cmd.Parameters.AddWithValue("@user_gender", a.user_gender);
                Cmd.Parameters.AddWithValue("@user_email", a.user_email);
                Cmd.Parameters.AddWithValue("@user_phonenumber", a.user_phonenumber);
                Cmd.Parameters.AddWithValue("@user_address", a.user_address);
                Cmd.Parameters.AddWithValue("@user_firstname", a.user_firstname);
                Cmd.Parameters.AddWithValue("@user_lastname", a.user_lastname);
                kt = Cmd.ExecuteNonQuery();
                return kt;
            }
            else
                return -1;
        }

    }
}
