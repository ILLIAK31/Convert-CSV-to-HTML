using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1_Illia_Karmazin_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] csv = System.IO.File.ReadAllLines(@"../../text.csv");
            int width = 0 , height = 0 , index = 0;
            string tag1 = "<th>" , tag2 = "</th>", Text2 = "\n</table>\n</body>\n</html>" , Text1 = "<!DOCTYPE html>\n<html>\n<head>\n<style>\ntable\n{\nfont-family: arial, sans-serif;\nborder-collapse: collapse;\nwidth: 100%;\n}\ntd, th\n{\nborder: 1px solid #dddddd;\ntext-align: left;\npadding: 8px;\n}\ntr:nth-child(even)\n{\nbackground-color: #dddddd;\n}\n</style>\n</head>\n<body>\n<table>";
            List<string> list = new List<string>();
            foreach (var line1 in csv)
            {
                width = 0;
                var csv2 = line1.Split('/');
                foreach (var line2 in csv2)
                {
                    list.Add(line2);
                    ++width;
                }
                ++height;
            }
            for (int i = 0; i < height; ++i)
            {
                Text1 += "\n<tr>\n";
                for (int j = 0; j < width; ++j, ++index)
                    Text1 += (tag1 + list[index] + tag2);
                Text1 += "\n</tr>";
                if (i == 0)
                {
                    tag1 = "<td>";
                    tag2 = "</td>";
                }
            }
            File.WriteAllText("index.html",(Text1+Text2));
        }
    }
}
