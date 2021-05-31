using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Scoala.Models.LoginDetails;
using System.Data;
using Scoala.Models.EntityLayer;

namespace Scoala.Models.DataAccess
{
    class SubjectsDAL
    {
        public ObservableCollection<Subject> GetAllSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject s = new Subject();

                    s.SubjectID = (int)(reader[0]);
                    s.Name = reader.GetString(1);

                    
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

        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idMaterie", subject.SubjectID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertSubject(string denumire)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Insertsubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramdenumire = new SqlParameter("@denumire", denumire);
                cmd.Parameters.Add(paramdenumire);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
