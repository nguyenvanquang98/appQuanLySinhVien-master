using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using QuanLySinhVien.Service;
using System.Data;

namespace QuanLySinhVien
{
    public partial class ManagerClass : Form
    {
        private ManagerStudent student;
        public ManagerClass()
        {
            InitializeComponent();
        }

        SqlConnection con;
        private void ManagerClass_Load(object sender, EventArgs e)
        {
               string conString = ConfigurationManager.ConnectionStrings["QLySVien"].ConnectionString.ToString();
               con = new SqlConnection(conString);
               con.Open();
               hienthi();

        }
        // show len gir

        private void hienthi()
        {
            string sql = "select * from class";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            gvClass.DataSource = dt;
        }
        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNameClass_TextChanged(object sender, EventArgs e)
        {

        }

        private void addClass()
        {
            string codeClass = txtMaLop.Text.Trim();
            string nameClass = txtNameClass.Text.Trim();
            string err = "";
            string errTenLop = "";
            string errThongTin = "";

            if (codeClass == "")
            {
                err = "Bạn điền thiếu mã lớp";
                MessageBox.Show(err);

            }
            else if (nameClass == "")
            {
                errTenLop = "Bạn điền thiếu tên lớp";
                MessageBox.Show(errTenLop);
            }
            else if (codeClass == "" && nameClass == "")
            {
                errThongTin = "Bạn điền thiếu thông tin";
                MessageBox.Show(errThongTin);
            }
            else
            {
                if (check_class(codeClass) != true)
                {
                    string sqlInsert = "insert into class values (@MaLH, @TenLH)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, con);
                    cmd.Parameters.AddWithValue("MaLH", codeClass);
                    cmd.Parameters.AddWithValue("TenLH", nameClass);
                    cmd.ExecuteNonQuery();
                    hienthi();

                }
                else
                {
                    MessageBox.Show("Lớp học đã tồn tại");
                }
            }

        }
        //
        public class luuNameClass
        {
            static public string idClass;
        }

        private void check_search()
        {
            string codeClass = txtMaLop.Text.Trim();
            luuNameClass.idClass = codeClass;

            string nameClass = txtNameClass.Text.Trim();
            string err = "";
            string errThongTin = "";

            if (codeClass == "")
            {
                err = "Bạn điền thiếu mã lớp";
                MessageBox.Show(err);

            }
            
            else if (codeClass == "" && nameClass == "")
            {
                errThongTin = "Bạn điền thiếu thông tin";
                MessageBox.Show(errThongTin);
            }
            else
            {

                ManagerStudent student = new ManagerStudent();
                student.Show();
                Visible = false;
            }
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            check_search();

        }
        // button thoat
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }
      
        private void ManagerClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Close();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            addClass();
        }
        private void editClass()
        {
            string codeClass = txtMaLop.Text.Trim();
            string nameClass = txtNameClass.Text.Trim();
            string err = "";
            string errTenLop = "";
            string errThongTin = "";

            if (codeClass == "")
            {
                err = "Bạn điền thiếu mã lớp";
                MessageBox.Show(err);

            }
            else if (nameClass == "")
            {
                errTenLop = "Bạn điền thiếu tên lớp";
                MessageBox.Show(errTenLop);
            }
            else if (codeClass == "" && nameClass == "")
            {
                errThongTin = "Bạn điền thiếu thông tin";
                MessageBox.Show(errThongTin);
            }
            else
            {
                if (check_class(codeClass) == true)
                {
                    string sqlUpdate = "update class set TenLH = @TenLH where MaLH = @MaLH";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("MaLH", codeClass);
                    cmd.Parameters.AddWithValue("TenLH", nameClass);
                    cmd.ExecuteNonQuery();
                    hienthi();
                }
                else
                {
                    MessageBox.Show("Lớp học không tòn tại");
                }
            }
        }
        private void btnEditClass_Click(object sender, EventArgs e)
        {
            editClass();
        }
        private void btnDelClass_Click(object sender, EventArgs e)
        {
            string codeClass = txtMaLop.Text.Trim();
            string nameClass = txtNameClass.Text.Trim();
            string err = "";
            string errTenLop = "";
            string errThongTin = "";

            int countStudent = 0;

            if (codeClass == "")
            {
                err = "Bạn điền thiếu mã lớp";
                MessageBox.Show(err);

            }
            else
            {
                if (check_class(codeClass) == true)
                {
                    string countSt = "SELECT COUNT(MaSV) FROM student WHERE MaLH = @MaLH";
                    string sqlDelete = "delete from class where MaLH = @MaLH";                 
                    SqlCommand cmdCountSt = new SqlCommand(countSt, con);
                    cmdCountSt.Parameters.AddWithValue("MaLH", codeClass);
                    countStudent = (int)cmdCountSt.ExecuteScalar();

                    if (countStudent>0)
                    {
                        string deletSudent = "delete from student where MaLH = @MaLH";
                        SqlCommand cmd2 = new SqlCommand(deletSudent, con);
                        cmd2.Parameters.AddWithValue("MaLH", codeClass);
                        cmd2.ExecuteNonQuery();

                        SqlCommand cmd3 = new SqlCommand(sqlDelete, con);
                        cmd3.Parameters.AddWithValue("MaLH", codeClass);
                        cmd3.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand(sqlDelete, con);
                        cmd3.Parameters.AddWithValue("MaLH", codeClass);
                        cmd3.ExecuteNonQuery();
                    }

                    hienthi();
                }
                else
                {
                    MessageBox.Show("Lớp học không tồn tại");
                }
            }
        }

        
        private Boolean check_class( string maLH)
        {
            Boolean result;
            string sqlSelect = "select * from class where MaLH=@MaLH";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.Parameters.AddWithValue("MaLH", maLH);
            if (cmd.ExecuteScalar() != null)
            {
                result = true; // ton tai tra ve true
            }
            else
            {
                result = false; // khong ton tai
            }

            return result;
        }
    }
}
