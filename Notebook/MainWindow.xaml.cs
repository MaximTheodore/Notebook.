using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Notebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<book> books = new List<book>();
        static book booki = new book();
        static book selected;
        public MainWindow()
        {
            InitializeComponent();
            books = Seri_deseri.Mydeserial<List<book>>("note.json") ?? new List<book>();
            DateTime time = DateTime.Now;
            date.SelectedDate = time;
            var orderedNumbers = books.OrderBy(n => n.dateTime);
            Note.ItemsSource = orderedNumbers;
            Note.DisplayMemberPath = "Nameof";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Note.SelectedItem != null)
            {
                selected = (book)Note.SelectedItem;
                Nam.Text = selected.Nameof;
                Desc.Text = selected.description;
                Nam.IsEnabled = true;
                Desc.IsEnabled = true;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)//название
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)//описание
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e) //сохранить
        {

            string t = Nam.Text.ToString();
            booki.Nameof = t;
            booki.description = Desc.Text;
            booki.dateTime = (DateTime)date.SelectedDate;
            books.Add(booki);
            Seri_deseri.MySeri(books, "note.json");
            Note.ItemsSource = null;
            Note.ItemsSource = books;
            Desc.Text = null;
            date.Text = null;
            Nam.Text = null;
            Nam.IsEnabled = false;
            Desc.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//del
        {
            books.Remove(Note.SelectedItem as book);
            Seri_deseri.MySeri(books, "note.json");
            Note.ItemsSource = null;
            Note.ItemsSource = books;

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//create
        {
            Nam.Text = null;
            Desc.Text = null;
            date.Text = null;
            Nam.IsEnabled = true;
            Desc.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//update
        {
            int i = Note.SelectedIndex;
            books.Remove(Note.SelectedItem as book);
            string t = Nam.Text.ToString();
            booki.Nameof = t;
            booki.description = Desc.Text;
            booki.dateTime = (DateTime)date.SelectedDate;
            books.Insert(i, booki);
            Seri_deseri.MySeri(books, "note.json");
            Note.ItemsSource = null;
            Note.ItemsSource = books;
           
        }
    }
}
