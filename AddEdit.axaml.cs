using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using demo1411shubenok.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demo1411shubenok;

public partial class AddEdit : Window
{
    public string path;
    public string destPath;
    public Bitmap bitmap;
    public string filename;


    public List<string> edizmBind = Helper.user11019Context.EdIzms.Select(x => x.EdIzm1).ToList();
    public List<string> categ = Helper.user11019Context.Categs.Select(x => x.Categ1).ToList();
    public List<string> manuf = Helper.user11019Context.Manufs.Select(x => x.Manuf1).ToList();
    public List<string> custs = Helper.user11019Context.Custs.Select(x => x.Cust1).ToList();
    public AddEdit()
    {
        InitializeComponent();
        edizmCmb.ItemsSource = edizmBind;
    }
    public AddEdit(Prod prod)
    {
        InitializeComponent();
        edizmCmb.ItemsSource = edizmBind;
        imgOut.Source = prod.bitmap;
        NameTxt.Text = prod.Name;
        descrTxt.Text = prod.Descr;
        
    }

    private async void img_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var res = await openFileDialog.ShowAsync(this);
        if (res == null) return;
        path = string.Join("", res);
        if (res != null)
        {
            bitmap = new Bitmap(path);
        }
        imgOut.Source = bitmap;
        filename = Path.GetFileName(path);
        destPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Assets";
        
    }
}