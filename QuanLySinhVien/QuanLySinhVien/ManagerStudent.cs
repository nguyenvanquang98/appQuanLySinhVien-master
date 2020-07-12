using QuanLySinhVien.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class ManagerStudent : Form
    {
        private SqlConnection con;
        private static SqlConnection con1;
        private DataTable dt;
        private SqlDataReader dr;
        private SqlCommand cmd;
        String mssv;
        String name;
        String classs;
        String address;

        public List<Student> listStudent;
        private ManagerClass nextFormClass =null;
        public ManagerStudent(ManagerClass managerClass)
        {
            nextFormClass = managerClass;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManagerStudent_Load(object sender, EventArgs e)
        {
            string maLH = ManagerClass.luuNameClass.idClass;
            txtClass.Text = maLH;

            //connectSQl();
            //hienthiSinhVien(maLH);
            hienthiSinhVienArrayList();

        }
        public void connectSQl()
        {
            string conString = ConfigurationManager.ConnectionStrings["QLySVien"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
        }
        public void hienthiSinhVien(string idClass)
        {

            string sql = "select * from student where MaLH = @MaLH";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("MaLH", idClass);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;


        }
        public void hienthiSinhVienArrayList()
        {
            DataTable dataTable = new DataTable();
            DataColumn dataColumn;
            dataColumn = new DataColumn("Mã SV");
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên SV");
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Mã Lớp");
            dataTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Địa chỉ");
            dataTable.Columns.Add(dataColumn);
            string maLH = ManagerClass.luuNameClass.idClass;

            //listStudent = classss.ListStudents;
             listStudent = ManagerClass.TruyenStudent.truyenList;

            foreach (Student list in listStudent)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = list.CodeStudent;
                dataRow[1] = list.NameStudent;
                dataRow[2] = maLH;
                dataRow[3] = list.Address;

                dataTable.Rows.Add(dataRow);
            }

            dataGridView1.DataSource = dataTable;

        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            nextFormClass.Show();
            //Visible = false;
            this.Hide();
        }
        private void addStudent()
        {
             mssv = txtMssv.Text.Trim();
             name = txtName.Text.Trim();
             classs = txtClass.Text.Trim();
             address = txtAddress.Text.Trim();
            string err1 = "";
            string err2 = "";
            string err3 = "";
            string err4 = "";

            if (mssv == "")
            {
                err1 = "Bạn điền thiếu mã sinh viên";
                MessageBox.Show(err1);
            } else if (name == "")
            {
                err2 = "Bạn điền thiếu thông tin tên sinh viên";
                MessageBox.Show(err2);
            } else if (address == "")
            {
                err3 = "Bạn vui lòng điền thông tin địa chỉ";
                MessageBox.Show(err3);
            } else {
                /*if(check_student(mssv, classs) == false)
                {
                    string sqlInsert = "insert into student values (@MaSV, @TenSV,@MaLH,@DiaChi) ";
                    SqlCommand cmd = new SqlCommand(sqlInsert, con);
                    cmd.Parameters.AddWithValue("MaSV", mssv);
                    cmd.Parameters.AddWithValue("TenSV", name);
                    cmd.Parameters.AddWithValue("MaLH", classs);
                    cmd.Parameters.AddWithValue("DiaChi", address);
                    cmd.ExecuteNonQuery();
                    //hienthiSinhVien(classs);
                }
                else
                {
                    MessageBox.Show("Sinh viên đã tồn tại trong database");
                }*/
                if (check_Student_ArrayList(mssv)!=true)
                {
                    listStudent.Add(new Student(mssv, name, address));
                    hienthiSinhVienArrayList();
                }
                else
                {
                    MessageBox.Show("Sinh viên đã tồn tại");
                }
                       

            }
        }
        public Boolean check_Student_ArrayList(string mssv)
        {

            listStudent = ManagerClass.TruyenStudent.truyenList;
            foreach (Student ls in listStudent)
            {
                if (ls.CodeStudent.Equals(mssv))
                {
                    return  true;
                }
            }

            return false;
        }



        // check trong sql
        private Boolean check_student(string massv,string maLH)
        {
            Boolean result;
            string sqlSelect = "select * from student where MaSV=@MaSV";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            cmd.Parameters.AddWithValue("MaSV", mssv);
            if (cmd.ExecuteScalar() != null)
            {
                result=  true; // ton tai tra ve true
            }
            else
            {
                result = false; // khong ton tai
            }

            return result;
        }
        private void edit_Student()
        {
            mssv = txtMssv.Text.Trim();
            name = txtName.Text.Trim();
            classs = txtClass.Text.Trim();
            address = txtAddress.Text.Trim();
            string err1 = "";
            string err2 = "";
            string err3 = "";
            string err4 = "";

            if (mssv == "")
            {
                err1 = "Bạn điền thiếu mã sinh viên";
                MessageBox.Show(err1);
            }
            else if (name == "")
            {
                err2 = "Bạn điền thiếu thông tin tên sinh viên";
                MessageBox.Show(err2);
            }
            else if (address == "")
            {
                err3 = "Bạn vui lòng điền thông tin địa chỉ";
                MessageBox.Show(err3);
            }
            else
            {
                /* if (check_student(mssv, classs) == true)
                 {
                     string sqlInsert = "update student set MaSV =@MaSV, TenSV=@TenSV, MaLH=@MaLH, DiaChi=@DiaChi where MaSV =@MaSV";
                     SqlCommand cmd = new SqlCommand(sqlInsert, con);
                     cmd.Parameters.AddWithValue("MaSV", mssv);
                     cmd.Parameters.AddWithValue("TenSV", name);
                     cmd.Parameters.AddWithValue("MaLH", classs);
                     cmd.Parameters.AddWithValue("DiaChi", address);
                     cmd.ExecuteNonQuery();
                    // hienthiSinhVien(classs);
                 }
                 else
                 {
                     MessageBox.Show("Sinh viên không tồn tại trong hệ thống");
                 }*/
                int count = 0;
                foreach (Student studentEdit in listStudent)
                {
                    if (studentEdit.CodeStudent.Equals(mssv))
                    {
                        studentEdit.NameStudent = name;
                        studentEdit.Address = address;
                        hienthiSinhVienArrayList();

                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == listStudent.Count)
                {
                    MessageBox.Show("Sinh viên không tồn tại");
                }

            }
        }
        private void del_Student()
        {
            mssv = txtMssv.Text.Trim();
            name = txtName.Text.Trim();
            classs = txtClass.Text.Trim();
            address = txtAddress.Text.Trim();
            string err1 = "";
            string err2 = "";
            string err3 = "";
            string err4 = "";

            if (mssv == "")
            {
                err1 = "Bạn điền thiếu mã sinh viên";
                MessageBox.Show(err1);
            }
            else
            {
                // -----------------------------------------------------------------su dung sql -----------------------------------
                // if (check_student(mssv, classs) == true)
                //{
                //  string sqlInsert = "delete from student where MaSV=@MaSV";
                // SqlCommand cmd = new SqlCommand(sqlInsert, con);
                //cmd.Parameters.AddWithValue("MaSV", mssv);
                //cmd.ExecuteNonQuery();
                // hienthiSinhVien(classs);
                //}
                //else
                //{
                //  MessageBox.Show("Sinh viên không tồn tại trong hệ thống");
                //}
                // -----------------------------------------------------------------su dung arraylist -----------------------------------
                Student studentDel = new Student(mssv, name, address);
                int count = 0;
                foreach(Student ls1 in listStudent)
                {
                    if (ls1.CodeStudent.Equals(mssv))
                    {
                        listStudent.Remove(ls1);
                        hienthiSinhVienArrayList();
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if(count == listStudent.Count)
                {
                    MessageBox.Show("Sinh viên không tồn tại trong hệ thống");
                }


            }
        }
        


        private void btnAdd_Click(object sender, EventArgs e)
        {
            addStudent();
        }

        private void ManagerStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            //con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit_Student();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            del_Student();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
