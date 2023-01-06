using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikMvcApp1.Data.Registrar;

namespace TelerikMvcApp1.Classes
{
    public class UserSession
    {
        //public void SetSessStuId(string studentCaseId)
        //{

        //}

        //public static string studentCaseId
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["students"] != null)
        //            return (string)HttpContext.Current.Session["students"];
        //        else
        //        {
        //            return HttpContext.Current.Session["students"].ToString();
        //        }
        //    }
        //    set=> HttpContext.Current.Session["students"] = value;
        //}

        public static string GetStudentID()
        {
            string studentID = null;
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["students"] != null)
                studentID = HttpContext.Current.Session["students"].ToString();
            return studentID;
        }

        public static string selectedSociety
        {
            get => HttpContext.Current.Session["society"] == null
                ? "All"
                : HttpContext.Current.Session["society"].ToString();
            set=>HttpContext.Current.Session["society"]=value;
        }

        public static string setGyr
        {
            get
            {
                if (HttpContext.Current.Session["classYear"] == null)
                    return "2022";
                else
                    return HttpContext.Current.Session["classYear"].ToString();
            }
            set
            {
                HttpContext.Current.Session["classYear"] = value;
            }
        }

        public static string setStudName
        {
            get
            {
                if (HttpContext.Current.Session["students"] == null)
                    return "0";
                else
                    return HttpContext.Current.Session["students"].ToString();
            }
            set
            {
                HttpContext.Current.Session["students"] = value;
            }
        }

        public static string SetSociety()
        {
            string society = string.Empty;
            if (string.IsNullOrEmpty(society))
                society = HttpContext.Current.Session["society"].ToString();
            return society;
        }
        
        public static string selectedStudent
        {
            get
            {
                if (HttpContext.Current.Session != null)
                    return (string)HttpContext.Current.Session["selectedStudent"];
                else
                    return (string)string.Empty;
            }
            set
            {
                HttpContext.Current.Session["selectedStudent"] = value;
            }
        }

        //public static string GetSelectedStudent()
        //{
        //    string studentID = string.Empty;
        //    if (HttpContext.Current.Session != null && HttpContext.Current.Session["studentID"] != null)
        //        studentID = HttpContext.Current.Session["studentID"].ToString();
        //    return studentID;
        //}

        //public static string GetStudentFullNameByCaseID()
        //{
        //    PerformanceTracker pt = new PerformanceTracker("GetUserFullNameByCaseID");
        //    Data.DevCollections.DevCollectionsEntities Entities = new Data.DevCollections.DevCollectionsEntities();
        //    RegistrarEntities1 Entities = new RegistrarEntities1();
        //    var caseid = GetSelectedStudent();
        //    var student = Entities.Personals.Where(u => u.Campus_Id == caseid).FirstOrDefault();
        //    string studentFullName = caseid;
        //    if (student != null)
        //        studentFullName = string.Concat((student.First_Name ?? "").Trim(), " ", (student.Last_Name ?? "").Trim()); //string.Join(" ",(new string[] { (user.fname ?? ""), (user.lname??"") }).Where(m => !string.IsNullOrEmpty(m)).ToList());            
        //    pt.Stop();
        //    return studentFullName;
        //}

        //public static string GetStudentSociety()
        //{
        //    RegistrarEntities1 Entities = new RegistrarEntities1();
        //    var caseid = GetSelectedStudent();
        //    var studentSoc = Entities.vw_Matri_Grad_Dates.Where(u => u.emaddr == caseid).FirstOrDefault();
        //    string studentSociety = caseid;
        //    if (studentSoc != null)
        //        studentSociety = studentSoc.advisor_society.Trim();
        //    return studentSociety;

        //}

        //public static string GetExpMatriDate()
        //{
        //    RegistrarEntities1 Entities = new RegistrarEntities1();
        //    var caseid = GetSelectedStudent();
        //    var studentGyr = Entities.vw_Matri_Grad_Dates.Where((u) => u.emaddr == caseid).FirstOrDefault();
        //    string studentExpMatriDate = caseid;
        //    if (studentGyr != null)
        //        studentExpMatriDate = studentGyr.gyr.ToString();
        //    return studentExpMatriDate;
        //}
    }
}