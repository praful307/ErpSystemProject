using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    internal class CourseService : ICourseService
    {
        public void AddCourse(CoursesModel courses)
        {
            using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@CourseId", courses.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                cmd.Parameters.AddWithValue("@Description", courses.CourseDescription);
                int cnt= cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
             using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.Parameters.AddWithValue("@CourseName", "");
                cmd.Parameters.AddWithValue("@Description", "");
                int cnt= cmd.ExecuteNonQuery();
            }


        }

        public List<CoursesModel> GetAllCourses()
        {
            List<CoursesModel> lst = new List<CoursesModel>();
             using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_FetchCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", 0);
                SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                {
                    int cid = Convert.ToInt32(dr["CourseId"].ToString());
                    string cname = dr["CourseName"].ToString();
                    string d = dr["Description"].ToString();
                    CoursesModel cs = new CoursesModel()
                    {

                        CourseId = cid,
                        CourseName = cname,
                        CourseDescription = d
                    };
                    lst.Add(cs);

                }
         
               

            }
            return lst;
        }

        public CoursesModel GetCourseById(int courseId)
        {
            CoursesModel course = null;
            using(SqlConnection con=  new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_FetchCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int cid = Convert.ToInt32(dr["CourseId"].ToString());
                    string cname = dr["CourseName"].ToString();
                    string d = dr["Description"].ToString();
                    course = new CoursesModel()
                    {
                        CourseId = cid,
                        CourseName = cname,
                        CourseDescription = d
                    };
                    
                    

                }
                return course;
            }
        }

        public void RestoreCourse(int courseId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@CourseId", courseId);
                cmd.Parameters.AddWithValue("@CourseName", "");
                cmd.Parameters.AddWithValue("@Description", "");
                int cnt = cmd.ExecuteNonQuery();
            }    
        }

        public void UpdateCourse(CoursesModel courses)
        {
           using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                    cmd.Parameters.AddWithValue("@CourseId", courses.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                cmd.Parameters.AddWithValue("@Description", courses.CourseDescription);
            }
        }
    }
}
