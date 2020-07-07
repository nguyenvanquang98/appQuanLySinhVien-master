using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAO
{
    public class Classes
    {
        private string _nameClass, _codeClass;
        private ListStudents _listStudents;

        public Classes(string codeClass, string nameClass, ListStudents listsStudents)
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

        public ListStudents ListStudents
        {
            get => _listStudents;
            set => _listStudents = value;
        }

        public string CodeClass
        {
            get => _codeClass;
            set => _codeClass = value;
        }

        public void ShowInfoClass()
        {
            Console.WriteLine("\t \t \t =>              Code Class: " + _codeClass + ", Name Class: " + _nameClass + ", \n \t \t \t                 List Student: " + _listStudents.ShowListStudent());
        }

    }

    public class ListClass
    {
        List<Classes> listClasseses;

        public ListClass()
        {
            listClasseses = new List<Classes>();
        }

        public void AddClasses(Classes c)
        {
            listClasseses.Add(c);
        }

        public void RenameClasses(string codeClass2, string nameClass2)
        {

            foreach (Classes classes in listClasseses)
            {
                if (classes.CodeClass.Equals(codeClass2))
                {
                    classes.NameClass = nameClass2;
                }
            }
        }

        public void DeleteClasses(string codeClass2)
        {

            foreach (Classes classes in listClasseses.ToList())
            {
                if (classes.CodeClass.Equals(codeClass2))
                {
                    listClasseses.Remove(classes);
                    classes.ListStudents.DeleteAllStudent();
                }
            }
        }

        public void FindClassById(string codeClass)
        {
            foreach (Classes t in listClasseses)
            {
                if (t.CodeClass == codeClass)
                {
                    t.ShowInfoClass();

                }
            }
        }
        public void AddStudentIntoClass(Student student)
        {
            foreach (Classes classes in listClasseses)
            {
                if (classes.CodeClass.Equals(student.CodeClass))
                {
                    classes.ListStudents.AddStudents(student);
                }
            }
        }

        public void ChangeNameStudentInClass(string codeClass, string codeStudent, string nameStudent)
        {
            foreach (Classes classes in listClasseses)
            {
                if (classes.CodeClass == codeClass)
                {
                    if (classes.ListStudents.CheckCodeStudentExist(codeStudent))
                    {
                        classes.ListStudents.ChangeNameStudent(codeStudent, nameStudent);
                    }
                }
            }
        }
        public void DeleteNameStudentInClass(string codeClass, string codeStudent)
        {
            foreach (Classes classes in listClasseses)
            {
                if (classes.CodeClass.Equals(codeClass))
                {
                    if (classes.ListStudents.CheckCodeStudentExist(codeStudent))
                    {
                        classes.ListStudents.DeleteStudent(codeStudent);
                    }
                }
            }
        }

    }



    public class Student
    {
        private string _codeStudent, _nameStudent, _codeClass;
        private List<Student> _listStudents = new List<Student>();

        public Student(string codeStudent, string nameStudent, string codeClass)
        {
            _codeStudent = codeStudent;
            _nameStudent = nameStudent;
            _codeClass = codeClass;
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

        public string CodeClass
        {
            get => _codeClass;
            set => _codeClass = value;
        }

        public List<Student> ListStudents
        {
            get => _listStudents;
            set => _listStudents = value;
        }

        public string ShowInfoStudent()
        {
            return "[CodeStudent: " + _codeStudent + ", Name Student: " + _nameStudent + ", Class : " + _codeClass + "]";
        }
    }

    public class ListStudents
    {
        readonly List<Student> _listStudents;

        public ListStudents()
        {
            _listStudents = new List<Student>();
        }

        public void AddStudents(Student student)
        {
            _listStudents.Add(student);
        }

        public void ChangeNameStudent(string codeStudent, string nameStudent)
        {
            foreach (Student st in _listStudents)
            {
                if (st.CodeStudent.Equals(codeStudent))
                {
                    st.NameStudent = nameStudent;
                }
            }
        }

        public void DeleteStudent(string codeStudent)
        {
            foreach (Student st in _listStudents)
            {
                if (st.CodeStudent.Equals(codeStudent))
                {
                    _listStudents.Remove(st);
                }
            }
        }

        public void DeleteAllStudent()
        {
            _listStudents.Clear();
        }

        public string ShowListStudent()
        {
            string rs = "";
            foreach (Student t in _listStudents)
            {
                rs += t.ShowInfoStudent() + "\n \t \t \t                 ";
            }

            return rs;
        }

        public bool CheckCodeStudentExist(string codeStudent)
        {
            foreach (Student t in _listStudents)
            {
                if (t.CodeStudent.Equals(codeStudent))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
