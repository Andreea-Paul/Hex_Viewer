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
            string path = @"D:\carti\progit.pdf";

            using (FileStream file = File.OpenRead(path))
            {
                byte[] bytes = new byte[16];
                int batch,counter;
                counter= 0;

                do
                {
                    string line=string.Empty;
                    batch = file.Read(bytes, 0, 16);

                    counter++;
                    string counter_hex = Convert.ToString(counter, 16);
                    string hexString = BitConverter.ToString(bytes).Replace("-", " ");
                    
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        if (bytes[i] < 33 || bytes[i] > 126 && bytes[i] < 159)
                        {
                            line += ".";
                        }
                        else
                        {
                            line += (char)bytes[i];
                        }
                    }
                    Console.WriteLine($"{counter_hex}:  {hexString}  {line}");
                }
                while (batch == 16);
            }
        }
    }
}
        
    

