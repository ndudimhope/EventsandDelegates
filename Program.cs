using System;

namespace EventsandDelegates
{
    class Program
    {
        static void Main(string[] args)

        {

            var video = new Video() { Title = "Video1" };
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }
}
