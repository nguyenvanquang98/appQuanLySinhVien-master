using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Object
{
    public class Student
    {
        private string _codeStudent, _nameStudent, _address;
        private List<Student> _listStudents = new List<Student>();

        public Student(string codeStudent, string nameStudent, string address)
        {
            _codeStudent = codeStudent;
            _nameStudent = nameStudent;
            _address = address;
           
        }

        public string CodeStudent
        {
            get => _codeStudent;
            set => _codeStudent = value;
        }

        public string NameStudent
        {
            get => _nameStudent;
            set => _nameStudent = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public List<Student> ListStudents
        {
            get => _listStudents;
            set => _listStudents = value;
        }

    }
}
