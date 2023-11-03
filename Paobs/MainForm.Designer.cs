
namespace Paobs
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mailAddressListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.buttonPane = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // mailAddressListBox
            // 
            this.mailAddressListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mailAddressListBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mailAddressListBox.FormattingEnabled = true;
            this.mailAddressListBox.IntegralHeight = false;
            this.mailAddressListBox.ItemHeight = 15;
            this.mailAddressListBox.Location = new System.Drawing.Point(0, 30);
            this.mailAddressListBox.Name = "mailAddressListBox";
            this.mailAddressListBox.Size = new System.Drawing.Size(473, 144);
            this.mailAddressListBox.TabIndex = 0;
            this.mailAddressListBox.SelectedIndexChanged += new System.EventHandler(this.mailAddressListBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(5, 10);
            this.addButton.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(80, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "追加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(5, 50);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // buttonPane
            // 
            this.buttonPane.AutoSize = true;
            this.buttonPane.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPane.Controls.Add(this.addButton);
            this.buttonPane.Controls.Add(this.deleteButton);
            this.buttonPane.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPane.Location = new System.Drawing.Point(473, 30);
            this.buttonPane.Name = "buttonPane";
            this.buttonPane.Size = new System.Drawing.Size(90, 144);
            this.buttonPane.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "登録されているメールアドレスのリスト";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(0, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 50);
            this.label2.TabIndex = 5;
            this.label2.Text = "現在のユーザーのパソコンの使用状況のメールを送信するメールアドレスを入力してください。\r\nこの実行ファイルを削除する際にはすべてのメールアドレスの登録を解除してく" +
    "ださい。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 224);
            this.Controls.Add(this.mailAddressListBox);
            this.Controls.Add(this.buttonPane);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Paobs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.buttonPane.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox mailAddressListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.FlowLayoutPanel buttonPane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}