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
    internal class CourseFeesService : ICourseFeesService
    {
        public void AddCourseFees(CourseFeesModel fees)
        {
          using(SqlConnection con= new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_CourseFees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
                cmd.Parameters.AddWithValue("@FeesId", fees.FeesId);
                    cmd.Parameters.AddWithValue("@FeesAmount", fees.FeesAmount);
                cmd.Parameters.AddWithValue("@Gst", fees.Gst);
                cmd.Parameters.AddWithValue("@CourseId", fees.CourseId);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourseFees(int feesId)
        {
            throw new NotImplementedException();
        }

        public List<CourseFeesModel> GetAllCoursesFees()
        {
            List<CourseFeesModel> lst = new List<CourseFeesModel>();

            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FetchCourseFees", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                  
                    cmd.Parameters.AddWithValue("@FeesId", DBNull.Value);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CourseFeesModel fs = new CourseFeesModel()
                        {
                            FeesId = Convert.ToInt32(dr["FeesId"]),
                            CourseId = Convert.ToInt32(dr["CourseId"]),
                            CourseName = dr["CourseName"].ToString(),
                            Description = dr["Description"].ToString(),
                            FeesMode = dr["FeesMode"].ToString(),
                            FeesAmount = Convert.ToSingle(dr["FeesAmount"]),
                            Gst = Convert.ToSingle(dr["Gst"]),
                            Flag = Convert.ToInt32(dr["Flag"])
                        };

                        lst.Add(fs);
                    }
                }
            }

            return lst;
        }


        public CourseFeesModel GetCourseFeesbyCourseId(int courseId)
        {
            throw new NotImplementedException();

        }

        public CourseFeesModel GetCourseFeesById(int feesId)
        {

            CourseFeesModel courseFees = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_FetchCourseFees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeesId", feesId); 
                SqlDataReader dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    int fid = Convert.ToInt32(dr["FeesId"].ToString());
                    int cid = Convert.ToInt32(dr["CourseId"].ToString());
                    string cname = dr["CourseName"].ToString();
                    string cd = dr["Description"].ToString();
                    string fm = dr["FeesMode"].ToString();
                    float fa = (float)(Convert.ToDouble(dr["FeesAmount"].ToString()));
                    float g = (float)(Convert.ToDouble(dr["Gst"].ToString()));
                    int f = Convert.ToInt32(dr["Flag"].ToString());
                     courseFees = new CourseFeesModel()
                    {
                        FeesId = fid,
                        CourseId = cid,
                        CourseName = cname,
                        Description = cd,
                        FeesMode = fm,
                        FeesAmount = fa,
                        Gst = g,
                        Flag = f
                    };
                }
                return courseFees;
            }
        }

        public void RestoreCourseFees(int feesId)
        {
            throw new NotImplementedException();
        }

        public void UdpateCourses(CourseFeesModel fees)
        {
            throw new NotImplementedException();
        }
    }
}
