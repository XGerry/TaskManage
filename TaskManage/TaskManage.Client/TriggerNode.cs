﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl.Triggers;

namespace TaskManage.Client
{
	public class TriggerNode : TreeNode
	{
		public TriggerNode(ITrigger trigger)
		{
			Text = trigger.Key.Name;
			Trigger = trigger;
		}
		public ITrigger Trigger { get; private set; }
	}
}
