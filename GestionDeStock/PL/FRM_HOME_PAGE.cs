﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace GestionDeStock.PL
{
    public partial class FRM_HOME_PAGE : Form
    {
        private dbStockContext db;
        private List<byte[]> cheminsImagesProduits;
        private List<Produit> produitsAvecImages; // Liste des produits avec images et détails
        private int indexImageActuelle = 0;
        private Timer timerDiaporama;
        private Timer timerBackground; // Timer pour l'animation de fond
        private int colorTransitionStep = 0; // Étape de transition de la couleur
        private static Random random = new Random(); // Générateur de couleurs aléatoires

        private Color startColor = Color.Red;  // Couleur de départ
        private Color endColor = Color.Blue;   // Couleur de fin
        private const int maxTransitionSteps = 100; // Nombre total d'étapes de transition

        public FRM_HOME_PAGE()
        {
            InitializeComponent();
            db = new dbStockContext();
            RemplirHistoriqueCommande();
            RemplirProduitsEnStock();
            ChargerImagesProduits();

            // Initialiser le Timer pour le diaporama
            timerDiaporama = new Timer();
            timerDiaporama.Interval = 3000;
            timerDiaporama.Tick += new EventHandler(timerDiaporama_Tick);
            timerDiaporama.Start();

            // Initialiser le Timer pour l'animation du fond
            timerBackground = new Timer();
            timerBackground.Interval = 50; // Changer la couleur toutes les 50 ms pour une animation fluide
            timerBackground.Tick += new EventHandler(timerBackground_Tick);
            timerBackground.Start(); // Démarrer l'animation de fond

            // Afficher les différents types de diagrammes
            AfficherDiagrammeCommandes();       // Produits commandés sous forme de barres
            AfficherDiagrammeStock();           // Produits en stock sous forme de colonnes
            AfficherDiagrammeProduits();        // Produits sous forme de camembert
            AfficherDiagrammeCommandesDoughnut(); // Historique des commandes sous forme de courbe
            AfficherBarreProgressionProduits(); // Barres de progression pour produits vendus/restants
        }

        // Fonction utilitaire pour mélanger deux couleurs
        private Color BlendColors(Color color1, Color color2, float amount)
        {
            int r = (int)(color1.R * (1 - amount) + color2.R * amount);
            int g = (int)(color1.G * (1 - amount) + color2.G * amount);
            int b = (int)(color1.B * (1 - amount) + color2.B * amount);
            return Color.FromArgb(r, g, b);
        }

        // Fonction utilitaire pour générer des couleurs aléatoires
        private int RandomColor()
        {
            return random.Next(0, 256);
        }

        // Méthode pour l'animation de fond
        private void timerBackground_Tick(object sender, EventArgs e)
        {
            // Calculer la proportion actuelle de la transition
            float blendFactor = (float)colorTransitionStep / maxTransitionSteps;

            // Changer la couleur de fond
            this.BackColor = BlendColors(startColor, endColor, blendFactor);

            // Incrémenter l'étape de transition
            colorTransitionStep++;

            // Si la transition est terminée, inverser les couleurs
            if (colorTransitionStep > maxTransitionSteps)
            {
                colorTransitionStep = 0;  // Réinitialiser l'étape
                Color tempColor = startColor;
                startColor = endColor;
                endColor = tempColor;  // Inverser les couleurs pour l'effet de boucle
            }
        }

        // Charger les images des produits pour le diaporama
        private void ChargerImagesProduits()
        {
            // Charger tous les produits en mémoire
            produitsAvecImages = db.Produits
                                   .Where(p => p.Quantite_Produit > 0 && p.Image_Produit != null)
                                   .ToList(); // On récupère les données dans la mémoire ici

            // Si des images existent, charger la première dans le PictureBox
            if (produitsAvecImages.Any())
            {
                AfficherImageProduit(0);
            }
            else
            {
                MessageBox.Show("Aucune image valide trouvée pour les produits.");
            }
        }

        // Afficher une image de produit à un index donné
        private void AfficherImageProduit(int index)
        {
            var produit = produitsAvecImages[index];
            using (MemoryStream ms = new MemoryStream(produit.Image_Produit))
            {
                pbxDiaporama.Image = Image.FromStream(ms);
                pbxDiaporama.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // Timer pour faire défiler les images dans le diaporama
        private void timerDiaporama_Tick(object sender, EventArgs e)
        {
            if (produitsAvecImages.Any())
            {
                // Passer à l'image suivante
                indexImageActuelle = (indexImageActuelle + 1) % produitsAvecImages.Count;
                AfficherImageProduit(indexImageActuelle);
            }
        }

        // Clic sur l'image pour afficher les détails du produit
        private void pbxDiaporama_Click(object sender, EventArgs e)
        {
            if (produitsAvecImages.Any())
            {
                var produit = produitsAvecImages[indexImageActuelle];

                // Créer un nouveau formulaire pour afficher les détails du produit
                FRM_Detail_Produit frmDetails = new FRM_Detail_Produit(produit);
                frmDetails.ShowDialog();
            }
        }

        // Remplir le DataGridView avec l'historique des produits commandés
        private void RemplirHistoriqueCommande()
        {
            var commandes = from c in db.Commandes
                            join dc in db.Detail_Commande on c.ID_Commande equals dc.ID_Commande
                            join p in db.Produits on dc.ID_Produit equals p.Id_Produit
                            select new
                            {
                                CommandeID = c.ID_Commande,
                                Produit = p.Nom_Produit,
                                Quantite = dc.Quantite,
                                Date = c.DATE_Commande
                            };

            dvgHistoriqueCommande.DataSource = commandes.ToList();
        }

        // Remplir le DataGridView avec les produits en stock
        private void RemplirProduitsEnStock()
        {
            var produitsEnStock = from p in db.Produits
                                  where p.Quantite_Produit > 0
                                  select new
                                  {
                                      Produit = p.Nom_Produit,
                                      Quantite = p.Quantite_Produit,
                                      Prix = p.Prix_Produit
                                  };

            dvgCommandes.DataSource = produitsEnStock.ToList();
        }

        // Afficher les produits commandés sous forme de diagramme en barres
        private void AfficherDiagrammeCommandes()
        {
            var commandes = from c in db.Commandes
                            join dc in db.Detail_Commande on c.ID_Commande equals dc.ID_Commande
                            join p in db.Produits on dc.ID_Produit equals p.Id_Produit
                            group dc by p.Nom_Produit into g
                            select new
                            {
                                Produit = g.Key,
                                QuantiteCommandee = g.Sum(dc => dc.Quantite)
                            };

            chartCommandes.Series.Clear();
            chartCommandes.Legends.Clear();

            var seriesBar = new Series("Produits commandés");
            seriesBar.ChartType = SeriesChartType.Bar; // Type Barres
            seriesBar.IsValueShownAsLabel = true;
            chartCommandes.Series.Add(seriesBar);

            foreach (var commande in commandes)
            {
                int pointIndex = seriesBar.Points.AddXY(commande.Produit, commande.QuantiteCommandee);
                var point = seriesBar.Points[pointIndex];
                point.Color = Color.FromArgb(255, RandomColor(), RandomColor(), RandomColor());
            }

            var legend = new Legend("Produits commandés");
            chartCommandes.Legends.Add(legend);
        }

        // Afficher les produits en stock sous forme de diagramme en colonnes
        private void AfficherDiagrammeStock()
        {
            var produitsEnStock = from p in db.Produits
                                  where p.Quantite_Produit > 0
                                  select new
                                  {
                                      Produit = p.Nom_Produit,
                                      Quantite = p.Quantite_Produit
                                  };

            chartStock.Series.Clear();
            chartStock.Legends.Clear();

            var seriesColumn = new Series("Produits en stock");
            seriesColumn.ChartType = SeriesChartType.Column;
            seriesColumn.IsValueShownAsLabel = true;
            chartStock.Series.Add(seriesColumn);

            foreach (var produit in produitsEnStock)
            {
                int pointIndex = seriesColumn.Points.AddXY(produit.Produit, produit.Quantite);
                var point = seriesColumn.Points[pointIndex];
                point.Color = Color.FromArgb(255, RandomColor(), RandomColor(), RandomColor());
            }

            var legend = new Legend("Produits en stock");
            chartStock.Legends.Add(legend);
        }

        // Afficher les produits sous forme de diagramme circulaire (Pie Chart) avec des flèches pour les étiquettes
        private void AfficherDiagrammeProduits()
        {
            var produits = from p in db.Produits
                           where p.Quantite_Produit > 0
                           select new
                           {
                               Produit = p.Nom_Produit,
                               Prix = p.Prix_Produit
                           };

            chartProduits.Series.Clear();
            chartProduits.Legends.Clear();

            var seriesPie = new Series("Prix des Produits");
            seriesPie.ChartType = SeriesChartType.Pie;
            seriesPie.IsValueShownAsLabel = true;
            seriesPie["PieLabelStyle"] = "Outside";  // Afficher les étiquettes à l'extérieur des parts
            seriesPie.BorderWidth = 2;               // Ajouter une bordure visible autour des parts
            chartProduits.Series.Add(seriesPie);

            foreach (var produit in produits)
            {
                int pointIndex = seriesPie.Points.AddXY(produit.Produit, produit.Prix);
                var point = seriesPie.Points[pointIndex];
                point.Color = Color.FromArgb(255, RandomColor(), RandomColor(), RandomColor());
                point.Label = $"{produit.Produit}: {point.YValues[0]:C2}";
                point.LabelForeColor = Color.Black;
            }

            var legend = new Legend("Prix des Produits");
            chartProduits.Legends.Add(legend);

            seriesPie.SmartLabelStyle.Enabled = true;
            seriesPie.SmartLabelStyle.CalloutLineColor = Color.Black;
            seriesPie.SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Underlined;
            seriesPie.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            seriesPie.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
            seriesPie.SmartLabelStyle.MaxMovingDistance = 40;

            chartProduits.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartProduits.ChartAreas[0].Area3DStyle.Inclination = 30;

            // Tooltip pour les infos
            chartProduits.GetToolTipText += (sender, e) =>
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    var point = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    string produitNom = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex].AxisLabel;
                    double prix = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex].YValues[0];
                    e.Text = $"{produitNom}: {prix:C2}";
                }
            };
        }

        // Afficher l'historique des commandes sous forme de DoughnutChart (diagramme en anneau)
        private void AfficherDiagrammeCommandesDoughnut()
        {
            var commandes = from c in db.Commandes
                            group c by c.DATE_Commande into g
                            select new
                            {
                                Date = g.Key,
                                TotalCommandes = g.Sum(c => c.Detail_Commande.Sum(dc => (int?)dc.Quantite) ?? 0)
                            };

            dvgHistoriqueCommande.Series.Clear();
            dvgHistoriqueCommande.Legends.Clear();

            var seriesDoughnut = new Series("Historique Commandes");
            seriesDoughnut.ChartType = SeriesChartType.Doughnut;
            seriesDoughnut.IsValueShownAsLabel = true;
            dvgHistoriqueCommande.Series.Add(seriesDoughnut);

            double totalCommandes = commandes.Sum(c => c.TotalCommandes);

            foreach (var commande in commandes)
            {
                if (commande.TotalCommandes > 0)
                {
                    int pointIndex = seriesDoughnut.Points.AddXY(commande.Date.ToShortDateString(), commande.TotalCommandes);
                    var point = seriesDoughnut.Points[pointIndex];
                    double percentage = (commande.TotalCommandes / totalCommandes) * 100;
                    point.Label = $"{point.AxisLabel}\n{percentage:F2}%";
                    point.ToolTip = $"Date: {commande.Date.ToShortDateString()}\nTotal Commandes: {commande.TotalCommandes}\n{percentage:F2}%";
                }
            }

            var legend = new Legend("Historique Commandes");
            dvgHistoriqueCommande.Legends.Add(legend);

            dvgHistoriqueCommande.ChartAreas[0].AxisX.Title = "Date des Commandes";
            dvgHistoriqueCommande.ChartAreas[0].AxisY.Title = "Quantité Totale Commandée";
        }

        // Afficher un diagramme à barres empilées horizontales pour les produits vendus/restants
        private void AfficherBarreProgressionProduits()
        {
            var produits = from p in db.Produits
                           join dc in db.Detail_Commande on p.Id_Produit equals dc.ID_Produit into prodCommandes
                           from pc in prodCommandes.DefaultIfEmpty()
                           group pc by new { p.Nom_Produit, p.Quantite_Produit } into g
                           select new
                           {
                               Produit = g.Key.Nom_Produit,
                               Vendu = g.Sum(x => x != null ? x.Quantite : 0),
                               Restant = g.Key.Quantite_Produit - g.Sum(x => x != null ? x.Quantite : 0)
                           };

            dvgCommandes.Series.Clear();
            dvgCommandes.Legends.Clear();

            var seriesVendus = new Series("Vendus");
            seriesVendus.ChartType = SeriesChartType.StackedBar;
            seriesVendus.IsValueShownAsLabel = true;
            dvgCommandes.Series.Add(seriesVendus);

            var seriesRestants = new Series("Restants");
            seriesRestants.ChartType = SeriesChartType.StackedBar;
            seriesRestants.IsValueShownAsLabel = true;
            dvgCommandes.Series.Add(seriesRestants);

            foreach (var produit in produits)
            {
                seriesVendus.Points.AddXY(produit.Produit, produit.Vendu);
                seriesRestants.Points.AddXY(produit.Produit, produit.Restant);
            }

            var legend = new Legend("Progression des Produits");
            dvgCommandes.Legends.Add(legend);

            dvgCommandes.ChartAreas[0].AxisY.Title = "Quantité";
            dvgCommandes.ChartAreas[0].AxisX.Title = "Produits";

            dvgCommandes.ChartAreas[0].AxisY.LabelStyle.Angle = -45;
            dvgCommandes.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            dvgCommandes.GetToolTipText += (sender, e) =>
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    var point = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    double total = seriesVendus.Points[e.HitTestResult.PointIndex].YValues[0] + seriesRestants.Points[e.HitTestResult.PointIndex].YValues[0];
                    double percentage = (point.YValues[0] / total) * 100;
                    e.Text = $"{point.AxisLabel}\nQuantité: {point.YValues[0]}\n{percentage:F2}%";
                }
            };
        }
    }
}
