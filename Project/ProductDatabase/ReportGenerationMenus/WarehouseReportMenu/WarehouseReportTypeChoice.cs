﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Text;
using System.Threading.Tasks;
using ProductDatabase.ReportGenerationMenus.ShortReportMenu;

namespace ProductDatabase.ReportGenerationMenus.WarehouseReportMenu
{
    internal static class WarehouseReportTypeChoice
    {
        internal static void Show()
        {
            Title = "Меню формування звіту по складу";
            Clear();
            WriteLine("\tФормування звіту про товар");
            WriteLine("1. Сформувати звіт по складу по всіх товарах");
            WriteLine("2. Сформувати звіт по складу по вибраній категорії");
            WriteLine();
            WriteLine("\n9. Повернутися до попереднього меню");
            WriteLine("\n0. Повернутися до головного меню");
            Write("\nВиберіть дію: ");
            Choose();

        }

        internal static void Choose()
        {
            string choice = (ReadLine());
            //Clear();
            switch (choice)
            {
                case "0":
                    MainMenu.Show();
                    break;
                case "1":
                    WarehouseReportOutputChoice.Show();
                    break;
                case "2":
                    WarehouseReportBycategory.Show();
                    break;
                case "9":
                    Back();
                    break;
                default:
                    Show();
                    break;
            }

        }

        internal static void Back()
        {
            ReportGenerationMenu.Show();
        }
    }
}
