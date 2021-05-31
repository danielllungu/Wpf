using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Scoala.Models.LoginDetails;
using System.Data;
using Scoala.Models.DataAccess;
using Scoala.Models.EntityLayer;

namespace Scoala.Models.BussinessLogic
{
    class Logins
    {
        private ObservableCollection<AdminLD> admins = new ObservableCollection<AdminLD>();
        private ObservableCollection<StudentLD> students = new ObservableCollection<StudentLD>();
        private ObservableCollection<TeacherLD> teachers = new ObservableCollection<TeacherLD>();
        private string email;
        private string pass;
        public Logins(string login_email, string login_password)
        {
            this.email = login_email;
            this.pass = login_password;
        }
        public bool IsAdmin()
        {
            AdminLDDAL adminLDDAL = new AdminLDDAL();
            admins = adminLDDAL.GetAdminsLoginDetails();
            for (int index = 0; index < admins.Count(); index++)
            {
                if (email == admins[index].Email && pass == admins[index].Password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTeacher()
        {
            TeacherLDDAL teacherLDDAL = new TeacherLDDAL();
            teachers = teacherLDDAL.GetTeachersLoginDetails();
            for (int index = 0; index < teachers.Count(); index++)
            {
                if (email == teachers[index].Email && pass == teachers[index].Password)
                {
                    return true;
                }
            }

            return false;
        }

        
        public Student GetLoggedInStudent()
        {
            StudentLDDAL sdal = new StudentLDDAL();
            ObservableCollection<StudentLD> s = new ObservableCollection<StudentLD>();
            s = sdal.GetStudentsLoginDetails();

            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students = sdal.GetStudents();

            for(int index=0; index<s.Count(); index++)
            {
                if(s[index].Email==email && s[index].Password==pass)
                {
                    for(int i=0; i<students.Count(); i++)
                    {
                        if(students[i].StudentID==s[index].StudentID)
                        {
                            return students[i];
                        }
                    }
                }
            }

            return null;
        }

        public Teacher GetLoggedInTeacher()
        {
            TeacherLDDAL tdal = new TeacherLDDAL();
            ObservableCollection<TeacherLD> tLD = new ObservableCollection<TeacherLD>();
            tLD = tdal.GetTeachersLoginDetails();

            ObservableCollection<Teacher> tList = new ObservableCollection<Teacher>();
            tList = tdal.GetAllTeachers();

            for (int index=0; index<tLD.Count(); index++)
            {
                if(tLD[index].Email==email && tLD[index].Password==pass)
                {
                    for(int i=0; i<tList.Count(); i++)
                    {
                        if(tLD[index].TeacherID==tList[i].TeacherID)
                        {
                            return tList[i];
                        }
                    }
                }
            }
            return null;

        }

        public bool IsStudent()
        {
            StudentLDDAL studentLDDAL = new StudentLDDAL();
            students = studentLDDAL.GetStudentsLoginDetails();
            for (int index = 0; index < students.Count(); index++)
            {
                if (email == students[index].Email && pass == students[index].Password)
                {
                    return true;
                }
            }

            return false;
        }


    }
}

