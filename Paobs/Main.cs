using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Paobs
{
    class Main
    {
        public Main(string[] args)
        {
            LogIO.LogEvents("Application Start");
            PushEvents("ログイン");

            MadList = DicListConverter.ListToDic(args).Keys.ToArray();

            string tempName = TempName;
            if (File.Exists(tempName))
            {
                try
                {
                    Report(File.ReadAllText(tempName, Encoding.UTF8));
                    File.Delete(tempName);
                }
                catch (Exception ee)
                {
                    LogIO.LogEvents(ee.Message);
                }
            }

            TimeStamp = DateTime.Now;

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            SystemEvents.SessionEnded += SystemEvents_SessionEnded;
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            while (IsRunning)
            {
                System.Threading.Thread.Sleep(60000);
                GC.Collect();
            }

            LogIO.LogEvents("Application End");
        }

        private string[] MadList;
        private bool IsRunning = true;

        private DateTime TimeStamp;
        private List<string> EventHistory = new List<string>();

        private static string TempName = $"{Program.UserName}_temp";

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            LogIO.LogEvents(e.Mode.ToString());
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            LogIO.LogEvents(e.Reason.ToString());
            PushEvents("ログアウト");

            if (!Program.UserName.Equals(Environment.UserName))
            {
                return;
            }

            TimeSpan time = DateTime.Now - TimeStamp;

            string tempName = TempName;
            try
            {
                string text = $"{Program.AssemblyName}より{Program.UserName}のパソコンの使用状況を報告させていただきます。\n\n" +
                $"トータルの使用時間は{(int)time.TotalHours}時間{time.Minutes}分{time.Seconds}秒です。\n\n" +
                $"履歴：\n{string.Join("\n", EventHistory)}\n\n" +
                $"このメールの送信を停止するには\n{Program.AssemblyLocation}\nからメールアドレスを削除してください。";

                File.WriteAllText(tempName, text, Encoding.UTF8);
                Report(text);
                File.Delete(tempName);
            }
            catch (Exception ee)
            {
                LogIO.LogEvents(ee.Message);
            }
            finally
            {
                IsRunning = false;
            }
        }

        private void Report(string text) => MailIO.SendMail($"使用状況の報告", text, MadList);

        private bool IsLocked;
        private DateTime LockTime;

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            LogIO.LogEvents(e.Reason.ToString());

            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    PushEvents("ロック");
                    IsLocked = true;
                    LockTime = DateTime.Now;
                    break;
                case SessionSwitchReason.SessionUnlock:
                    if (IsLocked)
                    {
                        PushEvents("アンロック");
                        IsLocked = false;
                        TimeStamp += DateTime.Now - LockTime;
                    }
                    else
                    {
                        EventHistory.Clear();
                        PushEvents("ログイン");
                        TimeStamp = DateTime.Now;
                    }
                    break;
            }
        }

        private void PushEvents(string text)
        {
            EventHistory.Add($"{LogIO.TimeText} {text}");
        }
    }
}
