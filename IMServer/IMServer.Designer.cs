using System.Drawing;

namespace IMServer
{
    partial class IMServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.lbServerIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnStartLinsten = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopListen = new System.Windows.Forms.Button();
            this.lbChatRecord = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLog = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClientList = new System.Windows.Forms.ComboBox();
            this.tbChatContent = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(65, 28);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(117, 21);
            this.tbServerIP.TabIndex = 0;
            this.tbServerIP.Text = "127.0.0.1";
            this.tbServerIP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(18, 33);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(41, 12);
            this.lbServerIP.TabIndex = 1;
            this.lbServerIP.Text = "IP地址";
            this.lbServerIP.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(211, 31);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 12);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "端口";
            this.lbPort.Click += new System.EventHandler(this.lbPort_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(246, 28);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(74, 21);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "9000";
            // 
            // btnStartLinsten
            // 
            this.btnStartLinsten.Location = new System.Drawing.Point(326, 28);
            this.btnStartLinsten.Name = "btnStartLinsten";
            this.btnStartLinsten.Size = new System.Drawing.Size(75, 23);
            this.btnStartLinsten.TabIndex = 4;
            this.btnStartLinsten.Text = "开始监听";
            this.btnStartLinsten.UseVisualStyleBackColor = true;
            this.btnStartLinsten.Click += new System.EventHandler(this.btnStartLinsten_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopListen);
            this.groupBox1.Controls.Add(this.lbServerIP);
            this.groupBox1.Controls.Add(this.btnStartLinsten);
            this.groupBox1.Controls.Add(this.tbServerIP);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Location = new System.Drawing.Point(44, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 77);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnStopListen
            // 
            this.btnStopListen.Location = new System.Drawing.Point(407, 28);
            this.btnStopListen.Name = "btnStopListen";
            this.btnStopListen.Size = new System.Drawing.Size(79, 23);
            this.btnStopListen.TabIndex = 5;
            this.btnStopListen.Text = "停止监听";
            this.btnStopListen.UseVisualStyleBackColor = true;
            this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
            // 
            // lbChatRecord
            // 
            this.lbChatRecord.AutoSize = true;
            this.lbChatRecord.Location = new System.Drawing.Point(18, 81);
            this.lbChatRecord.Name = "lbChatRecord";
            this.lbChatRecord.Size = new System.Drawing.Size(77, 12);
            this.lbChatRecord.TabIndex = 6;
            this.lbChatRecord.Text = "消息转发记录";
            this.lbChatRecord.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbLog);
            this.groupBox2.Controls.Add(this.tbLog);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbClientList);
            this.groupBox2.Controls.Add(this.tbChatContent);
            this.groupBox2.Controls.Add(this.lbChatRecord);
            this.groupBox2.Location = new System.Drawing.Point(44, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 457);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lbLog
            // 
            this.lbLog.AutoSize = true;
            this.lbLog.Location = new System.Drawing.Point(18, 323);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(29, 12);
            this.lbLog.TabIndex = 13;
            this.lbLog.Text = "日志";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.White;
            this.tbLog.Location = new System.Drawing.Point(20, 339);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(504, 103);
            this.tbLog.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "在线列表";
            // 
            // cbClientList
            // 
            this.cbClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClientList.FormattingEnabled = true;
            this.cbClientList.Location = new System.Drawing.Point(89, 42);
            this.cbClientList.Name = "cbClientList";
            this.cbClientList.Size = new System.Drawing.Size(130, 20);
            this.cbClientList.TabIndex = 10;
            this.cbClientList.SelectedIndexChanged += new System.EventHandler(this.cbClientList_SelectedIndexChanged);
            // 
            // tbChatContent
            // 
            this.tbChatContent.BackColor = System.Drawing.Color.White;
            this.tbChatContent.Location = new System.Drawing.Point(20, 105);
            this.tbChatContent.Multiline = true;
            this.tbChatContent.Name = "tbChatContent";
            this.tbChatContent.ReadOnly = true;
            this.tbChatContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChatContent.Size = new System.Drawing.Size(504, 206);
            this.tbChatContent.TabIndex = 7;
            // 
            // IMServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 588);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "IMServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IM服务器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnStartLinsten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbChatRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbChatContent;
        private System.Windows.Forms.Button btnStopListen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClientList;
        private System.Windows.Forms.Label lbLog;
        private System.Windows.Forms.TextBox tbLog;
    }
}

