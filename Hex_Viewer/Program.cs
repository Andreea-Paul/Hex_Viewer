using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hex_Viewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\carti\text.txt";

            using (FileStream file = File.OpenRead(path))
            {
                byte[] bytes = new byte[16];
                int batch,counter;
                counter= 0;

                do
                {
                    string line=string.Empty;
                    batch = file.Read(bytes, 0, 16);
                    string hex_string=string.Empty;

                    counter++;
                    string counter_hex = Convert.ToString(counter, 16);
                    while (counter_hex.Length < 8)
                    {
                        counter_hex = "0" + counter_hex;
                    }


                    for (int i = 0; i < batch; i++)
                    {
                        string hex = Convert.ToString(bytes[i], 16);
                        hex_string += $" {hex}";
                        if (bytes[i] < 33 || bytes[i] > 126 && bytes[i] < 159)
                        {
                            line += ".";
                        }
                        else
                        {
                            line += (char)bytes[i];
                        }
                    }
                    while (hex_string.Length < 48)
                    {
                        hex_string+= " ";
                    }
                    
                    Console.WriteLine($"{counter_hex}:  {hex_string}  {line}");
                }
                while (batch>0);
            }
        }
    }
}
        
    

