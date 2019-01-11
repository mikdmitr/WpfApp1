using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string myDirectory = Directory.GetCurrentDirectory();


        //Provider=Microsoft.Jet.OLEDB.4.0
        //public static string connstring= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=fur.accdb; Persist Security Info=False;";
        // public static string connstring = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=fur.accdb; Persist Security Info=False;";
        //private DataSet furDataSet = new furDataSet ;

        //public WpfApp1.furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));

        // private OleDbConnection mycon;

        public MainWindow()
        {
            InitializeComponent();
           // mycon = new OleDbConnection(connstring);
           // mycon.Open();

            
        }

       /* private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Привет куку!!!");        }*/

       

        private void Mainform_Closed(object sender, EventArgs e)
        {
           // mycon.Close();


        }



        private void Mainform_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp1.furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            // Загрузить данные в таблицу furniture. Можно изменить этот код как требуется.
            WpfApp1.furDataSetTableAdapters.furnitureTableAdapter furDataSetfurnitureTableAdapter = new WpfApp1.furDataSetTableAdapters.furnitureTableAdapter();
            furDataSetfurnitureTableAdapter.Fill(furDataSet.furniture);
            System.Windows.Data.CollectionViewSource furnitureViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("furnitureViewSource")));
            furnitureViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу room. Можно изменить этот код как требуется.
            WpfApp1.furDataSetTableAdapters.roomTableAdapter furDataSetroomTableAdapter = new WpfApp1.furDataSetTableAdapters.roomTableAdapter();
            furDataSetroomTableAdapter.Fill(furDataSet.room);
            System.Windows.Data.CollectionViewSource roomViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roomViewSource")));
            roomViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу location. Можно изменить этот код как требуется.
            WpfApp1.furDataSetTableAdapters.locationTableAdapter furDataSetlocationTableAdapter = new WpfApp1.furDataSetTableAdapters.locationTableAdapter();
            furDataSetlocationTableAdapter.Fill(furDataSet.location);
            System.Windows.Data.CollectionViewSource locationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("locationViewSource")));
            locationViewSource.View.MoveCurrentToFirst();
            // Загрузить данные в таблицу join. Можно изменить этот код как требуется.
            WpfApp1.furDataSetTableAdapters.joinTableAdapter furDataSetjoinTableAdapter = new WpfApp1.furDataSetTableAdapters.joinTableAdapter();
            furDataSetjoinTableAdapter.Fill(furDataSet.join);
            System.Windows.Data.CollectionViewSource joinViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("joinViewSource")));
            joinViewSource.View.MoveCurrentToFirst();
        }

        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            //furDataSet.room.AcceptChanges();

            //furDataSet.AcceptChanges();
            WpfApp1.furDataSetTableAdapters.roomTableAdapter furDataSetroomTableAdapter = new WpfApp1.furDataSetTableAdapters.roomTableAdapter();
            furDataSetroomTableAdapter.Update(furDataSet.room);
            MessageBox.Show("Данные сохранены");
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            WpfApp1.furDataSetTableAdapters.furnitureTableAdapter furDataSetfurnitureTableAdapter = new WpfApp1.furDataSetTableAdapters.furnitureTableAdapter();
            furDataSetfurnitureTableAdapter.Update(furDataSet.furniture);
            MessageBox.Show("Данные сохранены");
        }

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            WpfApp1.furDataSetTableAdapters.locationTableAdapter furDataSetlocationTableAdapter = new WpfApp1.furDataSetTableAdapters.locationTableAdapter();
            furDataSetlocationTableAdapter.Update(furDataSet.location);
            MessageBox.Show("Данные сохранены");
        }

        private void RoomDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           // roomDataGrid.DataContext
        }

        private void BtnSaveToXMLroom_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            //WpfApp1.furDataSetTableAdapters.roomTableAdapter furDataSetroomTableAdapter = new WpfApp1.furDataSetTableAdapters.roomTableAdapter();
            //furDataSetroomTableAdapter.Update(furDataSet.room);
            furDataSet.room.WriteXml("room.xml");
            MessageBox.Show("Данные выгружены в файл room.xml");

        }

        private void BtnLoadFromXMLroom_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));
            try
            {
                furDataSet.room.Clear();
                furDataSet.room.ReadXml("room.xml");
                //WpfApp1.furDataSetTableAdapters.roomTableAdapter furDataSetroomTableAdapter = new WpfApp1.furDataSetTableAdapters.roomTableAdapter();
                //furDataSetroomTableAdapter.Update(furDataSet.room);
                MessageBox.Show("Данные загружены из файла room.xml");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, проверьте наличие файла room.xml в каталоге программы");
            }            
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            furDataSet furDataSet = ((WpfApp1.furDataSet)(this.FindResource("furDataSet")));

            WpfApp1.furDataSetTableAdapters.joinTableAdapter furDataSetjoinTableAdapter = new WpfApp1.furDataSetTableAdapters.joinTableAdapter();
            furDataSetjoinTableAdapter.Fill(furDataSet.join);
            System.Windows.Data.CollectionViewSource joinViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("joinViewSource")));
            joinViewSource.View.MoveCurrentToFirst();
            MessageBox.Show("Информация в таблице обновлена");
        }
    }
}
