using DemoTest.Context;
using DemoTest.Context.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoTest.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            List<Order> listOrder;
            switch(CurrectUser.User.RoleId)
            {
                case 1:
                    lblRole.Text = "Окно клиента";
                    btnAddOrder.Visible = true;
                    btnAddOrder.Enabled = true;
                    using (var db = new DemoTestDBContext())
                    {
                        listOrder = db.Orders
                            .Include(x => x.Client)
                            .Include(x => x.Worker)
                            .Include(x => x.TypeEquipments)
                            .Include(x => x.Statuses)
                            .Where(x => x.ClientId == CurrectUser.User.Id)
                            .ToList();
                    }
                    break;
                case 2:
                    lblRole.Text = "Окно мастера";
                    using (var db = new DemoTestDBContext())
                    {
                        listOrder = db.Orders
                            .Include(x => x.Client)
                            .Include(x => x.Worker)
                            .Include(x => x.TypeEquipments)
                            .Include(x => x.Statuses)
                            .Where(x => x.WorkerId == CurrectUser.User.Id)
                            .ToList();
                    }
                    break;
                case 3:
                    lblRole.Text = "Окно оператора";
                    using (var db = new DemoTestDBContext())
                    {
                        listOrder = db.Orders
                            .Include(x => x.Client)
                            .Include(x => x.Worker)
                            .Include(x => x.TypeEquipments)
                            .Include(x => x.Statuses)
                            .ToList();
                    }
                    break;
                default:
                    lblRole.Text = "Окно менеджера"; 
                    using (var db = new DemoTestDBContext())
                    {
                        listOrder = db.Orders
                            .Include(x => x.Client)
                            .Include(x => x.Worker)
                            .Include(x => x.TypeEquipments)
                            .Include(x => x.Statuses)
                            .ToList();
                    }
                    break;
            }
            foreach (var order in listOrder)
            {
                AddOrderView(order);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            using (var db = new DemoTestDBContext())
            {
                var order = new Order()
                {
                    CreateOrder = DateTime.Now,
                    TypeEquipmentId = 1,
                    ReasonDefect = "Описание проблемы",
                    StatusId = 1,
                    ModelEquipment = "Made in China",
                    ClientId = CurrectUser.User.Id,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                var control = new OrderView(db.Orders
                    .Include(x => x.Client)
                    .Include(x => x.Worker)
                    .Include(x => x.TypeEquipments)
                    .Include(x => x.Statuses)
                    .FirstOrDefault(x => x.Id == db.Orders.Max(y => y.Id)));
                control.Parent = flowLayoutPanel1;
            }
        }

        public void AddOrderView(Order order)
        {
            var orderControl = new OrderView(order);
            orderControl.Parent = flowLayoutPanel1;
            orderControl.StatusCount += OrderControl_StatusCount;
            CountComplete();
        }
        public void CountComplete()
        {
            int CountComplete = 0;

            foreach (var status in flowLayoutPanel1.Controls)
            {
                if (status is OrderView controlOrder)
                {
                    if (controlOrder.Order.StatusId == 3)
                    {
                        CountComplete++;
                    }
                }
            }
            tssStatusCount.Text = "Статус Выполнен: " + CountComplete.ToString();
        }

        private void OrderControl_StatusCount()
        {
            CountComplete();
        }
    }
}
