using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Threading;
using System.Reflection.PortableExecutable;

namespace AlifHW_2019_
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////////////1
            string word = "hello";
            var CodedWord = Code(word);
            Console.Write("Coded:"+CodedWord);
            Console.WriteLine();
            ////////////////////////////////////////////2
            var UnCodeLetters = UnCode(CodedWord);
            Console.Write("Unccoded:"+UnCodeLetters);
            Console.WriteLine();
            ////////////////////////////////////////////3
            string Dirt = "fgv2hbk4lf;11+dasd1vk56";
            var Clear=CleanString(Dirt);
            Console.WriteLine(Dirt+" => "+Clear[3]);
            Console.WriteLine($"Cause {Clear[0]} {Clear[2]} {Clear[1]} = {Clear[3]}");
            ////////////////////////////////////////////4
            string Camel = "camelCase";
            var list1 = Camel.Select(x=>x.ToString());
            var x = 0;
            var list = list1.Select(x => char.IsUpper(char.Parse(x))?" "+x:x);
            foreach (var item in list)
            {
                Console.Write(item);
            }
        }
        static string Code(string word)
        {
            List<char> Alphabet = new List<char>() { '0', 'a', 'e', 'i', 'o', 'u', 'y' };
            var list = word.ToArray().Select(x => Alphabet.Contains(x) ? char.Parse(Alphabet.IndexOf(x).ToString()) : x);
            StringBuilder code = new StringBuilder();
            foreach (var item in list)
            {
                code.Append(item);
            }
            word = code.ToString();
            return word;
        }
        static string UnCode(string word)
        {
            int isNum = 0;
            List<char> Alphabet = new List<char>() { '0', 'a', 'e', 'i', 'o', 'u', 'y' };
            var list = word.ToArray().Select(x => int.TryParse(x.ToString(), out isNum) ? char.Parse(Alphabet[isNum].ToString()) : x);
            StringBuilder code = new StringBuilder();
            foreach (var item in list)
            {
                code.Append(item);
            }
            word = code.ToString();
            return word;
        }
        static List<string> CleanString(string word)
        {
            int first = 0;
            List<char> symbols = new List<char>() { '+', '-', '/', '*' };
            var list = from item in word
                       where int.TryParse(item.ToString(), out first) || symbols.Contains(item)
                       select item;
            var Symbol = from item in list
                         where symbols.Contains(item)
                         select item;
            var SymbolIndex = list.ToList().IndexOf(Symbol.ToArray()[0]);
            var FirstNum = from item in list
                           where list.IndexOf(item) < SymbolIndex
                           select item;
            var SecondNum = from item in list
                            where list.IndexOf(item) > SymbolIndex
                            select item;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (var item in FirstNum)
            {
                stringBuilder.Append(item);
            }
            foreach (var item in SecondNum)
            {
                stringBuilder2.Append(item);
            }
            double result = 0;
            int firstnum = int.Parse(stringBuilder.ToString());
            int secondnum = int.Parse(stringBuilder2.ToString());
            char action = Symbol.ToArray()[0];
            switch (action)
            {
                case '-': result = firstnum - secondnum; break;
                case '*': result = firstnum * secondnum; break;
                case '/': result = firstnum / secondnum; break;
                case '+': result = firstnum + secondnum; break;
            }
            return new List<string>() { firstnum.ToString(), secondnum.ToString(),action.ToString(), result.ToString() };
        }
    }
}
