using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Paobs
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, string> Dic;

        public MainForm()
        {
            InitializeComponent();

            Dic = DicListConverter.ListToDic(RegistryIO.GetList());
            mailAddressListBox.Items.AddRange(Dic.Keys.ToArray());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryIO.SetList(DicListConverter.DicToList(Dic));
        }

        private SHA512 SHA = new SHA512Managed();
        private string GetHexHash(string text) => string.Join(string.Empty, SHA.ComputeHash(Encoding.UTF8.GetBytes(text)).Select(x => $"{x:x}"));

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                string mad = addForm.MailAddress;
                if (!Regex.IsMatch(mad, @"\w+@.+\.\w+$"))
                {
                    MessageBox.Show(this, "メールアドレスの形式ではありませんでした。", "形式の違い", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Dic.ContainsKey(mad))
                {
                    MessageBox.Show(this, $"{mad}はすでに追加されています。", "重複", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string password = addForm.Password;
                    if (password.Length > 0)
                    {
                        Dic.Add(mad, GetHexHash(password));
                    }
                    else
                    {
                        Dic.Add(mad, null);
                    }

                    mailAddressListBox.Items.Add(mad);
                    MessageBox.Show(this, $"{mad}を追加しました。\n確認メールが{mad}に宛てて送られます。\n変更を適用するにはログインしなおしてください。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MailIO.SendMail($"確認メール", $"{Program.AssemblyName}で{mad}が{Program.UserName}のパソコンの使用状況のメールを送信するメールアドレスとして追加されました。", mad);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string mad = (string)mailAddressListBox.SelectedItem;
            if (Dic[mad] == null)
            {
                delete();
            }
            else
            {
                AuthForm authForm = new AuthForm();
                authForm.MailAddress = mad;
                if (authForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (Dic[mad].Equals(GetHexHash(authForm.Password)))
                    {
                        delete();
                    }
                    else
                    {
                        MessageBox.Show(this, $"パスワードが違います。", "認証失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            void delete()
            {
                Dic.Remove(mad);
                mailAddressListBox.Items.Remove(mad);
                if (Dic.Count == 0)
                {
                    MessageBox.Show(this, $"{mad}の登録を解除しました。\nすべてのメールアドレスを削除したので、この実行ファイルを削除することができます。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, $"{mad}の登録を解除しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                MailIO.SendMail($"確認メール", $"{Program.AssemblyName}で{mad}が{Program.UserName}のパソコンの使用状況のメールを送信するメールアドレスから削除されました。", mad);
            }
        }

        private void mailAddressListBox_SelectedIndexChanged(object sender, EventArgs e) => deleteButton.Enabled = mailAddressListBox.SelectedIndex != -1;
    }
}
