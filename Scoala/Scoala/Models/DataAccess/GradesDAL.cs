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
    class GradesDAL
    {
        public ObservableCollection<StudentsToGradesLST> GetAllStudentsToGrades()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsToGrades", con);
                ObservableCollection<StudentsToGradesLST> result = new ObservableCollection<StudentsToGradesLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentsToGradesLST s = new StudentsToGradesLST();
                    s.StudentToGrade.StudentID = (int)(reader[0]);
                    s.StudentToGrade.CuplajID = (int)(reader[1]);
                    s.StudentToGrade.Date = reader.GetDateTime(2).ToString();
                    s.StudentToGrade.GradeID = (int)(reader[3]);
                    s.StudentToGrade.Semester = (int)(reader[4]);
                    s.Student.StudentID = (int)(reader[5]);
                    s.Student.Name = reader.GetString(6);
                    s.Grade.GradeID = (int)(reader[7]);
                    s.Grade.Description = reader.GetString(8);
                    s.Grade.GradeValue = (int)(reader[9]);

                    
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

        public void InsertGrade(int? nota, string tip_nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertNota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramd = new SqlParameter("@descriere", tip_nota);
                SqlParameter paramn = new SqlParameter("@nota", nota);

                cmd.Parameters.Add(paramd);
                cmd.Parameters.Add(paramn);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Grade> GetGrades()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetGrades", con);
                ObservableCollection<Grade> result = new ObservableCollection<Grade>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Grade g = new Grade();
                    g.GradeID = (int)(reader[0]);
                    g.Description = reader.GetString(1);
                    g.GradeValue = (int)(reader[2]);

                    result.Add(g);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertGradeToStudent(Student student, TeacherToSubject tts, string data, Grade grade, int semestru)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertStudentGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudent = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramCuplaj = new SqlParameter("@idCuplaj", tts.CuplajID);
                SqlParameter paramdata = new SqlParameter("@data", data);
                SqlParameter paramNota = new SqlParameter("@idNota", grade.GradeID);
                SqlParameter paramSemestru = new SqlParameter("@semestru", semestru);

                cmd.Parameters.Add(paramStudent);
                cmd.Parameters.Add(paramCuplaj);
                cmd.Parameters.Add(paramdata);
                cmd.Parameters.Add(paramNota);
                cmd.Parameters.Add(paramSemestru);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<GradeStudentLST> GetAllGradeStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllGradeStudentsListed", con);
                ObservableCollection<GradeStudentLST> result = new ObservableCollection<GradeStudentLST>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GradeStudentLST g = new GradeStudentLST();
                    g.GradeStudent = new GradeStudent();
                    g.Student = new Student();
                    g.TeacherToSubject = new TeacherToSubject();

                    g.GradeStudent.GradeID = (int)(reader[0]);
                    g.GradeStudent.Grade = (int)(reader[1]);
                    g.GradeStudent.StudentID = (int)(reader[2]);
                    g.GradeStudent.CuplajID = (int)(reader[3]);
                    g.GradeStudent.TipNota = reader.GetString(4);
                    g.GradeStudent.Semsestru = (int)(reader[5]);
                    g.GradeStudent.Data = reader.GetString(6);
                    g.Student.StudentID = (int)(reader[7]);
                    g.Student.Name = reader.GetString(8);
                    g.TeacherToSubject.TeacherID = (int)(reader[9]);
                    g.TeacherToSubject.SubjectID = (int)(reader[10]);
                    g.TeacherToSubject.CuplajID = (int)(reader[11]);


                    result.Add(g);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertGradeStudent(Student student, Subject subject, TeacherToSubject teacherToSubject, string tip_nota, int nota, int semestru, string data)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertIntoGradeStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStudent = new SqlParameter("@idElev", student.StudentID);
                SqlParameter paramNota = new SqlParameter("@nota", nota);
                SqlParameter paramCuplaj = new SqlParameter("@idCuplaj", teacherToSubject.CuplajID);
                SqlParameter paramTip= new SqlParameter("@tipNota", tip_nota);
                SqlParameter paramSem = new SqlParameter("@semestru", semestru);
                SqlParameter paramData = new SqlParameter("@data", data);

                cmd.Parameters.Add(paramStudent);
                cmd.Parameters.Add(paramNota);
                cmd.Parameters.Add(paramCuplaj);
                cmd.Parameters.Add(paramTip);
                cmd.Parameters.Add(paramSem);
                cmd.Parameters.Add(paramData);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGradeStudent(GradeStudent grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteGradeStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@idNota", grade.GradeID);
                
                cmd.Parameters.Add(paramID);
   
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
