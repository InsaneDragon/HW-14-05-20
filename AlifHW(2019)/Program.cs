using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlifHW_2019_
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 123456789;
            ShowReversedNum(number);
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ShowCountAndSum(list);
            ShowSortedList(new List<string>() { "Svetnie", "Grob", "Grobkhop" });
            ShowUniq(new List<double>() {1,2,3,3,6,2,1,5,5});
            Console.ReadKey();
        }
        static void ShowReversedNum(int number)
        {
            var CharList = number.ToString().ToCharArray();
            var list2 = from l in CharList.Reverse()
                        select l;
            foreach (var item in list2)
            {
                Console.Write(item);
            }
        }
        static void ShowCountAndSum(List<int> list)
        {
            var list1 = from item in list
                        where item > 0
                        select item;
            var list2 = from item in list
                        where item < 0
                        select item;
            Console.WriteLine();
            Console.WriteLine("Count:" + list1.ToList().Count);
            Console.WriteLine("Sum:" + list2.Sum());
        }
        static void ShowSortedList(List<string> list)
        {
            var list2 = from item in list
                        orderby item.Length
                        select item;
            Console.WriteLine("Sorted List:");
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
        }
        static void ShowUniq(List<double> list)
        {
            List<double> Not = new List<double>();
            for (int i = 0; i < list.Count; i++)
            {
                for (int y = 1; y < list.Count; y++)
                {
                    if (list[i]==list[y]&&i!=y)
                    {
                        Not.Add(i);
                        break;
                    }
                }
            }
            foreach (var item in Not)
            {
                list.RemoveAll(x=>x==item);
            }
            if (list.Count > 0)
            {
                Console.WriteLine(list[0]);
            }
        }
    }
}
