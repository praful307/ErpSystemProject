using ErpSystem_Models;
using ErpSystem_Services.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Implementation
{
    public class CourseFeesService : ICourseFeesService
    {
        public void AddCourseFees(CourseFeesModel fees)
        {
           using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CourseFees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "insert");
                    cmd.Parameters.AddWithValue("@FeesId", fees.FeesId);
                    cmd.Parameters.AddWithValue("@FeesMode",fees.FeesMode);
                    cmd.Parameters.AddWithValue("@FeesAmount",fees.FeesAmount);
                    cmd.Parameters.AddWithValue("@Gst", fees.Gst);
                    cmd.Parameters.AddWithValue("@CourseId", fees.CourseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCourseFees(int feesId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CourseFees",con))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "delete");
                    cmd.Parameters.AddWithValue("@FeesId", feesId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CourseFeesModel> GetAllCoursesFees()
        {List<CourseFeesModel> lst= new List<CourseFeesModel>();
            using (SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd= new SqlCommand("sp_FetchCourseFees",con))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeesId", 0);
                    SqlDataReader dr= cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        int feesid = Convert.ToInt32(dr["FeesId"].ToString());
                        int courseId = Convert.ToInt32(dr["CourseId"].ToString());
                        string courseName = dr["CourseName"].ToString();    
                        string courseDes=dr["Description"].ToString();
                        string feesMode= dr["FeesMode"].ToString();
                        float feesAmount = (float)Convert.ToDouble(dr["FeesAmount"].ToString());
                        string gst = dr["Gst"].ToString();
                        CourseFeesModel cf = new CourseFeesModel()
                        {
                            FeesId = feesid,
                            CourseId = courseId,
                            CourseName = courseName,
                            Description = courseDes,
                            FeesMode = feesMode,
                            FeesAmount = feesAmount,
                            Gst = gst
                        };
                        lst.Add(cf);
                    }
                  
                   
                }
            }  
            return lst;
        }

        public CourseFeesModel  GetCourseFeesById(int feesId)
        {
            CourseFeesModel courseFees = null;
            using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using(SqlCommand cmd= new SqlCommand("sp_FetchCourseFees",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FeesId", feesId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        int feesid = Convert.ToInt32(dr["FeesId"].ToString());
                        int courseId = Convert.ToInt32(dr["CourseId"].ToString());
                        string courseName = dr["CourseName"].ToString();
                        string courseDes = dr["Description"].ToString();
                        string feesMode = dr["FeesMode"].ToString();
                        float feesAmount = (float)Convert.ToDouble(dr["FeesAmount"].ToString());
                        string gst = dr["Gst"].ToString();

                        courseFees = new CourseFeesModel()
                        {
                            FeesId = feesId,
                            CourseId = courseId,
                            CourseName = courseName,
                            Description = courseDes,
                            FeesMode = feesMode,
                            FeesAmount = feesAmount,
                            Gst = gst
                        };
                        
                    }
                }
                
            }
            return courseFees;

        }

        //public Task<CourseFeesModel> GetCourseWiseFees(int courseId)
        //{
        //    throw new NotImplementedException();
        //}

        public void RestoreCourseFees(int feesId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CourseFees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "restore");
                    cmd.Parameters.AddWithValue("@FeesId", feesId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UdpateCourses(CourseFeesModel fees)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CourseFees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "update");
                    cmd.Parameters.AddWithValue("@FeesId", fees.FeesId);
                    cmd.Parameters.AddWithValue("@FeesMode", fees.FeesMode);
                    cmd.Parameters.AddWithValue("@FeesAmount", fees.FeesAmount);
                    cmd.Parameters.AddWithValue("@Gst", fees.Gst);
                   

                }
            }
        }
    }
}
