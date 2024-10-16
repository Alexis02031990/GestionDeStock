using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.RAP
{
    public partial class FRM_RAPPORT : Form
    {
        public FRM_RAPPORT()
        {
            InitializeComponent();
        }

        private void FRM_RAPPORT_Load(object sender, EventArgs e)
        {

            this.RPAfficher.RefreshReport();
        }
    }
}
