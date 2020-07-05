using QuanLySinhVien.data;
using QuanLySinhVien.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service
{
    class LopDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        public LopDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllClass()
        {
            // tao cau lenh SQL
            string sql = "Select * from class";
            // khoi tao ket noi
            SqlConnection con = dc.getConnection();
            // Khoi tao doi tuong lop SqlDataAdapter
            con.Open();
            // do du lieu tu SqlDataAdapter -> datatable

            DataTable dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
 
            //da.Fill(dt);
            // dong ket noi
            con.Close();
            return dt;

        }

        public bool insertClass(Lop lop)
        {
            string sql = "INSERT INTO dbo.Lop VALUES(@MaLop, @TenLop)";
            SqlConnection con = dc.getConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar).Value = lop.MaLop;
                cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = lop.TenLop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateClass(Lop lop)
        {
            string sql = "Update dbo.Lop set TenLop = @TenLop where MaLop = @MaLop";
            SqlConnection con = dc.getConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar).Value = lop.MaLop;
                cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = lop.TenLop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteClass(Lop lop)
        {
            string sql = "delete Lop where MaLop = @MaLop";
            SqlConnection con = dc.getConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar).Value = lop.MaLop;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}
