using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using Quartz;
using Quartz.Impl.Matchers;
using TaskManage.Core.Domain;
using TaskManage.Core.Domain.TriggerTypes;
using TaskManage.Core.SchedulerProviders;

namespace TaskManage.Client
{
    public partial class MainForm : Form
    {
        private readonly ISchedulerProvider _schedulerProvider;
        private readonly ISchedulerDataProvider _schedulerDataProvider;

        public MainForm()
        {
            InitializeComponent();
            jobGroupsTreeView.AfterSelect += jobGroupsTreeView_AfterSelect;
        }

        public MainForm(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider)
            : this()
        {
            this._schedulerProvider = schedulerProvider;
            this._schedulerDataProvider = schedulerDataProvider;
            loadJobGroups();
            loadRunningJobs();
            this.jobGroupsTreeView.Nodes[0].Expand();
            this.cboState.SelectedIndex = 0;
            //this.jobGroupsTreeView.ExpandAll();
        }

        void jobGroupsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListView lv = new ListView();
            lv.Items.Clear();
            jobDetailsToggle(false);
            if (e.Node is SchedulerNode)
            {
                pnlDetails.Controls.Add(new ScheduleDisplay(_schedulerDataProvider.Data));
            }
            if (e.Node is TriggerNode || e.Node is JobNode)
            {
                btnDeleteJob.Enabled = true;
            }
            else
            {
                btnDeleteJob.Enabled = false;
            }
            if (e.Node is JobNode)
            {
                JobNode jobNode = (JobNode)e.Node;
                var jobDetailsData = _schedulerDataProvider.GetJobDetailsData(e.Node.Text, e.Node.Parent.Parent.Text);
                btnRunJobNow.Enabled = true;
                pnlDetails.Controls.Add(new NativeJobDetailDisplay(jobDetailsData));
            }
            else
            {
                btnRunJobNow.Enabled = false;

            }
            if (e.Node is TriggerNode)
            {
                TriggerNode node = (TriggerNode)e.Node;
                var triggerData = _schedulerDataProvider.GetTriggerData(node.Trigger.Key);
                btnPause.Enabled = true;
                setPauseButtonText();
                if (triggerData.TriggerType.Code == "cron")
                {
                    pnlDetails.Controls.Add(new CronTriggerDisplay(triggerData));
                }
                if (triggerData.TriggerType.Code == "simple")
                {
                    pnlDetails.Controls.Add(new SimpleTriggerDisplay(triggerData));
                }
                btnEdit.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnPause.Enabled = false;
            }

            #region 當選擇JobGroup子節點時自動過濾出List列表內容

            if (e.Node.Parent != null && e.Node.Parent.Text == "Job Groups")
            {
                ListViewItem searchItem = null;
                int index = 0;
                List<int> listIndex = new List<int>();
                List<int> temp = new List<int>();
                for (int i = 0; i < listView_RunningJobs.Items.Count; i++)
                {
                    temp.Add(i);
                }
                do
                {
                    if (index < listView_RunningJobs.Items.Count)
                    {
                        searchItem = listView_RunningJobs.FindItemWithText(e.Node.Text, true, index, false);
                        if (searchItem != null)
                        {
                            index = searchItem.Index + 1;
                            listIndex.Add(index);
                            searchItem.BackColor = Color.Coral;
                            if (temp.Exists(m => m == index - 1))
                            {
                                temp.Remove(index - 1);
                            }
                        }
                    }
                    else
                        searchItem = null;

                } while (searchItem != null);
                for (int i = 0; i < temp.Count; i++)
                {
                    ListViewItem item = listView_RunningJobs.Items[temp[i]];
                    item.BackColor = Color.Empty;
                }
            }
            else
            {
                for (int i = 0; i < listView_RunningJobs.Items.Count; i++)
                {
                    ListViewItem item = listView_RunningJobs.Items[i];
                    item.BackColor = Color.Empty;
                }
            }
            #endregion

            jobDetailsToggle(true);
        }

        private void setPauseButtonText()
        {
            TriggerNode node = (TriggerNode)jobGroupsTreeView.SelectedNode;
            if (_schedulerProvider.Scheduler.GetTriggerState(node.Trigger.Key) == TriggerState.Paused)
            {
                btnPause.Text = "Resume";
            }
            else
            {
                btnPause.Text = "Pause";
            }
        }

