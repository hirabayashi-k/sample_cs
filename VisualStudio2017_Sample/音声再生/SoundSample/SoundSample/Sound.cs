using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSample
{
    class Sound
    {
        [System.Runtime.InteropServices.DllImport("winmm.dll",
        CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int mciSendString(string command,
        System.Text.StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private string aliasName = "MediaFile";

        public void PlaySound(string file)
        {

            string cmd;
            //ファイルを開く
            cmd = "open \"" + file + "\" alias " + aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0)
                return;
            //再生する
            cmd = "play " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        public void StopSound()
        {
            string cmd;
            //再生しているWAVEを停止する
            cmd = "stop " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            //閉じる
            cmd = "close " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }
    }
}
