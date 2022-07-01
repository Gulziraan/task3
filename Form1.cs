using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace task_3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        List<Log> log = new List<Log>();
        List<string> lines = File.ReadAllLines("Logs.txt").ToList();
        List<LogDetails> logD = new List<LogDetails>();
        List<string> logd = File.ReadAllLines("LogDetails.txt").ToList();

        private void Form1_Load_1(object sender, EventArgs e)
        {
            foreach (string line in lines)
            {
                string[] entries = line.Split();
                Log newLog = new Log();
                newLog.Id = Convert.ToInt32(entries[0]);
                newLog.UserId = Convert.ToInt32(entries[1]);
                newLog.EntryId = Convert.ToInt32(entries[2]);
                newLog.Operation = Convert.ToInt32(entries[3]);
                newLog.Date = Convert.ToDateTime(entries[4] + " " + entries[5]);
                newLog.EntityType = Convert.ToInt32(entries[6]);
                log.Add(newLog);
            }
            foreach (string line in logd)
            {
                string[] entries = line.Split();
                LogDetails newLog = new LogDetails();
                newLog.Id = Convert.ToInt32(entries[0]);
                newLog.LogId = Convert.ToInt32(entries[1]);
                newLog.PropertyName = Convert.ToString(entries[2]);
                newLog.NewValue = Convert.ToString(entries[3]);
                newLog.OldValue = Convert.ToString(entries[4]);
                logD.Add(newLog);
            }
            foreach (var logs in log)
            {
                dataGridView1.Rows.Add(logs.Id.ToString(), logs.UserId.ToString(), logs.EntryId.ToString(), Convert.ToString(logs.Operation), logs.Date.ToString("MM-dd-yyyy hh:mm:ss.fff"), Convert.ToString(logs.EntityType));
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (var logss in logD)
            {
                if (logss.LogId == Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells[0].Value))
                    dataGridView2.Rows.Add(logss.Id, logss.LogId, logss.PropertyName, logss.NewValue, logss.OldValue);
            }

        }
    }
}
