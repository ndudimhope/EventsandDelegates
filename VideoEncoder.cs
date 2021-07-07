using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsandDelegates
{
    class VideoEncoder
    {
        //1. Define a Delegate
        //2. Define an Event based on that Delegate
        //3. Raise the Event

        public delegate void VideoEncoderEventHandler(Object source, EventArgs args);

        // Raising the Event
        public event VideoEncoderEventHandler VideoEncoded;


        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);

        }
    }
}
