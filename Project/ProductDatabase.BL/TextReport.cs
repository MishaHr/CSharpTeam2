using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ProductDatabase.BL.Reports;
using ProductDatabase.BL.Repositories;

namespace ProductDatabase.BL
{
    public class TextReportSave
    {
        List<Tuple<string, int>> mainColumn = new List<Tuple<string, int>>();
        List<Tuple<string, int>> columnContent = new List<Tuple<string, int>>();

        private const char cellHorizontalLine = '─';
        private const string cellVerticalLine = "│";

        public static string Path { get; set; }

        private int tableSize;

        private string separateLine;

        const int dataWidth = 12;
        const int intWidth = 10;
        const int stringWidth = 16;
        const int numberWidth = 17;

        // Конструктор по замовчуванні створює Звіт у папці Debug
        public TextReportSave()
        {        }

        // Конструктор отримує як параметр стрінг який буде адресою створення Звіту
        public TextReportSave(string @path)
        {
            Path = path;
        }

        // Метод встановлює головні колонки та відповідні довжини
        private void SetFullColumn()
        {
            mainColumn.Clear();
            mainColumn.Add(new Tuple<string, int>("ID", intWidth));
            mainColumn.Add(new Tuple<string, int>("Категорiя", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Виробник", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Модель", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Дата виготовлення", dataWidth));
            mainColumn.Add(new Tuple<string, int>("Термiн придатностi", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Кількість одиниць", intWidth));
            mainColumn.Add(new Tuple<string, int>("Ціна за одиницю", intWidth));
            mainColumn.Add(new Tuple<string, int>("Постачальник", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Телефон постачальника", numberWidth));
            mainColumn.Add(new Tuple<string, int>("Дата поставки", dataWidth));
            mainColumn.Add(new Tuple<string, int>("Номер складу", intWidth));
            mainColumn.Add(new Tuple<string, int>("Короткий опис", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Поле для приміток", stringWidth));
            SetSeparateLine();
        }

        private void SetShortColumn()
        {
            mainColumn.Clear();
            mainColumn.Add(new Tuple<string, int>("ID", intWidth));
            mainColumn.Add(new Tuple<string, int>("Категорiя", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Виробник", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Модель", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Дата виготовлення", dataWidth));
            mainColumn.Add(new Tuple<string, int>("Термiн придатностi", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Короткий опис", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Поле для приміток", stringWidth));
            SetSeparateLine();
        }

        private void SetWarehouseRecordColumn()
        {
            mainColumn.Clear();
            mainColumn.Add(new Tuple<string, int>("ID", intWidth));
            mainColumn.Add(new Tuple<string, int>("Категорiя", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Виробник", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Модель", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Кількість одиниць", intWidth));
            mainColumn.Add(new Tuple<string, int>("Ціна за одиницю", intWidth));
            mainColumn.Add(new Tuple<string, int>("Постачальник", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Дата виготовлення", dataWidth));
            mainColumn.Add(new Tuple<string, int>("Термiн придатностi", stringWidth));
            mainColumn.Add(new Tuple<string, int>("Номер складу", intWidth));
            SetSeparateLine();
        }

        public void SafeFullProductReport()
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var fullReports = reportBuilder.GenerateFullProductReport();

            List<string> textFullProductReports = new List<string>();

            foreach (FullProductReport report in fullReports)
            {
                textFullProductReports.Add(report.ToString());
            }

            Path = @"Звіт.txt";
            SetFullColumn();

            using (StreamWriter report = File.CreateText(Path)) report.WriteLine(separateLine);

            PrintTextReport(mainColumn);

            foreach (string report in textFullProductReports)
            {
                SetAndPrintInfo(report);
            }
        }

        public void SafeFullProductReportBycategory(int categoryId)
        {
            Repository<Category> categoryRepository = new Repository<Category>();
            var categories = categoryRepository.GetAll();

            ReportBuilder reportBuilder = new ReportBuilder();
            var fullReports = reportBuilder.GenerateFullProductReport();

            var filteredList = (
                           from fullReport in fullReports
                           join category in categories on fullReport.Category equals category.CategoryName
                           where category.id == categoryId
                           select fullReport).ToList();

            List<string> textFullProductReports = new List<string>();

            foreach (FullProductReport report in filteredList)
            {
                textFullProductReports.Add(report.ToString());
            }

            string CategoryName = (from category in categories
                                   where category.id == categoryId
                                   select category.CategoryName).FirstOrDefault();

            Path = $@"Звіт по {CategoryName}.txt";
            SetFullColumn();

            using (StreamWriter report = File.CreateText(Path)) report.WriteLine(separateLine);

            PrintTextReport(mainColumn);

            foreach (string report in textFullProductReports)
            {
                SetAndPrintInfo(report);
            }
        }

        public void SafeShortProductReport()
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var shortReports = reportBuilder.GenerateShortProductReport();

            List<string> textShortProductReports = new List<string>();

            foreach (ShortProductReport report in shortReports)
            {
                textShortProductReports.Add(report.ToString());
            }

            Path = @"Короткий звіт.txt";
            SetShortColumn();

            using (StreamWriter report = File.CreateText(Path)) report.WriteLine(separateLine);

            PrintTextReport(mainColumn);

            foreach (string report in textShortProductReports)
            {
                SetAndPrintInfo(report);
            }
        }

        public void SafeWarehouseRecordProductReport()
        {
            ReportBuilder reportBuilder = new ReportBuilder();
            var warehouseRecord = reportBuilder.GenerateWarehouseRecordReport();

            List<string> textWarehouseRecordReports = new List<string>();

            foreach (WarehouseRecordReport report in warehouseRecord)
            {
                textWarehouseRecordReports.Add(report.ToString());
            }

            Path = @"Звіт по складу.txt";
            SetWarehouseRecordColumn();

            using (StreamWriter report = File.CreateText(Path)) report.WriteLine(separateLine);

            PrintTextReport(mainColumn);

            foreach (string report in textWarehouseRecordReports)
            {
                SetAndPrintInfo(report);
            }
        }

        // Метод створює розділяючу лінію для звіту, за допомогою довжини колонок (+Знаки розділу колонок)
        private void SetSeparateLine()
        {
            tableSize = 0;
            for (int i = 0; i < mainColumn.Count; i++) tableSize = tableSize + mainColumn[i].Item2;
            separateLine = new string(cellHorizontalLine, tableSize + mainColumn.Count + 1);
        }

        // Метод приймає стрінг, розподіляє його по відповідним колонкам з відповідними довжнами
        private void SetAndPrintInfo(string text)
        {
            string[] columnStrings = text.Split(';');

            for (int i = 0; i < columnStrings.Length; i++)
                columnContent.Add(new Tuple<string, int>(columnStrings[i], mainColumn[i].Item2));

            PrintTextReport(columnContent);
        }

        // Метод записує у файл Звіт
        private void PrintTextReport(List<Tuple<string, int>> column)
        {            
            bool allowPrint = true;

            string row;
            string columText = "";

            while (allowPrint == true)
            {
                row = cellVerticalLine;
                allowPrint = false;
                for (int i = 0; i < column.Count; i++)
                {
                    if (column[i].Item1.Length <= column[i].Item2)
                    {
                        columText = AlignCentre(column[i].Item1, column[i].Item2);

                        int width = column[i].Item2;

                        if (!IsEmptyString(column[i].Item1))
                        {
                            column.Remove(new Tuple<string, int>(column[i].Item1, column[i].Item2));
                            column.Insert(i, new Tuple<string, int>(SetEmptyString(width), width));
                        }

                    }
                    else
                    {
                        allowPrint = true;
                        columText = CorrectStringPart(column, i);
                        RemoveUsedWords(column,columText, i);
                    }
                    row += AlignCentre(columText, column[i].Item2) + cellVerticalLine;
                }
                using (StreamWriter report = File.AppendText(Path)) report.WriteLine(row);
            }
            using (StreamWriter report = File.AppendText(Path)) report.WriteLine(separateLine);

            columnContent.Clear();

        }


        // Метод визначає частину тексту, яка попаде в колонку
        private string CorrectStringPart(List<Tuple<string, int>> column ,int index)
        {
            string[] words = column[index].Item1.Split(' ');
            int width = column[index].Item2;
            string content;
            if (words[0].Length > width)
                content = WordTransmit(column,index, words[0].Substring(0, width - 1));

            else content = words[0]; 

            for (int i = 1; i < words.Length; i++)
                if (content.Length + words[i].Length + 1 < width) content += " " + words[i];
                else break;
            return content;
        }

        // Метод будує перенос слова, якщо воно більше за розмір колонки
        private string WordTransmit(List<Tuple<string, int>> column, int index, string word)
        {
            string text = column[index].Item1.Substring(column[index].Item2 - 1);
            int width = column[index].Item2;
            column.Remove(new Tuple<string, int>(column[index].Item1, column[index].Item2));
            column.Insert(index, new Tuple<string, int>(word + " -" +  text, width));
            return word + "-";
        }

        // Метод видаляє уже використані елементи з стрінгів , які записані в колонки
        private void RemoveUsedWords(List<Tuple<string, int>> column, string usedPart, int index)
        {
            string subString = column[index].Item1.Remove(0, usedPart.Length + 1);
            int width = column[index].Item2;

            column.Remove(new Tuple<string, int>(column[index].Item1, column[index].Item2));
            column.Insert(index, new Tuple<string, int>(subString, width));

        }

        // Метод центрує текст який передається
        private string AlignCentre(string text, int width)
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }

        // Метод повертає пустий (заповнений пробілами) рядок
        private string SetEmptyString(int width)
        {
            return new string(' ', width);
        }

        // Метод перевіряє чи пустий (заповнений пробілами) рядок
        private bool IsEmptyString(string text)
        {
            for (int i = 0; i < text.Length; i++)
                if (text[i] != ' ') return false;

            return true;
        }
    }
}

    

