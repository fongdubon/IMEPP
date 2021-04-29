using IMEPP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace IMEPP
{
    public partial class FrmCoach : MetroFramework.Forms.MetroForm
    {
        public FrmCoach()
        {
            InitializeComponent();
        }

        private void FrmCoach_Load(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                coachBindingSource.DataSource = dataContext.Coaches.ToList();
            }
            Coach coach = coachBindingSource.Current as Coach;
            if (coach != null && coach.Photo != null)
                pctPhoto.Image = Image.FromFile(coach.Photo);
            else
                pctPhoto.Image = null;
            pnlDatos.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            grdDatos.Enabled = false;
            pnlDatos.Enabled = true;
            pctPhoto.Image = null;
            coachBindingSource.Add(new Coach());
            coachBindingSource.MoveLast();
            txtFirstName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            pnlDatos.Enabled = true;
            grdDatos.Enabled = false;
            txtFirstName.Focus();
            Coach sparePart = coachBindingSource.Current as Coach;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grdDatos.Enabled = true;
            pnlDatos.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            coachBindingSource.ResetBindings(false);
            FrmCoach_Load(sender, e);
        }

        private void grdDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Coach coach = coachBindingSource.Current as Coach;
            if (coach != null && coach.Photo != null)
                pctPhoto.Image = Image.FromFile(coach.Photo);
            else
                pctPhoto.Image = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Archivos JPG|*.jpg|todos los archivos|*.*"

            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pctPhoto.Image = Image.FromFile(ofd.FileName);
                    Coach coach = coachBindingSource.Current as Coach;
                    if (coach != null)
                        coach.Photo = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (DataContext dataContext = new DataContext())
            {
                Coach coach = coachBindingSource.Current as Coach;
                if (coach != null)
                {
                    if (dataContext.Entry<Coach>(coach).State == EntityState.Detached)
                        dataContext.Set<Coach>().Attach(coach);
                    if (coach.Id == 0)
                        dataContext.Entry<Coach>(coach).State = EntityState.Added;
                    else
                        dataContext.Entry<Coach>(coach).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Dato guardado");
                    grdDatos.Refresh();
                    pnlDatos.Enabled = false;
                    grdDatos.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Quieres eliminar?") != DialogResult.OK)
            {
                return;
            }
            using (DataContext dataContext = new DataContext())
            {
                Coach coach = coachBindingSource.Current as Coach;
                if (coach != null)
                {
                    if (dataContext.Entry<Coach>(coach).State == EntityState.Detached)
                        dataContext.Set<Coach>().Attach(coach);

                    dataContext.Entry<Coach>(coach).State = EntityState.Deleted;
                    dataContext.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Dato eliminado");
                    coachBindingSource.RemoveCurrent();
                    pctPhoto.Image = null;
                    pnlDatos.Enabled = false;
                    grdDatos.Enabled = true;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;

                }
            }
        }
    }
}
