using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace task_3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EntryId { get; set; }
        public int Operation { get; set; }
        public DateTime Date { get; set; }
        public int EntityType { get; set; }
    }
    public class LogDetails
    {
        public int Id { get; set; }
        public int LogId { get; set; }
        public string PropertyName { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
    }
}
