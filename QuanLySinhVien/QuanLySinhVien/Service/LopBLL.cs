using QuanLySinhVien.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service
{
    class LopBLL
    {
        LopDAL lopDAL;
        public LopBLL()
        {
            lopDAL = new LopDAL();
        }

        public DataTable getAllClass()
        {
           return lopDAL.getAllClass();
        }
        public bool insertClass(Lop lop)
        {
            return lopDAL.insertClass(lop);
        }
        public bool updateClass(Lop lop)
        {
            return lopDAL.updateClass(lop);
        }

        public bool deleteClass(Lop lop)
        {
            return lopDAL.deleteClass(lop);
        }
    }
}
