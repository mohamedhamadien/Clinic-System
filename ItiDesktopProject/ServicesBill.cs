using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinckDB.databaseclincik;


namespace Clicic
{
    public partial class ServicesBill : Form
    {
        public Visit visit { get; set; }
        Model1 context = new Model1();
        public Doctor LoggedUser { get; set; }
        public ServicesBill()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(Quantity2.Text) > 0)
            {
                string[] row = new string[] { Services2.Text, Quantity2.Text, Price2.Text };
                dataGridView1.Rows.Add(row);

            }
        }

        private void ServicesBill_Load(object sender, EventArgs e)
        {
            
            textBox7.Text += LoggedUser.name;
            //LoggedUser.Clinic. = context.Clincs.Where(c => c.clinicID == visit.Clinc.clinicID).Select(C=>C.Services.).FirstOrDefault();
            var a = context.Services.Select(s => s.servcsesname).ToList();
            //string ServiceName = context.Services.Where(c => c.Clinic == visit.Clinc).Select(i => i.servcsesname).FirstOrDefault();
            Services1.Text = a[0];
            string[] row = new string[] { Services1.Text, Quantity1.Text, Price1.Text };
            dataGridView1.Rows.Add(row);

            var services = context.Services.Where(s => s.Clinic.clinicID == LoggedUser.ClinicId).OrderBy(x=>x.ID).Select(i => i.servcsesname).Skip(1).ToArray();
            Services2.Items.AddRange(services);
            }

        private void Services2_SelectedIndexChanged(object sender, EventArgs e)
        {
            float ServiceCost = context.Services.Where(C => C.servcsesname == Services2.Text).Select(i => i.cost).FirstOrDefault();
            Price2.Text = ServiceCost.ToString();
        }
    }
}
