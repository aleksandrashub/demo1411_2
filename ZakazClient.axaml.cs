using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo1411shubenok.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Collections.Generic;
using System.Linq;

namespace demo1411shubenok;

public partial class ZakazClient : Window
{
    
    public ZakazClient()
    {
        InitializeComponent();
        updateKorz();
    }
    private void updateKorz()
    {
        var list = Helper.user11019Context.ZakazPrs
               .Include(x => x.IdZakazNavigation)
               .Include(x => x.IdProdNavigation);

        listBox.ItemsSource = list;
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        var prod = listBox.SelectedItem as Prod;
        ZakazPr zakazPr = Helper.user11019Context.ZakazPrs.Where(x => x.IdProd == prod.IdProd).LastOrDefault();
        Helper.user11019Context.ZakazPrs.Remove(zakazPr);
        Helper.zakaz.ZakazPrs.Remove(zakazPr);
        Helper.user11019Context.SaveChanges();
        updateKorz();
    }

    private void min_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        var prod = Helper.user11019Context.Prods.FirstOrDefault(x => x.IdProd == ind);
        ZakazPr zakazPr = Helper.zakaz.ZakazPrs.FirstOrDefault(x => x.IdProd == ind && x.IdZakaz == Helper.zakaz.IdZakaz);
        zakazPr.Amount -= 1;
        Helper.user11019Context.ZakazPrs.Where(x => x.IdProd == prod.IdProd).LastOrDefault().Amount = zakazPr.Amount;
        if (zakazPr.Amount == 0)
        {
            Helper.zakaz.ZakazPrs.Remove(zakazPr);
            Helper.user11019Context.ZakazPrs.Remove(zakazPr);
            Helper.user11019Context.SaveChanges();
        }
        /* if (Helper.zakaz.ZakazPrs.Count() == 0)
         {
             Helper.user11019Context.ZakazPrs.Remove(zakazPr);
             Helper.user11019Context.SaveChanges();
         }*/

        updateKorz();
    }

    private void plus_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        var prod = Helper.user11019Context.Prods.FirstOrDefault(x => x.IdProd == ind);
        ZakazPr zakazPr = Helper.zakaz.ZakazPrs.FirstOrDefault(x => x.IdProd == ind && x.IdZakaz == Helper.zakaz.IdZakaz);
        if (zakazPr.Amount.Value < Helper.user11019Context.Prods.Where(x => x.IdProd == zakazPr.IdProd).LastOrDefault().QuanSkl)
        {
            zakazPr.Amount += 1;
        }
        else
        {
        }
        Helper.user11019Context.ZakazPrs.Where(x => x.IdProd == zakazPr.IdProd).LastOrDefault().Amount = zakazPr.Amount;
        updateKorz();
    }
}