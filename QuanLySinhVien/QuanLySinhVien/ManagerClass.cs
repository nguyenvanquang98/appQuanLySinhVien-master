using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using QuanLySinhVien.DAO;
using System.Collections;
using System.Collections.Generic;
using QuanLySinhVien.Object;

namespace QuanLySinhVien
{
    public partial class ManagerClass : Form
    {
        private ManagerStudent student;
        public List<Classes> listClasseses;
        public List<Student> listStudent;
        public ManagerClass()
        {
            
            listClasseses = new List<Classes>();
            listStudent = new List<Student>();
            InitializeComponent();
        }

        SqlConnection con;
        private void ManagerClass_Load(object sender, EventArgs e)
        {
            //connectData();
            //hienthi();
              hienthiArrayList();

        }
        // ket noi database
        public void connectData()
        {
            string conString = ConfigurationManager.ConnectionStrings["QLySVien"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
        }

        // do du lieu len table    
        private void hienthi()
        {
            string sql = "select * from class";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            gvClass.DataSource = dt;
        }
        //--------------------------------------------------------hien thi bang arraylist-----------------------------------
        

        private void hienthiArrayList()
        {

            //List<Classes> listClasseses = new List<Classes>(); // them sau khi load du lieu tu list class
            DataTable dataTable = new DataTable();
            DataColumn dataColumn;
            dataColumn = new DataColumn("Mã LH");
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên LH");
            dataTable.Columns.Add(dataColumn);

            foreach (Classes list in listClasseses)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = list.CodeClass;
                dataRow[1] = list.NameClass;

                dataTable.Rows.Add(dataRow);
            }

            gvClass.DataSource = dataTable;
            

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
                //if (check_class(codeClass) != true)
                if(Check_class_arrayList(codeClass) !=true)
                {
                    // -------------------------------------------------mo doan nay ra la ket noi sql--------------------------------- 
                    //string sqlInsert = "insert into class values (@MaLH, @TenLH)";
                    //SqlCommand cmd = new SqlCommand(sqlInsert, con);
                    //cmd.Parameters.AddWithValue("MaLH", codeClass);
                    //cmd.Parameters.AddWithValue("TenLH", nameClass);
                    //cmd.ExecuteNonQuery();
                    //hienthi();
                    // --------------------------------------------------- doan nay la arraylisst ------------------------------------
                    List<Student> lsStudent = new  List<Student>();
                    listClasseses.Add(new Classes(codeClass,nameClass,lsStudent));
                    hienthiArrayList();
                }
                else
                {
                    MessageBox.Show("Lớp học đã tồn tại");
                }
            }

        }
        //luu bien tap thoi de lop kia truy van quan
        public class luuNameClass
        {
            static public string idClass;
        }
        public class TruyenStudent
        {
            static public List <Student> truyenList;
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

                // -------------------------------------------------mo doan nay ra la ket noi sql--------------------------------- 
                //if (check_class(codeClass)!=false)
                //{
                //  ManagerStudent student = new ManagerStudent();
                //student.Show();
                //Visible = false;
                //}
                //else
                //{
                //  MessageBox.Show("Lớp học đã tồn tại");
                //}
                // --------------------------------------------------- doan nay la arraylisst ------------------------------------
                if (Check_class_arrayList(codeClass) == true)
                {
                     ManagerStudent student = new ManagerStudent(this);
                     TruyenStudent.truyenList = findClass(codeClass);
                     student.Show();
                     this.Hide();
                    // Visible = false;
                }
                else
                {
                    MessageBox.Show("Lớp học không tồn tại");
                }

            }
        }
        public List<Student> findClass(string codeClass)
        {
            List<Student> listSudent1 = new List<Student>();
            foreach(Classes lsClasss in listClasseses)
            {
                if (lsClasss.CodeClass.Equals(codeClass))
                {
                    listSudent1 = lsClasss.listStudent;
                }
            }
            return listSudent1;
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
        // dong ket noi sql
        private void ManagerClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            //con.Close();
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
                //---------------------------------------------------------ket noi sql ---------------------------------------
                //if (check_class(codeClass) == true){
                //string sqlUpdate = "update class set TenLH = @TenLH where MaLH = @MaLH";
                //SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                //cmd.Parameters.AddWithValue("MaLH", codeClass);
                //cmd.Parameters.AddWithValue("TenLH", nameClass);
                //cmd.ExecuteNonQuery();
                //hienthi();
                //}else{
                //MessageBox.Show("Lớp học không tồn tại");
                //}
                // --------------------------------------------------- doan nay la arraylisst ------------------------------------
                foreach (Classes classes in listClasseses)
                {
                    if (classes.CodeClass.Equals(codeClass)) { 
                        classes.NameClass = nameClass;
                        hienthiArrayList();

                    }else {
                        MessageBox.Show("Lớp học không tồn tại");
                    }
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
                //---------------------------------------------------------ket noi sql ---------------------------------------
                // if (check_class(codeClass) == true)
                //{
                //string countSt = "SELECT COUNT(MaSV) FROM student WHERE MaLH = @MaLH";
                //string sqlDelete = "delete from class where MaLH = @MaLH";                 
                //SqlCommand cmdCountSt = new SqlCommand(countSt, con);
                //cmdCountSt.Parameters.AddWithValue("MaLH", codeClass);
                //countStudent = (int)cmdCountSt.ExecuteScalar();

                //if (countStudent>0)
                //{
                //string deletSudent = "delete from student where MaLH = @MaLH";
                //SqlCommand cmd2 = new SqlCommand(deletSudent, con);
                //cmd2.Parameters.AddWithValue("MaLH", codeClass);
                //cmd2.ExecuteNonQuery();

                //SqlCommand cmd3 = new SqlCommand(sqlDelete, con);
                //cmd3.Parameters.AddWithValue("MaLH", codeClass);
                //cmd3.ExecuteNonQuery();
                //}
                //else
                //{
                //  SqlCommand cmd3 = new SqlCommand(sqlDelete, con);
                //cmd3.Parameters.AddWithValue("MaLH", codeClass);
                //cmd3.ExecuteNonQuery();
                //}

                //hienthi();
                //}
                //else
                //{
                //MessageBox.Show("Lớp học không tồn tại");
                //}
                // --------------------------------------------------- doan nay la arraylisst ------------------------------------
                int count = 0;
                foreach (Classes classes in listClasseses)
                {
                    if (classes.CodeClass.Equals(codeClass) && classes.NameClass.Equals(nameClass))
                    {
                        this.listClasseses.Remove(classes);
                        hienthiArrayList();
                        count --;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count ==listClasseses.Count)
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

        private Boolean Check_class_arrayList(String codeClass)
        {
            foreach (Classes t in listClasseses)
            {
                if (t.CodeClass == codeClass)
                {
                    return true;
                }
                
            }
            return false;
            
        }
    }
}
