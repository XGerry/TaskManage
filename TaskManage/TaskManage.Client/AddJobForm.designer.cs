namespace TaskManage.Client
{
    partial class AddJobForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboJobType = new System.Windows.Forms.ComboBox();
            this.cboTriggerType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobGroup = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.txtTriggerName = new System.Windows.Forms.TextBox();
            this.txtTriggerDescription = new System.Windows.Forms.TextBox();
            this.txtCronExpression = new System.Windows.Forms.TextBox();
            this.txtTriggerGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJobDescription = new System.Windows.Forms.Label();
            this.txtJobDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(129, 264);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 21);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 264);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboJobType
            // 
            this.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJobType.FormattingEnabled = true;
            this.cboJobType.Location = new System.Drawing.Point(158, 12);
            this.cboJobType.Name = "cboJobType";
            this.cboJobType.Size = new System.Drawing.Size(277, 20);
            this.cboJobType.TabIndex = 1;
            // 
            // cboTriggerType
            // 
            this.cboTriggerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTriggerType.FormattingEnabled = true;
            this.cboTriggerType.Location = new System.Drawing.Point(158, 113);
            this.cboTriggerType.Name = "cboTriggerType";
            this.cboTriggerType.Size = new System.Drawing.Size(277, 20);
            this.cboTriggerType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Job Type:";
            // 
            // txtJobGroup
            // 
            this.txtJobGroup.Location = new System.Drawing.Point(158, 38);
            this.txtJobGroup.Name = "txtJobGroup";
            this.txtJobGroup.Size = new System.Drawing.Size(277, 21);
            this.txtJobGroup.TabIndex = 2;
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(158, 63);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(277, 21);
            this.txtJobName.TabIndex = 3;
            // 
            // txtTriggerName
            // 
            this.txtTriggerName.Location = new System.Drawing.Point(158, 163);
            this.txtTriggerName.Name = "txtTriggerName";
            this.txtTriggerName.Size = new System.Drawing.Size(277, 21);
            this.txtTriggerName.TabIndex = 7;
            // 
            // txtTriggerDescription
            // 
            this.txtTriggerDescription.Location = new System.Drawing.Point(158, 188);
            this.txtTriggerDescription.Name = "txtTriggerDescription";
            this.txtTriggerDescription.Size = new System.Drawing.Size(277, 21);
            this.txtTriggerDescription.TabIndex = 8;
            // 
            // txtCronExpression
            // 
            this.txtCronExpression.Location = new System.Drawing.Point(158, 213);
            this.txtCronExpression.Name = "txtCronExpression";
            this.txtCronExpression.Size = new System.Drawing.Size(277, 21);
            this.txtCronExpression.TabIndex = 9;
            // 
            // txtTriggerGroup
            // 
            this.txtTriggerGroup.Location = new System.Drawing.Point(158, 138);
            this.txtTriggerGroup.Name = "txtTriggerGroup";
            this.txtTriggerGroup.Size = new System.Drawing.Size(277, 21);
            this.txtTriggerGroup.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Job Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Job Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Trigger Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Trigger Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Trigger Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Trigger Group:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cron Expression:";
            // 
            // lblJobDescription
            // 
            this.lblJobDescription.AutoSize = true;
            this.lblJobDescription.Location = new System.Drawing.Point(29, 90);
            this.lblJobDescription.Name = "lblJobDescription";
            this.lblJobDescription.Size = new System.Drawing.Size(101, 12);
            this.lblJobDescription.TabIndex = 19;
            this.lblJobDescription.Text = "Job Description:";
            // 
            // txtJobDescription
            // 
            this.txtJobDescription.Location = new System.Drawing.Point(158, 88);
            this.txtJobDescription.Name = "txtJobDescription";
            this.txtJobDescription.Size = new System.Drawing.Size(277, 21);
            this.txtJobDescription.TabIndex = 4;
            // 
            // AddJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 312);
            this.Controls.Add(this.lblJobDescription);
            this.Controls.Add(this.txtJobDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCronExpression);
            this.Controls.Add(this.txtTriggerGroup);
            this.Controls.Add(this.txtTriggerName);
            this.Controls.Add(this.txtTriggerDescription);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.txtJobGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTriggerType);
            this.Controls.Add(this.cboJobType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddJobForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboJobType;
        private System.Windows.Forms.ComboBox cboTriggerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobGroup;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtTriggerName;
        private System.Windows.Forms.TextBox txtTriggerDescription;
        private System.Windows.Forms.TextBox txtCronExpression;
        private System.Windows.Forms.TextBox txtTriggerGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJobDescription;
        private System.Windows.Forms.TextBox txtJobDescription;
    }
}