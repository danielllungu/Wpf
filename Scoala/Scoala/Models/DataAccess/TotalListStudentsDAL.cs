using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Scoala.Models.Lists;
using System.Data;

namespace Scoala.Models.DataAccess
{
    class TotalListStudentsDAL
    {
        public ObservableCollection<StudentsList> GetAllStudentsList()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetTotalListStudents", con);
                ObservableCollection<StudentsList> result = new ObservableCollection<StudentsList>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentsList s = new StudentsList();
                    s.StudentNume =reader.GetString(0);
                    s.Specializare = reader.GetString(1);
                    s.Numar_clasa = (int)(reader[2]);
                    s.Litera = reader.GetString(3);
                    result.Add(s);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
