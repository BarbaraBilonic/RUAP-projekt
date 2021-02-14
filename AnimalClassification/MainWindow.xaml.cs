using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Animal_Classification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataManager dataManager=new DataManager();
        public MainWindow()
        {
            InitializeComponent();
            

            
            
        }

        private void showMissingDataMessage()
        {
            string message = "You have to fill out all information";
            MessageBox.Show(message);
        }
        private void getTypeButton_Click(object sender, RoutedEventArgs e)
        {
            typeTB.Text = "";

            if (animalNameTB.Text.Length==0)
            {
                showMissingDataMessage();
            }
            else
            {
                
                sendData();
                string type = dataManager.getAnimalType();
                typeTB.Text = type;
                animalNameTB.Clear();
            }


            


        }
        private void sendData()
        {
            string dataItem;
            dataItem = animalNameTB.Text.ToString();
            dataManager.addDataItem(dataItem);
            dataItem = hairCB.Text.ToString();
            dataManager.addDataItem(dataItem);
            dataItem = feathersCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = eggsCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = milkCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = airborneCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = aquaticCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = predatorCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = teethCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = backboneCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = breathCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = venomousCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = finsCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = legsCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = tailCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = domesticCB.Text.ToString();
                dataManager.addDataItem(dataItem);
                dataItem = catsizedCB.Text.ToString();
                dataManager.addDataItem(dataItem);
            }
        }
    }

