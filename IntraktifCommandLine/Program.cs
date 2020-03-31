using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace IntraktifCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Loker loker = new Loker();
            List<Loker> lokers = new List<Loker>();
            int[] index;
            int jmlData = 0;           
            string data = string.Empty;
            while (data.ToUpper() !="EXIT")
            {  
                string input = Console.ReadLine();
                string[] arrayInput = input.Split(' ');
                string kode = arrayInput[0].ToLower().Trim();
                if (string.IsNullOrWhiteSpace(kode))
                {
                    Console.WriteLine("perintah tidak boleh pakai sepasi");
                }
                else if (kode.Equals("init"))
                {
                    int result = 0;
                    if (arrayInput.Length != 2 || !int.TryParse(arrayInput[1].Trim(), out result ))
                    {
                        Console.WriteLine("inputan data harus bertipe integer dan tidak boleh kosong");
                    }
                    else
                    {
                        jmlData = Convert.ToInt32(arrayInput[1].Trim());
                        lokers = new List<Loker>();
                        Console.WriteLine("Berhasil membuat loker dengan jumlah " + jmlData);
                        for (int i = 0; i < jmlData; i++)
                        {
                            Loker lkr = new Loker() { ID = Convert.ToString(i + 1), Nomor = "", Tipe = "" };
                            lokers.Add(lkr);
                        }
                    }
                    
                }
                else if (kode.Equals("input"))
                {
                    index = new int[jmlData];

                    if (jmlData == 0)
                    {
                        Console.WriteLine("Inputkan jumlah loker terlebih dahulu! ");
                    }
                    else
                    {
                        var found = lokers.FirstOrDefault(x => x.Nomor == "" || x.Tipe == "");                        
                        if (found != null)
                        {
                           // Console.WriteLine("cek jumlah arry "+arrayInput.Length+" ,"+ string.IsNullOrWhiteSpace(arrayInput[2]));
                            if (arrayInput.Length == 3)
                            {
                                if (string.IsNullOrWhiteSpace(arrayInput[1]) || string.IsNullOrWhiteSpace(arrayInput[2]))
                                {
                                    Console.WriteLine("data yang anda inputkan kurang lengkap");
                                }
                                else
                                {
                                    found.Tipe = arrayInput[1];
                                    found.Nomor = arrayInput[2];
                                    Console.WriteLine("Kartu identitas tersipan di loker " + found.ID);
                                }
                            }
                            else
                            {
                                Console.WriteLine("data yang anda inputkan kurang lengkap");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Maaf loker sudah penuh");
                        }
                    }
                }
                else if (kode.Equals("status"))
                {
                    Console.WriteLine("No Loker \t Tipe Identitas \t No Identitas");
                    foreach (Loker l in lokers)
                    {
                        Console.WriteLine(l.ID + " \t\t " + l.Tipe + " \t\t\t " + l.Nomor);
                    }

                }
                else if (kode.Equals("leave"))
                {
                    if (arrayInput.Length == 2 && !string.IsNullOrWhiteSpace(arrayInput[1]))
                    {
                        var found = lokers.FirstOrDefault(x => x.ID == arrayInput[1]);
                        if (found != null)
                        {
                            found.Nomor = "";
                            found.Tipe = "";
                            Console.WriteLine("Loker nomer {0} berhasil dikosongkan", found.ID);
                        }
                        else
                        {
                            Console.WriteLine("Loker nomer {0} tidak ditemukan ", arrayInput[1]);
                        }
                    }else
                    {
                        Console.WriteLine("anda belum menginputkan no Loker yang akan dihapus");
                    }
                }
                else if (kode.Equals("search"))
                {
                    if (arrayInput.Length == 2 && !string.IsNullOrWhiteSpace(arrayInput[1]))
                    {
                        List<Loker> found = lokers.FindAll(x => x.Tipe == arrayInput[1]);
                        string listNomor = "";
                        if (found.FirstOrDefault() != null)
                        {
                            foreach (Loker lkr in found)
                            {
                                listNomor += lkr.Nomor + ",";
                            }
                            Console.Write(listNomor);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Tipe Identitas tidak ditemukan");
                        }
                    }
                    else
                    {
                        Console.WriteLine("anda belum memasukkan tipe identitas yang akan dicari");
                    }
                        
                }
                else if (kode.Equals("find"))
                {
                    if (arrayInput.Length == 2 && !string.IsNullOrWhiteSpace(arrayInput[1]))
                    {
                        List<Loker> found = lokers.FindAll(x => x.Nomor == arrayInput[1]);
                        if (found.FirstOrDefault() != null)
                        {
                            string listId = "";
                            foreach (Loker lkr in found)
                            {
                                listId += lkr.ID + ",";
                            }
                            Console.Write(listId);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("No Identitas tidak ditemukan");
                        }
                    }
                    else
                    {
                        Console.WriteLine("anda belum memasukkan no identitas yang ingin di cari");
                    }                        
                }
                else if (kode.Equals("exit"))
                {
                    Console.WriteLine("press any key to close .......");
                }
                else
                {
                    Console.WriteLine("perintah tidak ditemukan");
                }
                data = kode;
            }
           // Console.WriteLine("berhasil membuat loker dengan jumlah {0}",data);
            Console.ReadKey();
        }
    }

}
