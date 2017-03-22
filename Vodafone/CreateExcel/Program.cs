////Будет класс для выполнения программы “Program”.
//using System;
//using System.Collections.Generic;
//using System.Data;
//namespace Vodafone.Controllers
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //заполняем тестовыми данными
//            var myData = new List<DataForTest>
//            {
//                new DataForTest("a1","b1","c1"),
//                new DataForTest("a2","b2","c2"),
//                new DataForTest("a3","b3","c3"),
//                new DataForTest("a4","b4","c4"),
//                new DataForTest("a5","b5","c5")
//            };

//            var ex = new ConvertToDataTable();
//            //ex.ExcelTableLines(myData) - конвертируем наши данные в DataTable
//            //ex.ExcelTableHeader(myData.Count) - формируем данные для Label
//            //template - указываем название нашего файла  - шаблона
//            new Worker().Export(ex.ExcelTableLines(myData), ex.ExcelTableHeader(myData.Count), "template");
//        }
//    }
//}