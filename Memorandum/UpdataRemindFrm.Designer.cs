namespace CSharpIdeas.Memorandum
{
    partial class UpdataRemindFrm
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
            this.numRank = new System.Windows.Forms.NumericUpDown();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mcEndDate = new System.Windows.Forms.MonthCalendar();
            this.rdbHasntEndDate = new System.Windows.Forms.RadioButton();
            this.rdbHasEndDate = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).BeginInit();
            this.SuspendLayout();
            // 
            // numRank
            // 
            this.numRank.Location = new System.Drawing.Point(115, 76);
            this.numRank.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRank.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRank.Name = "numRank";
            this.numRank.Size = new System.Drawing.Size(242, 25);
            this.numRank.TabIndex = 11;
            this.numRank.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(115, 128);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(242, 191);
            this.txtMain.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(115, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(242, 25);
            this.txtTitle.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "内容:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "重要等级:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "标题:";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(431, 357);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(99, 39);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "取消";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(153, 357);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(99, 39);
            this.btnYes.TabIndex = 5;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "结束日期:";
            // 
            // mcEndDate
            // 
            this.mcEndDate.Location = new System.Drawing.Point(393, 112);
            this.mcEndDate.Name = "mcEndDate";
            this.mcEndDate.TabIndex = 12;
            // 
            // rdbHasntEndDate
            // 
            this.rdbHasntEndDate.AutoSize = true;
            this.rdbHasntEndDate.Location = new System.Drawing.Point(531, 33);
            this.rdbHasntEndDate.Name = "rdbHasntEndDate";
            this.rdbHasntEndDate.Size = new System.Drawing.Size(103, 19);
            this.rdbHasntEndDate.TabIndex = 14;
            this.rdbHasntEndDate.Text = "无截止时间";
            this.rdbHasntEndDate.UseVisualStyleBackColor = true;
            // 
            // rdbHasEndDate
            // 
            this.rdbHasEndDate.AutoSize = true;
            this.rdbHasEndDate.Checked = true;
            this.rdbHasEndDate.Location = new System.Drawing.Point(393, 33);
            this.rdbHasEndDate.Name = "rdbHasEndDate";
            this.rdbHasEndDate.Size = new System.Drawing.Size(103, 19);
            this.rdbHasEndDate.TabIndex = 15;
            this.rdbHasEndDate.TabStop = true;
            this.rdbHasEndDate.Text = "有截止时间";
            this.rdbHasEndDate.UseVisualStyleBackColor = true;
            this.rdbHasEndDate.CheckedChanged += new System.EventHandler(this.rdbHasEndDate_CheckedChanged);
            // 
            // UpdataRemindFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 420);
            this.Controls.Add(this.rdbHasntEndDate);
            this.Controls.Add(this.rdbHasEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mcEndDate);
            this.Controls.Add(this.numRank);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Name = "UpdataRemindFrm";
            this.ShowIcon = false;
            this.Text = "更新备忘录记录";
            this.Load += new System.EventHandler(this.UpdataRemindFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRank;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar mcEndDate;
        private System.Windows.Forms.RadioButton rdbHasntEndDate;
        private System.Windows.Forms.RadioButton rdbHasEndDate;
    }
}