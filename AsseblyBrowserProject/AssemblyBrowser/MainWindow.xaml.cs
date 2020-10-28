using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using GatherData;
using System.Runtime.Remoting.Messaging;

namespace AssemblyBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string AssemblyPath;
       
        public TreeViewItem treeViewitem;
       
        private Handler handler;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_OpenAssembly(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                AssemblyPath = openFileDialog.FileName;
            handler = new Handler(AssemblyPath);
            OutPutAssembly();
        }
        private void OutPutAssembly()
        {
            TextBox.Text = handler.NameAssembly;
            foreach(Collector value in handler.listTypes)
            {
                treeViewitem = new TreeViewItem();
                treeViewitem.Header = value.type.FullName;
                AssemblyBrowserTreeView.Items.Add(treeViewitem);
                CreateTreeViewNode(value, treeViewitem);
                
            }
        }
        
        private void CreateTreeViewNode(Collector collector,TreeViewItem treeViewItem)
        {            
            foreach (Collector collector1 in collector.subListTypes)
            {
                TreeViewItem treeViewItem1 = new TreeViewItem
                {
                    Header = collector1.type.FullName
                };
                treeViewItem.Items.Add(treeViewItem1);
                CreateTreeViewNode(collector1, treeViewItem1);
            }

            foreach (string value  in collector.listData)
            {
                TreeViewItem treeViewitemsub = new TreeViewItem
                {
                    Header = value
                };
                treeViewItem.Items.Add(treeViewitemsub);
            }
        }


    }
}