        private void loadJobGroups()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                jobDetailsToggle(false);
                SchedulerNode schedulerNode = new SchedulerNode(_schedulerProvider.Scheduler);
                if (jobGroupsTreeView.Nodes.ContainsKey(schedulerNode.Name))
                {
                    jobGroupsTreeView.Nodes.RemoveByKey(schedulerNode.Name);
                }
                jobGroupsTreeView.Nodes.Add(schedulerNode);
                TreeNode jobGroupsNode = schedulerNode.Nodes.Add("Job Groups");
                var jobGroups = _schedulerProvider.Scheduler.GetJobGroupNames();
                foreach (string jobGroup in jobGroups)
                {
                    TreeNode jobGroupNode = jobGroupsNode.Nodes.Add(jobGroup);
                    TreeNode jobsNode = jobGroupNode.Nodes.Add("Jobs");
                    addJobNodes(jobsNode);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void loadRunningJobs()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                timer_Refresh_Running_Jobs.Stop();
                listView_RunningJobs.Items.Clear();
                var jobGroups = _schedulerDataProvider.Data.JobGroups;
                this.listView_RunningJobs.BeginUpdate();
                foreach (var jobGroup in jobGroups)
                {
                    foreach (var job in jobGroup.Jobs)
                    {
                        string jobName = job.UniqueName.Split('_')[1];
                        string jobGroupName = job.GroupName;
                        foreach (var trigger in job.Triggers)
                        {
                            string triggerName = trigger.Name;
                            string startDate = trigger.StartDate.ToString("yyyy-MM-dd HH:mm:ss");
                            string endDate = string.Empty;
                            if (trigger.EndDate.HasValue)
                            {
                                endDate = Convert.ToDateTime(trigger.EndDate).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            string previousFireDate = string.Empty;
                            if (trigger.PreviousFireDate.HasValue)
                            {
                                previousFireDate = Convert.ToDateTime(trigger.PreviousFireDate).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            string nextFireDate = string.Empty;
                            if (trigger.NextFireDate.HasValue)
                            {
                                nextFireDate = Convert.ToDateTime(trigger.NextFireDate).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            string triggerTypeMessage = string.Empty;
                            if (trigger.TriggerType.Code == "cron")
                            {
                                CronTriggerType triggerType = (CronTriggerType)trigger.TriggerType;
                                triggerTypeMessage = triggerType.CronExpression;
                            }
                            else if (trigger.TriggerType.Code == "simple")
                            {
                                SimpleTriggerType triggerType = (SimpleTriggerType)trigger.TriggerType;
                                triggerTypeMessage = GetSimpleTriggerTypeMessage(triggerType);
                            }
                            ListViewItem item = new ListViewItem(new[]
                             {
                                 jobName,
                                 jobGroupName,
                                 triggerName,
                                 trigger.GroupName,
                                 triggerTypeMessage,
                                 startDate,
                                 //endDate,
                                 previousFireDate,
                                 nextFireDate,
                                 trigger.Status.ToString()
                             });
                            listView_RunningJobs.Items.Add(item);
                        }
                    }
                }
                for (int i = 0; i < listView_RunningJobs.Columns.Count; i++)
                {
                    listView_RunningJobs.Columns[i].Width = -1;
                }
                this.listView_RunningJobs.EndUpdate();
                int timer_was = timer_Refresh_Running_Jobs.Interval;
                timer_Refresh_Running_Jobs.Interval = timer_was + 1;
                timer_Refresh_Running_Jobs.Interval = timer_was;

                timer_Refresh_Running_Jobs.Start();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private string GetSimpleTriggerTypeMessage(SimpleTriggerType simpleTriggerType)
        {
            string triggerTypeMessage = "repeat";
            if (simpleTriggerType.RepeatCount != -1)
            {
                triggerTypeMessage += simpleTriggerType.RepeatCount + " times ";
            }
            triggerTypeMessage += "every ";

            double diff = simpleTriggerType.RepeatInterval;
            var parts = new[,]
            {
                {
                    "day",
                    "days",
                    "86400000"//1000*60*60*24
                },
                {
                    "hour",
                    "hours",
                    "3600000"//1000*60*60
                },
                {
                    "minute",
                    "min",
                    "6000"//1000*60
                },
                {
                    "second",
                    "sec",
                    "1000"//1000
                }
            };
            List<string> messagesParts = new List<string>();
            for (int i = 0; i < parts.GetLongLength(0); i++)
            {

                string multiplier = parts[i, 2];
                var currentPartValue = Math.Floor(diff / Convert.ToDouble(multiplier));
                diff -= currentPartValue * Convert.ToDouble(multiplier);
                if (currentPartValue == 1)
                {
                    messagesParts.Add(parts[i, 0]);
                }
                else if (currentPartValue > 1)
                {
                    messagesParts.Add(currentPartValue + " " + parts[i, 1]);
                }
            }
            triggerTypeMessage += string.Join(", ", messagesParts.ToArray());
            return triggerTypeMessage;
        }

        private void addJobNodes(TreeNode jobsNode)
        {
            string group = jobsNode.Parent.Text;
            var groupMatcher = GroupMatcher<JobKey>.GroupEquals(group);
            var jobKeys = _schedulerProvider.Scheduler.GetJobKeys(groupMatcher);
            foreach (var jobKey in jobKeys)
            {
                try
                {
                    IJobDetail detail = _schedulerProvider.Scheduler.GetJobDetail(jobKey);
                    JobNode jobNode = new JobNode(detail);
                    jobsNode.Nodes.Add(jobNode);
                    addTriggerNodes(jobNode);
                }
                catch (Exception ex)
                {
                    jobsNode.Nodes.Add(string.Format("Unknown Job Type ({0})", jobKey.Name));
                }
            }
        }

        private void addTriggerNodes(TreeNode treeNode)
        {
            TreeNode triggersNode = treeNode.Nodes.Add("Triggers");
            var triggers = _schedulerProvider.Scheduler.GetTriggersOfJob(new JobKey(treeNode.Text, treeNode.Parent.Parent.Text));
            foreach (var trigger in triggers)
            {
                TriggerNode node = new TriggerNode(trigger);
                triggersNode.Nodes.Add(node);
            }
        }

        private void jobDetailsToggle(bool isVisible)
        {
            if (isVisible == false)
            {
                pnlDetails.Controls.Clear();
            }
        }

        //private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    using (ServerConnectForm form = new ServerConnectForm())
        //    {
        //        form.ShowDialog();
        //        if (!form.Cancelled)
        //        {
        //            try
        //            {
        //                QuartzScheduler scheduler = new QuartzScheduler(form.Server, form.Port, form.Scheduler);
        //                serverConnectStatusLabel.Text = string.Format("Connected to {0}", scheduler.Address);
        //                jobsToolStripMenuItem.Enabled = true;
        //            }
        //            catch (SocketException ex)
        //            {

        //            }
        //        }
        //        form.Close();
        //    }
        //}

        private void addJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddJobForm jobForm = new AddJobForm();
            jobForm.ShowDialog();
            if (jobForm.JobDetail != null && jobForm.Trigger != null)
            {
                _schedulerProvider.Scheduler.ScheduleJob(jobForm.JobDetail, jobForm.Trigger);
                loadJobGroups();
                loadRunningJobs();
            }
        }

        private void timer_Refresh_Running_Jobs_Tick(object sender, EventArgs e)
        {
            loadRunningJobs();
        }

        private void addAssemblyMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            dialog.Filter = "Assemblies (*.dll)|*.dll";
            dialog.ShowDialog();
            string fileName = Path.GetFileName(dialog.FileName);
            AssemblyRepository.AddAssembly(fileName);
        }

        private void deleteAssemblyMenuItem_Click(object sender, EventArgs e)
        {
            using (DeleteAssembliesForm form = new DeleteAssembliesForm())
            {
                form.ShowDialog();
                form.Close();
            }
        }

        private void btnRunJobNow_Click(object sender, EventArgs e)
        {
            JobNode node = (JobNode)jobGroupsTreeView.SelectedNode;
            _schedulerProvider.Scheduler.TriggerJob(node.Detail.Key);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            TriggerNode triggerNode = (TriggerNode)jobGroupsTreeView.SelectedNode;
            if (_schedulerProvider.Scheduler.GetTriggerState(triggerNode.Trigger.Key) == TriggerState.Paused)
            {
                _schedulerProvider.Scheduler.ResumeTrigger(triggerNode.Trigger.Key);
            }
            else
            {
                _schedulerProvider.Scheduler.PauseTrigger(triggerNode.Trigger.Key);
            }
            setPauseButtonText();
        }

        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = jobGroupsTreeView.SelectedNode;
            if (selectedNode is JobNode)
            {
                JobNode node = (JobNode)jobGroupsTreeView.SelectedNode;
                _schedulerProvider.Scheduler.DeleteJob(node.Detail.Key);
                jobGroupsTreeView.SelectedNode.Remove();
                loadRunningJobs();
            }
            var triggerNode = selectedNode as TriggerNode;
            if (triggerNode != null)
            {
                _schedulerProvider.Scheduler.UnscheduleJob(triggerNode.Trigger.Key);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TriggerNode node = (TriggerNode)jobGroupsTreeView.SelectedNode;
            AddJobForm form = new AddJobForm(node);
            form.ShowDialog();
            if (form.JobDetail != null && form.Trigger != null)
            {
                _schedulerProvider.Scheduler.RescheduleJob(node.Trigger.Key, form.Trigger);
                loadJobGroups();
            }
        }

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    _schedulerProvider.Scheduler.Start();
        //}

        //private void btnShutdown_Click(object sender, EventArgs e)
        //{
        //    _schedulerProvider.Scheduler.Shutdown(false);
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.txtJobName.Text = string.Empty;
            this.txtJobGroup.Text = string.Empty;
            this.cboState.SelectedIndex = 0;
            loadRunningJobs();
        }

        private void listView_RunningJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView_RunningJobs.FocusedItem != null)
            {
                string state = this.listView_RunningJobs.FocusedItem.SubItems[8].Text;
                if (state == ActivityStatus.Active.ToString())
                {
                    this.pauseToolStripMenuItem1.Enabled = true;
                    this.resumeToolStripMenuItem1.Enabled = false;
                }
                else if (state == ActivityStatus.Paused.ToString())
                {
                    this.pauseToolStripMenuItem1.Enabled = false;
                    this.resumeToolStripMenuItem1.Enabled = true;
                }
            }
        }

        private void pauseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).FocusedItem;
            string triggerName = item.SubItems[2].Text;
            string triggerGroup = item.SubItems[3].Text;
            _schedulerProvider.Scheduler.PauseTrigger(new TriggerKey(triggerName, triggerGroup));
            item.SubItems[8].Text = ActivityStatus.Paused.ToString();
        }

        private void resumeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListViewItem item = ((ListView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).FocusedItem;
            string triggerName = item.SubItems[2].Text;
            string triggerGroup = item.SubItems[3].Text;
            _schedulerProvider.Scheduler.ResumeTrigger(new TriggerKey(triggerName, triggerGroup));
            item.SubItems[8].Text = ActivityStatus.Active.ToString();
        }

        private void listView_RunningJobs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView_RunningJobs.Columns[e.Column].Tag == null)
            {
                listView_RunningJobs.Columns[e.Column].Tag = true;
            }
            var tabK = (bool)listView_RunningJobs.Columns[e.Column].Tag;
            listView_RunningJobs.Columns[e.Column].Tag = !tabK;
            listView_RunningJobs.ListViewItemSorter = new ListViewSort(e.Column, listView_RunningJobs.Columns[e.Column].Tag);
            //指定排序器并传送列索引与升序降序关键字    
            listView_RunningJobs.Sort();//对列表进行自定义排序 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadRunningJobs();
            string jobName = this.txtJobName.Text.Trim();
            string jobGroup = this.txtJobGroup.Text.Trim();
            string state = this.cboState.SelectedItem.ToString();
            StringBuilder sbWhere = new StringBuilder();
            if (!string.IsNullOrEmpty(jobName))
            {
                sbWhere.Append("[Job Name] like '%" + jobName + "%' ");
            }
            if (!string.IsNullOrEmpty(jobGroup))
            {
                if (!string.IsNullOrEmpty(sbWhere.ToString()))
                {
                    sbWhere.Append("And [Job Group] like '%" + jobGroup + "%' ");
                }
                else
                {
                    sbWhere.Append("[Job Group] like '%" + jobGroup + "%' ");
                }
            }
            if (!string.IsNullOrEmpty(state))
            {
                if (!string.IsNullOrEmpty(sbWhere.ToString()))
                {
                    sbWhere.Append("And [State]='" + state + "' ");
                }
                else
                {
                    sbWhere.Append("[State]='" + state + "' ");
                }
            }

            DataTable dtLv = LvToDataTable(listView_RunningJobs);
            DataRow[] arrayRows = dtLv.Select(sbWhere.ToString());
            DataTable newdt = dtLv.Clone();
            for (int i = 0; i < arrayRows.Length; i++)
            {
                newdt.ImportRow(arrayRows[i]);
            }
            DtToListView(newdt);
        }

        /// <summary>
        /// ListView 轉換成DataTable
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        protected static DataTable LvToDataTable(ListView lv)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                dt.Columns.Add(lv.Columns[i].Text);
            }
            for (int j = 0; j < lv.Items.Count; j++)
            {
                dr = dt.NewRow();
                for (int k = 0; k < lv.Columns.Count; k++)
                {
                    dr[k] = lv.Items[j].SubItems[k].Text;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// DataTable 轉換成ListView
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected void DtToListView(DataTable dt)
        {
            listView_RunningJobs.Items.Clear();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ListViewItem lvItem = new ListViewItem(dt.Rows[j][0].ToString());
                for (int k = 1; k < dt.Columns.Count; k++)
                {
                    lvItem.SubItems.Add(dt.Rows[j][k].ToString());
                }
                listView_RunningJobs.Items.Add(lvItem);
            }
            listView_RunningJobs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void addEmailStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmailForm emailForm = new AddEmailForm();
            emailForm.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExceptionLogForm exceptionLogForm = new ExceptionLogForm();
            exceptionLogForm.ShowDialog();
        }
    }
}

