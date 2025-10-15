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
    public class VideoService : IVideoService
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection);
        public void AddVideo(VideoModel video)
        {
            con.Open();
            using(SqlCommand cmd= new SqlCommand("sp_ContentVideo",con))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "insert");
           
                cmd.Parameters.AddWithValue("@ContentId", video.ContentId);
                cmd.Parameters.AddWithValue("@VideoTitle", video.VideoTitle);
                cmd.Parameters.AddWithValue("@VideoUrl", video.VideoUrl);
                int cnt = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVideo(int videoId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentVideo", con))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@VideoId", videoId);
                cmd.ExecuteNonQuery();

            }
        }

        public Task<List<VideoModel>> GetAllVideos()
        {
            List<VideoModel> lst = new List<VideoModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_FetchContentVideo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VideoId", 0);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            VideoModel cs = new VideoModel()
                            {
                                VideoId = Convert.ToInt32(dr["VideoId"].ToString()),
                                ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                                ContentName = dr["ContentName"].ToString(),
                                VideoTitle = dr["VideoTitle"].ToString(),
                                VideoUrl = dr["VideoUrl"].ToString(),
                            };
                            lst.Add(cs);
                        }
                    }
                }
            }

            // Wrap the result in a completed task
            return Task.FromResult(lst);
        }

        public Task<List<VideoModel>> GetContentWiseVideo(int contentId)
        {
            con.Close();
            List<VideoModel> lst = new List<VideoModel>();
            using(SqlCommand cmd= new SqlCommand("sp_FetchContentWiseVideo",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", contentId);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new VideoModel
                    {
                      
                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        VideoId = Convert.ToInt32(dr["VideoId"].ToString()),
                        VideoUrl = dr["VideoUrl"].ToString(),
                        VideoTitle = dr["VideoTitle"].ToString(),

                    });
                }

            }
            return Task.FromResult(lst);
        }

        public Task<List<VideoModel>> GetTopicWiceVideo(int topicId)
        {
            con.Close();
            List<VideoModel> lst = new List<VideoModel>();
            using (SqlCommand cmd = new SqlCommand("sp_TopicWiseVideos", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", topicId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add(new VideoModel
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),

                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        VideoId = Convert.ToInt32(dr["VideoId"].ToString()),
                        VideoUrl = dr["VideoUrl"].ToString(),
                        VideoTitle = dr["VideoTitle"].ToString(),

                    });
                }

            }
            return Task.FromResult(lst);
        }

        public Task<VideoModel> GetVideoById(int videoId)
        {


            con.Close();
            VideoModel video = null;
            con.Close();
            using (SqlCommand cmd = new SqlCommand("sp_FetchContentVideo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VideoId", videoId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    video = new VideoModel
                    {
                        TopicId = Convert.ToInt32(dr["TopicId"].ToString()),
                        TopicName = dr["TopicName"].ToString(),

                        ContentId = Convert.ToInt32(dr["ContentId"].ToString()),
                        ContentName = dr["ContentName"].ToString(),
                        VideoId = Convert.ToInt32(dr["VideoId"].ToString()),
                        VideoUrl = dr["VideoUrl"].ToString(),
                        VideoTitle = dr["VideoTitle"].ToString(),

                    };

                }              

            }
            return Task.FromResult(video);
        }

        public void RestoreVideo(int videoId)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentVideo", con))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "restore");
                cmd.Parameters.AddWithValue("@VideoId", videoId);
                cmd.ExecuteNonQuery();

            }
        }

        public void UpdateVideo(VideoModel video)
        {
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_ContentVideo", con))
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "update");

                cmd.Parameters.AddWithValue("@ContentId", video.ContentId);
                cmd.Parameters.AddWithValue("@VideoTitle", video.VideoTitle);
                cmd.Parameters.AddWithValue("@VideoUrl", video.VideoUrl);
                int cnt = cmd.ExecuteNonQuery();
            }
        }
    }
}
