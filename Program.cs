using System;

namespace EventsandDelegates
{
    class Program
    {
        static void Main(string[] args)

        {

            var video = new Video() { Title = "Video1" };
            var videoEncoder = new VideoEncoder(); //EventPublisher
            var mailService = new MailService(); //EventSubscriber
            var messageService = new MessageService(); //EventSubsriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }
    }
}
