using DemoTest.Context;
using DemoTest.Context.Models;
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

namespace DemoTest.UI
{
    public partial class OrderView : UserControl
    {
        public event Action StatusCount;
        public Order Order { get; set; }
        public OrderView(Order order)
        {
            InitializeComponent();
            this.Order = order;
            Initialites(order);
        }
        public void Initialites(Order order)
        {
            using (var db = new DemoTestDBContext())
            {
                cmbMaster.DataSource = db.Users.Where(x => x.RoleId == 2).ToList();
                cmbMaster.DisplayMember = nameof(User.FIO);
                cmbMaster.ValueMember = nameof(User.Id);
                cmbMaster.SelectedItem = cmbMaster.Items.Cast<User>().FirstOrDefault(x => x.Id == order.WorkerId);

                cmbStatus.DataSource = db.Statuses.ToList();
                cmbStatus.DisplayMember = nameof(Status.Description);
                cmbStatus.ValueMember = nameof(Status.Id);
                cmbStatus.SelectedItem = cmbStatus.Items.Cast<Status>().FirstOrDefault(x => x.Id == order.StatusId);

                cmbTypeEq.DataSource = db.TypeEquipments.ToList();
                cmbTypeEq.DisplayMember = (nameof(TypeEquipment.Title));
                cmbTypeEq.ValueMember = nameof(TypeEquipment.Id);
                cmbTypeEq.SelectedItem = cmbTypeEq.Items.Cast<TypeEquipment>().FirstOrDefault(x => x.Id == order.TypeEquipmentId);

                txtModel.Text = order.ModelEquipment;
                txtDefect.Text = order.ReasonDefect;
                txtZapchasty.Text = order.Zapchasty;
                lblDate.Text = order.CreateOrder.ToString();
                txtNomer.Text = order.Id.ToString();
                lblFio.Text = order.Client.FIO;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new DemoTestDBContext())
            {
                var order = db.Orders.FirstOrDefault(x => x.Id == Order.Id);

                if(order != null)
                {
                    order.CreateOrder = DateTime.Parse(lblDate.Text);
                    order.ModelEquipment = txtModel.Text;
                    order.ReasonDefect = txtDefect.Text;
                    order.Zapchasty = txtZapchasty.Text;
                    order.StatusId = ((Status)cmbStatus.SelectedItem).Id;
                    order.TypeEquipmentId = ((TypeEquipment)cmbTypeEq.SelectedItem).Id;
                    if(cmbMaster.SelectedItem != null)
                    {
                        order.WorkerId = ((User)cmbMaster.SelectedItem).Id;
                        if(order.StatusId <= 2)
                        {
                            order.StatusId = 2;
                            cmbStatus.SelectedItem = cmbStatus.Items.Cast<Status>().FirstOrDefault(x => x.Id == 2);
                        }
                    }
                }
                db.SaveChanges();
                this.Order = order;
                StatusCount?.Invoke();
            }
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtModel.Text) &&
                !string.IsNullOrEmpty(txtDefect.Text);
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            txtModel.Enabled = CurrectUser.User.RoleId == 1;
            txtDefect.Enabled = CurrectUser.User.RoleId == 1;
            cmbTypeEq.Enabled = CurrectUser.User.RoleId == 1;
            txtZapchasty.Enabled = CurrectUser.User.RoleId == 2;
            cmbStatus.Enabled = CurrectUser.User.RoleId == 3;
            cmbMaster.Enabled = CurrectUser.User.RoleId == 3;
        }
    }
}
