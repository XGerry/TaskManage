namespace TaskManage.Client
{
    partial class AddEmailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboClassName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceivers = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCcs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBCcs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Name:";
            // 
            // cboClassName
            // 
            this.cboClassName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClassName.FormattingEnabled = true;
            this.cboClassName.Location = new System.Drawing.Point(94, 19);
            this.cboClassName.Name = "cboClassName";
            this.cboClassName.Size = new System.Drawing.Size(299, 20);
            this.cboClassName.TabIndex = 1;
            this.cboClassName.SelectedIndexChanged += new System.EventHandler(this.cboClassName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Receivers:";
            // 
            // txtReceivers
            // 
            this.txtReceivers.Location = new System.Drawing.Point(94, 52);
            this.txtReceivers.Multiline = true;
            this.txtReceivers.Name = "txtReceivers";
            this.txtReceivers.Size = new System.Drawing.Size(448, 154);
            this.txtReceivers.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ccs:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCcs
            // 
            this.txtCcs.Location = new System.Drawing.Point(94, 230);
            this.txtCcs.Multiline = true;
            this.txtCcs.Name = "txtCcs";
            this.txtCcs.Size = new System.Drawing.Size(448, 94);
            this.txtCcs.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "BCcs:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBCcs
            // 
            this.txtBCcs.BackColor = System.Drawing.SystemColors.Window;
            this.txtBCcs.Location = new System.Drawing.Point(94, 340);
            this.txtBCcs.Name = "txtBCcs";
            this.txtBCcs.Size = new System.Drawing.Size(448, 21);
            this.txtBCcs.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Remark:";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(94, 382);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(448, 21);
            this.txtRemark.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 418);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Creator:";
            // 
            // txtCreator
            // 
            this.txtCreator.Location = new System.Drawing.Point(94, 418);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(201, 21);
            this.txtCreator.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Coral;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(61, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(360, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "注意:多個收件人，抄送人以及密送人之間用;隔開";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(153, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(272, 461);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // AddEmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 526);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBCcs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCcs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReceivers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboClassName);
            this.Controls.Add(this.label1);
            this.Name = "AddEmailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEmailForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReceivers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCcs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBCcs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCreator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
    }
}