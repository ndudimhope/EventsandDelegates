using System;

namespace EventsandDelegates
{
    class Program
    {

        public static FellowQueries fellowQueries = new FellowQueries();
        static void Main(string[] args)

        {

            //var video = new Video() { Title = "Video1" };
            //var videoEncoder = new VideoEncoder(); //EventPublisher
            //var mailService = new MailService(); //EventSubscriber
            //var messageService = new MessageService(); //EventSubsriber

            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            //videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            //videoEncoder.Encode(video);

            //fellowQueries.GetFellowsSortedByLastName1();
            //fellowQueries.GetFellowsSortedByLastName2();

            //fellowQueries.GetFellowsBornfrom2005SortedDesc1();
            //fellowQueries.GetFellowsBornfrom2005SortedByDesc2();

            //fellowQueries.GetFellowsNeitherMaleNorFemale1();
            //fellowQueries.GetFellowsNeitherMaleNorFemale2();

            fellowQueries.GetFellowsGroupedByTracks();
            fellowQueries.GetFellowsGroupedByTracks2();


        }
    }
}
