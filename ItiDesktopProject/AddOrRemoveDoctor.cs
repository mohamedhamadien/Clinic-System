using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ItiDesktopProject
{

    public partial class AddOrRemoveDoctor : Form
    {
        Model1 context = new Model1();
        public AddOrRemoveDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrRemoveReceptionist addOrRemoveReceptionist = new AddOrRemoveReceptionist();
            addOrRemoveReceptionist.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Adminstrator adminstrator = new Adminstrator();
            adminstrator.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            try
            {
                doctor.name = FullName.Text;
                doctor.age = Convert.ToInt32(age.Text);
                doctor.percentage = float.Parse(Percentage.Text);
                doctor.AccountantEmail = AccEmail.Text;
                var ClinicName = context.Clincs.Where(u => u.clinic_name == Clinic.Text).Select(i => i).FirstOrDefault();
                doctor.Clinic = ClinicName;
                doctor.Contract = Contract.Text;
                doctor.Email = DocEmail.Text;
                doctor.Gender = gender.Text;
                doctor.Mirtal_Status = Mirtal.Text;
                doctor.phonNumber = Phone.Text;
                var user = context.Usertypes.Where(u => u.UserName == UserID.Text).Select(i => i).SingleOrDefault();
                doctor.UserTypes = user;
                doctor.WorkingHours = WorkingHours.Text;
                ////////////
                context.Doctors.Add(doctor);
                context.SaveChanges();
                ////////////
                FullName.Clear();
                age.Clear();
                Percentage.Clear();
                AccEmail.Clear();
                Contract.Clear();
                DocEmail.Clear();
                Phone.Clear();
                
            }
            catch
            {

            }

           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOrRemoveDoctor_Load(object sender, EventArgs e)
        {
            var users = context.Usertypes.Select(u => u.UserName).ToArray();
            UserID.Items.AddRange(users);

            var Clinics = context.Clincs.Select(u => u.clinic_name).ToArray();
            Clinic.Items.AddRange(Clinics);
        }
    }
}
