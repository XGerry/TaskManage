using System;
using System.Windows.Forms;
using TaskManage.Core.Domain;
using TaskManage.Core.Domain.TriggerTypes;

namespace TaskManage.Client
{
    public partial class SimpleTriggerDisplay : UserControl
    {
        private readonly TriggerData _triggerData;
        public SimpleTriggerDisplay()
        {
            InitializeComponent();
            this.Load += SimpleTriggerDisplay_Load;
        }

        public SimpleTriggerDisplay(TriggerData triggerData):this()
        {
            _triggerData = triggerData;
        }


        void SimpleTriggerDisplay_Load(object sender, EventArgs e)
        {
            lblDescription.Text = _triggerData.Description;
            lblGroup.Text = _triggerData.GroupName;
            lblName.Text = _triggerData.Name;
            lblStartTime.Text = _triggerData.StartDate.ToString("yyyy/MM/dd HH:mm:ss");
            if (_triggerData.EndDate.HasValue)
            {
                lblEndTime.Text = Convert.ToDateTime(_triggerData.EndDate).ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                lblEndTime.Text = string.Empty;
            }
            if (_triggerData.NextFireDate.HasValue)
            {
                lblNextFireTime.Text = Convert.ToDateTime(_triggerData.NextFireDate).ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                lblNextFireTime.Text = string.Empty;
            }

            if (_triggerData.PreviousFireDate.HasValue)
            {
                lblPreviousFireTime.Text = Convert.ToDateTime(_triggerData.PreviousFireDate).ToString("yyyy/MM/dd HH:mm:ss");
            }
            else
            {
                lblPreviousFireTime.Text = string.Empty;
            }
            SimpleTriggerType triggerType = (SimpleTriggerType)_triggerData.TriggerType;
            lblRepeatCount.Text = triggerType.RepeatCount.ToString();
            lblRepeatInterval.Text = triggerType.RepeatInterval.ToString();
        }


    }
}
