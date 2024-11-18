using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo1411shubenok.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo1411shubenok;

public partial class Catalog : Window
{
    
    public List<Prod> prods = Helper.user11019Context.Prods.Include(x => x.IdManNavigation).ToList();
    public Catalog()
    {
        InitializeComponent();
        updateList();
        if (Helper.isGuest == false)
        {
            fioClient.Text = Helper.currUser.Surname + " " + Helper.currUser.Name + " " + Helper.currUser.Lastname;
        }
        if (Helper.zakaz.ZakazPrs.Count() > 0)
        {
            toZakazBtn.IsVisible = true;
        }
        else
        {
            toZakazBtn.IsVisible = false;
        }
    }

    private void updateList()
    {
        var currProds = prods;

        switch (sort.SelectedIndex)
        {
        case 0:
                currProds = prods.OrderBy(x => x.ItogCost).ToList();
                break;
        case 1:
                currProds = prods.OrderByDescending(x => x.ItogCost).ToList();
                break;
        case 2:
        default:
                break;
        
        }

        switch (filter.SelectedIndex)
        {
            case 0:
                currProds = prods.Where(x => x.CurrDisc < 10).ToList();
                break;
            case 1:
                currProds = prods.Where(x => x.CurrDisc < 15 && x.CurrDisc >=10).ToList();
                break;

            case 2:
                currProds = prods.Where(x => x.CurrDisc >= 15).ToList();
                break;
            case 3:
            default:
                break;
        
        }

        string searchText = poisk.Text ?? "";
        int count = searchText.Split(' ').Length;
        searchText = searchText.ToLower();
        string[] values = new string[count];
        values = searchText.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string s in values)
        {
            if (!string.IsNullOrEmpty(s))
            {
                currProds = prods.Where(x => x.Name.Contains(s)).ToList();

            }
            else
            {
                continue;
            }
        }
        listbox.ItemsSource = currProds;
    }

    private void Sort_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        updateList();
    }
    private void Filter_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        updateList();
    }

    private void Poisk_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        updateList();
    }

    private void MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var product = listbox.SelectedItem as Prod;
        ZakazPr zakazPr = new ZakazPr();
        if (Helper.zakaz.ZakazPrs.Count == 0)
        {
            Helper.zakaz.IdZakaz = Helper.user11019Context.Zakazs.OrderBy(x => x.IdZakaz).LastOrDefault().IdZakaz + 1;
        }
        zakazPr.IdZakazNavigation = Helper.zakaz;
        zakazPr.IdZakaz = Helper.zakaz.IdZakaz;
        zakazPr.IdProdNavigation = product;
        zakazPr.IdProd = product.IdProd;
        zakazPr.Amount = 1;
        Helper.zakaz.ZakazPrs.Add(zakazPr);
       // Helper.user11019Context.ZakazPrs.Add(zakazPr);
      //  Helper.user11019Context.SaveChanges();
        //Helper.user11019Context.SaveChanges();
        Helper.prodsZakaz.Add(product);
        if (Helper.zakaz.ZakazPrs.Count() > 0)
        {
            toZakazBtn.IsVisible = true;
        }
        else
        {
            toZakazBtn.IsVisible = false;
        }
    }

    private void vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
        Helper.prodsZakaz.Clear();
        Helper.user11019Context.Zakazs.Remove(Helper.zakaz);
        Helper.user11019Context.SaveChanges();
        Helper.zakaz = null;
        Helper.currUser = null;
        Helper.role = -1;
    }
}