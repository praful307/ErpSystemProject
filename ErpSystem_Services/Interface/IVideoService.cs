using ErpSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Services.Interface
{
    public interface IVideoService
    {
        void AddVideo(VideoModel video);
        
        void UpdateVideo(VideoModel video);
        void DeleteVideo(int videoId);
        void RestoreVideo(int videoId);
      Task  <List<VideoModel>> GetAllVideos();
      Task  <VideoModel> GetVideoById(int videoId);
      Task <List <VideoModel>> GetContentWiseVideo(int contentId);
      Task <List <VideoModel>> GetTopicWiceVideo(int topicId);
    }
}
