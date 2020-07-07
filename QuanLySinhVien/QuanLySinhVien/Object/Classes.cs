using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Object
{
    public class Classes
    {
        private string _nameClass, _codeClass;
        private List<Student> _listStudents = new List<Student>();

        public Classes()
        {

        }
        public Classes(string codeClass, string nameClass, List<Student> listsStudents)
        {
            _nameClass = nameClass;
            _codeClass = codeClass;
            _listStudents = listsStudents;
        }

        public string NameClass
        {
            get => _nameClass;
            set => _nameClass = value;
        }

        public string CodeClass
        {
            get => _codeClass;
            set => _codeClass = value;
        }
        public List<Student> listStudent
        {
            get => _listStudents;
            set => _listStudents = value;
        }

    }
}

