using DevExpressCheckedListBoxControl.modelado;
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

namespace DevExpressCheckedListBoxControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        private async void getData()
        {
            using (AdventureWorksDW2017Entities entities = new AdventureWorksDW2017Entities())
            {
                checkedListBoxControl1.DataSource = await entities.DimPromotion.ToListAsync();
                checkedListBoxControl1.DisplayMember = "EnglishPromotionName";
                checkedListBoxControl1.ValueMember = "PromotionKey";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<DimPromotion> lista = new List<DimPromotion>();

            foreach(var item in checkedListBoxControl1.CheckedItems)
            {
                lista.Add((DimPromotion)item); //add checked items to the list
            }
        }
    }
}
