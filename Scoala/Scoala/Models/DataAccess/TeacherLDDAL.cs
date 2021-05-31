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
    class TeacherLDDAL
    {
        public ObservableCollection<TeacherLD> GetTeachersLoginDetails()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("TeacherLoginDetails", con);
                ObservableCollection<TeacherLD> result = new ObservableCollection<TeacherLD>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherLD t = new TeacherLD();
                    t.TeacherID = (int)(reader[0]);
                    t.Email = reader.GetString(1);
                    t.Password = reader.GetString(2);
                    //p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
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

        public void AddTeacher(string name, string phone)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@name", name);
                SqlParameter paramPhone = new SqlParameter("@phone", phone);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramPhone);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddTeacherLD(Teacher t, string email, string password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacherLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", t.TeacherID);
                SqlParameter paramEmail = new SqlParameter("@email", email);
                SqlParameter paramPass = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramPass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher t = new Teacher();
                    t.TeacherID= (int)(reader[0]);
                    t.Name= reader.GetString(1);
                    t.Phone= reader.GetString(2);
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

        public void DeleteTeacherFromTeachers(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherFromTeachers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherFromSubjects(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherFromSubjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherFromMasters(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherFromMasters", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherFromLogin(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherFromLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherFromClasses(Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherFromClasses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                cmd.Parameters.Add(paramID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTeacher(Teacher teacher, string name, string phone)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idProfesor", teacher.TeacherID);
                SqlParameter paramName = new SqlParameter("@nume", name);
                SqlParameter paramPhone = new SqlParameter("@telefon", phone);
                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramPhone);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertTeacherToSubject(Teacher teacher, Subject subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertTeacherToSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDt = new SqlParameter("@idProfesor", teacher.TeacherID);
                SqlParameter paramIDs = new SqlParameter("@idMaterie", subject.SubjectID);
                
                cmd.Parameters.Add(paramIDt);
                cmd.Parameters.Add(paramIDs);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTeacherToSubject(TeacherToSubject teacherToSubject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacherToSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idCuplaj", teacherToSubject.CuplajID);
        
                cmd.Parameters.Add(paramID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<TeacherToSubject> GetTeacherToSubject()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeacherToSubject", con);
                ObservableCollection<TeacherToSubject> result = new ObservableCollection<TeacherToSubject>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherToSubject t = new TeacherToSubject();
                    t.TeacherID = (int)(reader[0]);
                    t.SubjectID = (int)(reader[1]);
                    t.CuplajID = (int)(reader[2]);
                    
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

        public ObservableCollection<TeacherToSubjectLST> GetAllTeacherToSubject()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetALLTeachersToSubjects", con);
                ObservableCollection<TeacherToSubjectLST> result = new ObservableCollection<TeacherToSubjectLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TeacherToSubjectLST t = new TeacherToSubjectLST();

                    t.TeacherToSubject.TeacherID = (int)(reader[0]);
                    t.TeacherToSubject.SubjectID = (int)(reader[1]);
                    t.TeacherToSubject.CuplajID = (int)(reader[2]);
                    t.Teacher.TeacherID = (int)(reader[3]);
                    t.Teacher.Name = reader.GetString(4);
                    t.Teacher.Phone = reader.GetString(5);
                    t.Subject.SubjectID = (int)(reader[6]);
                    t.Subject.Name = reader.GetString(7);

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

    }
}
