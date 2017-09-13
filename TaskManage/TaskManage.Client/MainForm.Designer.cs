using System.Windows.Forms;

namespace TaskManage.Client
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
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.jobAssembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAssemblyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAssemblyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalListenersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGlobalJobListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTriggerListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addJobListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_Refresh_Running_Jobs = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.jobGroupsTreeView = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRunJobNow = new System.Windows.Forms.Button();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.listView_RunningJobs = new TaskManage.Client.ListViewNF();
            this.JobName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TriggerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TriggerGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Schedule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PreviousFireDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextFireDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxTrigger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pauseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtJobGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.ctxTrigger.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jobAssembliesToolStripMenuItem,
            this.jobsToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.logToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(936, 25);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // jobAssembliesToolStripMenuItem
            // 
            this.jobAssembliesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAssemblyMenuItem,
            this.deleteAssemblyMenuItem});
            this.jobAssembliesToolStripMenuItem.Name = "jobAssembliesToolStripMenuItem";
            this.jobAssembliesToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.jobAssembliesToolStripMenuItem.Text = "Job Assemblies";
            // 
            // addAssemblyMenuItem
            // 
            this.addAssemblyMenuItem.Name = "addAssemblyMenuItem";
            this.addAssemblyMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addAssemblyMenuItem.Text = "Add";
            this.addAssemblyMenuItem.Click += new System.EventHandler(this.addAssemblyMenuItem_Click);
            // 
            // deleteAssemblyMenuItem
            // 
            this.deleteAssemblyMenuItem.Name = "deleteAssemblyMenuItem";
            this.deleteAssemblyMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteAssemblyMenuItem.Text = "Delete";
            this.deleteAssemblyMenuItem.Click += new System.EventHandler(this.deleteAssemblyMenuItem_Click);
            // 
            // jobsToolStripMenuItem
            // 
            this.jobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addJobToolStripMenuItem});
            this.jobsToolStripMenuItem.Name = "jobsToolStripMenuItem";
            this.jobsToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.jobsToolStripMenuItem.Text = "Jobs";
            // 
            // addJobToolStripMenuItem
            // 
            this.addJobToolStripMenuItem.Name = "addJobToolStripMenuItem";
            this.addJobToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addJobToolStripMenuItem.Text = "Add";
            this.addJobToolStripMenuItem.Click += new System.EventHandler(this.addJobToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.emailToolStripMenuItem.Text = "Email";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addEmailStripMenuItem_Click);
            // 
            // globalListenersToolStripMenuItem
            // 
            this.globalListenersToolStripMenuItem.Name = "globalListenersToolStripMenuItem";
            this.globalListenersToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // addGlobalJobListenerToolStripMenuItem
            // 
            this.addGlobalJobListenerToolStripMenuItem.Name = "addGlobalJobListenerToolStripMenuItem";
            this.addGlobalJobListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // addTriggerListenerToolStripMenuItem
            // 
            this.addTriggerListenerToolStripMenuItem.Name = "addTriggerListenerToolStripMenuItem";
            this.addTriggerListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // addJobListenerToolStripMenuItem
            // 
            this.addJobListenerToolStripMenuItem.Name = "addJobListenerToolStripMenuItem";
            this.addJobListenerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // timer_Refresh_Running_Jobs
            // 
            this.timer_Refresh_Running_Jobs.Interval = 300000;
            this.timer_Refresh_Running_Jobs.Tick += new System.EventHandler(this.timer_Refresh_Running_Jobs_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scheduler Objects";
            // 
            // jobGroupsTreeView
            // 
            this.jobGroupsTreeView.Location = new System.Drawing.Point(14, 50);
            this.jobGroupsTreeView.Name = "jobGroupsTreeView";
            this.jobGroupsTreeView.Size = new System.Drawing.Size(336, 247);
            this.jobGroupsTreeView.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Details";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Location = new System.Drawing.Point(432, 50);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(393, 247);
            this.pnlDetails.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(765, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 21);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(649, 301);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 21);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(507, 301);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(65, 21);
            this.btnPause.TabIndex = 17;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRunJobNow
            // 
            this.btnRunJobNow.Enabled = false;
            this.btnRunJobNow.Location = new System.Drawing.Point(436, 301);
            this.btnRunJobNow.Name = "btnRunJobNow";
            this.btnRunJobNow.Size = new System.Drawing.Size(65, 21);
            this.btnRunJobNow.TabIndex = 16;
            this.btnRunJobNow.Text = "Run";
            this.btnRunJobNow.UseVisualStyleBackColor = true;
            this.btnRunJobNow.Click += new System.EventHandler(this.btnRunJobNow_Click);
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Enabled = false;
            this.btnDeleteJob.Location = new System.Drawing.Point(578, 301);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(65, 21);
            this.btnDeleteJob.TabIndex = 15;
            this.btnDeleteJob.Text = "Delete";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // listView_RunningJobs
            // 
            this.listView_RunningJobs.AllowColumnReorder = true;
            this.listView_RunningJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JobName,
            this.JobGroup,
            this.TriggerName,
            this.TriggerGroup,
            this.Schedule,
            this.StartDate,
            this.PreviousFireDate,
            this.NextFireDate,
            this.State});
            this.listView_RunningJobs.ContextMenuStrip = this.ctxTrigger;
            this.listView_RunningJobs.FullRowSelect = true;
            this.listView_RunningJobs.Location = new System.Drawing.Point(6, 49);
            this.listView_RunningJobs.Name = "listView_RunningJobs";
            this.listView_RunningJobs.Size = new System.Drawing.Size(906, 368);
            this.listView_RunningJobs.TabIndex = 23;
            this.listView_RunningJobs.UseCompatibleStateImageBehavior = false;
            this.listView_RunningJobs.View = System.Windows.Forms.View.Details;
            this.listView_RunningJobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_RunningJobs_ColumnClick);
            this.listView_RunningJobs.SelectedIndexChanged += new System.EventHandler(this.listView_RunningJobs_SelectedIndexChanged);
            // 
            // JobName
            // 
            this.JobName.Text = "Job Name";
            this.JobName.Width = 84;
            // 
            // JobGroup
            // 
            this.JobGroup.Text = "Job Group";
            this.JobGroup.Width = 88;
            // 
            // TriggerName
            // 
            this.TriggerName.Text = "Trigger Name";
            this.TriggerName.Width = 90;
            // 
            // TriggerGroup
            // 
            this.TriggerGroup.Text = "Trigger Group";
            this.TriggerGroup.Width = 80;
            // 
            // Schedule
            // 
            this.Schedule.Text = "Schedule";
            this.Schedule.Width = 100;
            // 
            // StartDate
            // 
            this.StartDate.Text = "Start date";
            this.StartDate.Width = 100;
            // 
            // PreviousFireDate
            // 
            this.PreviousFireDate.Text = "Previous fire date";
            this.PreviousFireDate.Width = 100;
            // 
            // NextFireDate
            // 
            this.NextFireDate.Text = "Next fire date";
            this.NextFireDate.Width = 100;
            // 
            // State
            // 
            this.State.Text = "State";
            // 
            // ctxTrigger
            // 
            this.ctxTrigger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem1,
            this.resumeToolStripMenuItem1});
            this.ctxTrigger.Name = "ctxTrigger";
            this.ctxTrigger.Size = new System.Drawing.Size(123, 48);
            // 
            // pauseToolStripMenuItem1
            // 
            this.pauseToolStripMenuItem1.Enabled = false;
            this.pauseToolStripMenuItem1.Name = "pauseToolStripMenuItem1";
            this.pauseToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.pauseToolStripMenuItem1.Text = "Pause";
            this.pauseToolStripMenuItem1.Click += new System.EventHandler(this.pauseToolStripMenuItem1_Click);
            // 
            // resumeToolStripMenuItem1
            // 
            this.resumeToolStripMenuItem1.Enabled = false;
            this.resumeToolStripMenuItem1.Name = "resumeToolStripMenuItem1";
            this.resumeToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.resumeToolStripMenuItem1.Text = "Resume";
            this.resumeToolStripMenuItem1.Click += new System.EventHandler(this.resumeToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboState);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtJobGroup);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtJobName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listView_RunningJobs);
            this.groupBox1.Location = new System.Drawing.Point(12, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 440);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running Jobs";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(659, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "",
            "Active",
            "Paused"});
            this.cboState.Location = new System.Drawing.Point(483, 17);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(121, 20);
            this.cboState.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "State:";
            // 
            // txtJobGroup
            // 
            this.txtJobGroup.Location = new System.Drawing.Point(297, 15);
            this.txtJobGroup.Name = "txtJobGroup";
            this.txtJobGroup.Size = new System.Drawing.Size(117, 21);
            this.txtJobGroup.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "JobGroup:";
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(83, 16);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(117, 21);
            this.txtJobName.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "JobName:";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 753);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnRunJobNow);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jobGroupsTreeView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ctxTrigger.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem globalListenersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGlobalJobListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTriggerListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addJobListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addJobToolStripMenuItem;
        private System.Windows.Forms.Timer timer_Refresh_Running_Jobs;
        private System.Windows.Forms.ToolStripMenuItem jobAssembliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAssemblyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAssemblyMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView jobGroupsTreeView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRunJobNow;
        private System.Windows.Forms.Button btnDeleteJob;
        private ListViewNF listView_RunningJobs;
        private System.Windows.Forms.ColumnHeader JobName;
        private System.Windows.Forms.ColumnHeader TriggerName;
        private System.Windows.Forms.ColumnHeader Schedule;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader PreviousFireDate;
        private System.Windows.Forms.ColumnHeader NextFireDate;
        private System.Windows.Forms.ColumnHeader State;
        private ColumnHeader JobGroup;
        private ContextMenuStrip ctxTrigger;
        private ToolStripMenuItem pauseToolStripMenuItem1;
        private ToolStripMenuItem resumeToolStripMenuItem1;
        private ColumnHeader TriggerGroup;
        private GroupBox groupBox1;
        private Button btnSearch;
        private ComboBox cboState;
        private Label label5;
        private TextBox txtJobGroup;
        private Label label4;
        private TextBox txtJobName;
        private Label label3;
        private ToolStripMenuItem emailToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem logToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
    }
}

