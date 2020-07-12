using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Object
{
    class user
    {
        private string name;
        private string password;

        public user(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public string getName { set => value = name; get=> name; }
        public string getPass { set => value = password; get => password; }
    }
}
