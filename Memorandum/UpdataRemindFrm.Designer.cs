﻿namespace CSharpIdeas.Memorandum
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
            this.btnNo.Location = new System.Drawing.Point(258, 347);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(99, 39);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "取消";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(115, 347);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(99, 39);
            this.btnYes.TabIndex = 5;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // UpdataRemindFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 420);
            this.Controls.Add(this.numRank);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Name = "UpdataRemindFrm";
            this.Text = "UpdataRemindFrm";
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
    }
}