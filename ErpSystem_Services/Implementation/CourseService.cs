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
    public class CourseService : ICourseService
    {
        public void AddCourse(CoursesModel courses)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@CourseId", courses.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", courses.CourseCode);
                cmd.Parameters.AddWithValue("@Description", courses.Description);
              
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_Courses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "delete");
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CoursesModel> GetAllCourses()
        {
            List<CoursesModel> lst = new List<CoursesModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FetchCourse", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseId", 0);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CoursesModel cs = new CoursesModel()
                            {
                                CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                                CourseName = dr["CourseName"].ToString(),
                                CourseCode = dr["CourseCode"].ToString(),
                                Description = dr["CoursesDesription"].ToString()
                            };
                            lst.Add(cs);
                        }
                    }
                }
            }

            // Wrap the result in a completed task
            return lst;
        }


        public CoursesModel GetCourseById(int courseId)
        {
            CoursesModel course = null;

            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FetchCourse", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // only one record expected
                        {
                            course = new CoursesModel()
                            {
                                CourseId = Convert.ToInt32(dr["CourseId"].ToString()),
                                CourseName = dr["CourseName"].ToString(),
                                CourseCode= dr["CourseCode"].ToString(),
                                Description = dr["CoursesDesription"].ToString()
                            };
                        }
                    }
                }
            }

            return course;
        }


        public void RestoreCourse(int courseId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_Courses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "restore");
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCourse(CoursesModel courses)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Courses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");
                cmd.Parameters.AddWithValue("@CourseId", courses.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", courses.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", courses.CourseCode);
                cmd.Parameters.AddWithValue("@Description", courses.Description);
                int cnt = cmd.ExecuteNonQuery();
            }
        }
    }
}
