using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskManage.Core.Domain;

namespace TaskManage.Client
{
    public partial class NativeJobDetailDisplay : UserControl
    {
        private readonly JobDetailsData _jobDetailsData;

        public NativeJobDetailDisplay()
        {
            InitializeComponent();
            this.Load += NativeJobDetailDisplay_Load;
        }
        public NativeJobDetailDisplay(JobDetailsData jobDetailsData)
            : this()
        {
            this._jobDetailsData = jobDetailsData;
        }
        void NativeJobDetailDisplay_Load(object sender, EventArgs e)
        {
            IDictionary<string, object> jobDetails = _jobDetailsData.JobProperties;
            foreach (var Key in jobDetails.Keys)
            {
                string value = jobDetails[Key].ToString();
                if (Key == "Description")
                {
                    lblDescription.Text = value;
                }
                else if (Key == "Job Group")
                {
                    lblGroup.Text = value;
                }
                else if (Key == "Job type")
                {
                    lblJobType.Text = value;
                }
                else if (Key == "Full name")
                {
                    lblName.Text = value;
                }
            }

            loadJobDataMap(_jobDetailsData.JobDataMap);
        }

        private void loadJobDataMap(IDictionary<object, object> jobDataMaps)
        {
            foreach (var jobDataMap in jobDataMaps)
            {
                //jobDataListView.Items.Add(new ListViewItem(new[] { jobDataMap.Key.ToString(), jobDataMap.Value.ToString() }));
            }
        }
    }
}
