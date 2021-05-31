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
    class TeachersToSubjectsToClassDAL
    {
        public ObservableCollection<TeachersToClassesLST> GetTeachersToSubjectsToClass()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetTeachersToClass", con);
                ObservableCollection<TeachersToClassesLST> result = new ObservableCollection<TeachersToClassesLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeachersToClassesLST t = new TeachersToClassesLST();
                    t.TeacherToSubjectToClass.CuplajID = (int)(reader[0]);
                    t.TeacherToSubjectToClass.ClassID = (int)(reader[1]);
                    t.TeacherToSubject.TeacherID = (int)(reader[2]);
                    t.TeacherToSubject.SubjectID = (int)(reader[3]);
                    t.TeacherToSubject.CuplajID = (int)(reader[4]);
                    t.Subject.SubjectID = (int)(reader[5]);
                    t.Subject.Name = reader.GetString(6);
                    t.Teacher.TeacherID = (int)(reader[7]);
                    t.Teacher.Name = reader.GetString(8);
                    t.Teacher.Phone = reader.GetString(9);
                    t.Class.ClassID = (int)(reader[10]);
                    t.Class.ClassNumber = (int)(reader[11]);
                    t.Class.Letter = reader.GetString(12);
                    t.Class.Specialization = reader.GetString(13);
                    result.Add(t);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertTeacherSubjectToClass(TeacherToSubject teacherToSubject, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacherSubjectToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCuplaj = new SqlParameter("@idCuplaj", teacherToSubject.CuplajID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);
                cmd.Parameters.Add(paramIDCuplaj);
                cmd.Parameters.Add(paramIDClasa);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherSubjectToClass(TeacherToSubject teacherToSubject, Class cls)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherSubjectToClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDCuplaj = new SqlParameter("@idCuplaj", teacherToSubject.CuplajID);
                SqlParameter paramIDClasa = new SqlParameter("@idClasa", cls.ClassID);
                cmd.Parameters.Add(paramIDCuplaj);
                cmd.Parameters.Add(paramIDClasa);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
