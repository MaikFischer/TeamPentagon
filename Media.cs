using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CreditClicker
{
    public class Media
    {
        public const int MM_MCINOTIFY = 0x3B9;

        private string fileName;
        private bool isOpen = false;
        private Form notifyForm;
        private string mediaName = "media";

        //mciSendString 
        [DllImport("winmm.dll")]
        private static extern long mciSendString(
            string command,
            StringBuilder returnValue,
            int returnLength,
            IntPtr winHandle);

        private void ClosePlayer()
        {
            if (isOpen)
            {
                String playCommand = "Close " + mediaName;
                mciSendString(playCommand, null, 0, IntPtr.Zero);
                isOpen = false;
            }
        }


        private void OpenMediaFile()
        {
            ClosePlayer();
            string playCommand = "Open \"" + fileName +
                                "\" type mpegvideo alias " + mediaName;
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }


        private void PlayMediaFile()
        {
            if (isOpen)
            {
                string playCommand = "Play " + mediaName + " notify";
                mciSendString(playCommand, null, 0, notifyForm.Handle);
            }
        }


        public void Play(string fileName, Form notifyForm)
        {
            this.fileName = fileName;
            this.notifyForm = notifyForm;
            OpenMediaFile();
            PlayMediaFile();
        }

        public void Stop()
        {
            ClosePlayer();
        }

    }
}