using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paobs
{
    class RegistryIO
    {
        public static string[] GetList()
        {
            if (Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true) is RegistryKey regkey)
            {
                string listText = regkey.GetValue(Program.AssemblyName) as string;
                regkey.Close();
                return listText?.Trim('\"')?.Split(new string[] { "\" \"" }, StringSplitOptions.RemoveEmptyEntries)?.Skip(1)?.ToArray();
            }
            else
            {
                Console.WriteLine("レジストリのキーを開けませんでした。");
                return null;
            }
        }

        public static bool SetList(string[] list)
        {
            if (Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true) is RegistryKey regkey)
            {
                if (list.Length == 0)
                {
                    if (regkey.GetValueNames().Contains(Program.AssemblyName, EqualityComparer<string>.Default))
                    {
                        regkey.DeleteValue(Program.AssemblyName);
                    }
                }
                else
                {
                    regkey.SetValue(Program.AssemblyName, "\"" + string.Join("\" \"", list.Prepend(Program.AssemblyLocation)) + "\"");
                }

                regkey.Close();
                return true;
            }
            else
            {
                Console.WriteLine("レジストリのキーを開けませんでした。");
                return false;
            }
        }
    }
}
