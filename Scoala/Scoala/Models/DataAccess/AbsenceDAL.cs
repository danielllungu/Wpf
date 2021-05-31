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
    class AbsenceDAL
    {
        public ObservableCollection<AbsenceStudentLST> GetAllAbsenceStudentListed()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAbsencesStudent", con);
                ObservableCollection<AbsenceStudentLST> result = new ObservableCollection<AbsenceStudentLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    

                    AbsenceStudentLST a = new AbsenceStudentLST();
                    a.AbsenceStudent = new AbsenceStudent();
                    a.Student = new Student();
                    a.TeacherToSubject = new TeacherToSubject();

                    a.AbsenceStudent.AbsenceID = (int)(reader[0]);
                    a.AbsenceStudent.TipAbsenta = reader.GetString(1);
                    a.AbsenceStudent.Data = reader.GetString(2);
                    a.AbsenceStudent.CuplajID = (int)(reader[3]);
                    a.AbsenceStudent.StudentID = (int)(reader[4]);
                    a.Student.StudentID = (int)(reader[5]);
                    a.Student.Name = reader.GetString(6);
                    a.TeacherToSubject.TeacherID = (int)(reader[7]);
                    a.TeacherToSubject.SubjectID = (int)(reader[8]);
                    a.TeacherToSubject.CuplajID = (int)(reader[9]);

                    result.Add(a);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }


        public void InsertAbsence(Student student, TeacherToSubject teacherToSubject, string tip_absenta, string data)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudent = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramCuplaj = new SqlParameter("@idCuplaj", teacherToSubject.CuplajID);
                SqlParameter paramTip = new SqlParameter("@tipAbsenta", tip_absenta);
                SqlParameter paramData = new SqlParameter("@data", data);

                cmd.Parameters.Add(paramStudent);
                cmd.Parameters.Add(paramCuplaj);
                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramData);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAbsence(AbsenceStudent absenceStudent)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idabsenta", absenceStudent.AbsenceID);
                

                cmd.Parameters.Add(paramID);
       
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
