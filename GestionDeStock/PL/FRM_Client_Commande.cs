using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeStock.PL
{
    public partial class FRM_Client_Commande : Form
    {
        private dbStockContext db;
        public FRM_Client_Commande()
        {
            InitializeComponent();
            db = new dbStockContext();
        }
        //Foncion pour remplir la datagrid de produit
        public void RemplirDvgProduit()
        {
            db = new dbStockContext();
            foreach (var cl in db.Clients)
            {
                dvgclient.Rows.Add(cl.ID_Client,cl.Nom_Client, cl.Prenom_client,cl.Adresse_Client, cl.Telephone_client, cl.Email_Client,cl.Pays_Client,cl.Ville_Client);
            }

        }

        private void FRM_Client_Commande_Load(object sender, EventArgs e)
        {
            //Remplissage datagrid avec la liste des clients
            RemplirDvgProduit();
        }

        private void dvgclient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Quitter le formulaire 
            Close();
        }
    }
}
