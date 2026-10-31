using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManagerTimeTask
{
    public class SimpleAppointment
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public SimpleAppointment(string text, DateTime date)
        {
            Text = text;
            Date = date;
        }
    }

    public partial class Form1 : Form
    {
        private List<SimpleAppointment> appointmentsList = new List<SimpleAppointment>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtText.Text))
            {
                MessageBox.Show("Please, write something in the text box!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string inputByUtent = txtText.Text;
            DateTime selectedDate = monthCalendar1.SelectionStart;

            SimpleAppointment newAppointment = new SimpleAppointment(inputByUtent, selectedDate);
            appointmentsList.Add(newAppointment);

            txtText.Clear();
            UpdateScreen();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            listCommitments.Items.Clear();
            DateTime selectedDate = monthCalendar1.SelectionStart;

            foreach (var appointment in appointmentsList)
            {
                if (appointment.Date.Date == selectedDate.Date)
                {
                    listCommitments.Items.Add(appointment.Text);
                }
            }
        }
    }
}