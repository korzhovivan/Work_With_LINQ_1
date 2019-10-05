using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
namespace LINQ
{
    class Program
    {

        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataContext dc = new DataContext(cs);
            ex1(dc);
            

            Console.ReadKey();
        }

        public static void ex1(DataContext dc)
        {
            var select = from item in dc.GetTable<Item>()
                         select item;

            foreach (var item in select)
            {
                Console.WriteLine(item.Id + "--" + item.Title + "--" + item.Categoty + "--" + item.Weight + "--" + item.Price);
            }
        }
        public static void ex2(DataContext dc)
        {
            var select = dc.GetTable<Item>().Where(item => item.Weight > 1).Count();

            Console.Write(select);
        }
        public static void ex3(DataContext dc)
        {
            var select = from item in dc.GetTable<Item>()
                         group item by item.Categoty into rez
                         select new { category = rez.Key, Count = rez.Count() };

            foreach (var item in select)
            {
                Console.WriteLine(item.category + ": " + item.Count);
            }
        }
        public static void ex4(DataContext dc)
        {
            string str = @"s____";

            var select = dc.GetTable<Item>().Where(item => SqlMethods.Like(item.Title, str));

            foreach (var item in select)
            {
                Console.WriteLine(item.Id + "--" + item.Title + "--" + item.Title + "--" + item.Weight + "--" + item.Price);
            }
        }
        public static void ex5(DataContext dc)
        {

            var select = dc.GetTable<Item>().Where(item => item.Price < 400).OrderBy(item => item.Title);

            foreach (var item in select)
            {
                Console.WriteLine(item.Id + "--" + item.Title + "--" + item.Title + "--" + item.Weight + "--" + item.Price);
            }
        }
        public static void ex6(DataContext dc)
        {

            var select = (from item in dc.GetTable<Item>()
                          orderby item.Price descending
                          select item).First();


            Console.Write(select.Weight);

        }


    }
}

