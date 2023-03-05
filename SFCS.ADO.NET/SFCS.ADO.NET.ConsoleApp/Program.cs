using System;
using System.Collections.Generic;
using System.Data;
using SFCS.ADO.NET.Library;

namespace SFCS.ADO.NET.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();

            var result = connector.ConnectAsync();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);
                var tablename = "networkusers";

                Console.WriteLine("Получаем данные из таблицы " + tablename);
                var data = db.SelectAllCommandReader(tablename);

                if (data != null)
                {
                    var columnList = new List<string>();

                    for (int i = 0; i < data.FieldCount; i++)
                    {
                        var name = data.GetName(i);
                        columnList.Add(name);
                    }

                    for (int i = 0; i < columnList.Count; i++)
                    {
                        Console.WriteLine($"{columnList[i]}\t");
                    }
                    Console.WriteLine();

                    while (data.Read())
                    {
                        for (int i = 0; i < columnList.Count; i++)
                        {
                            var value = data[columnList[i]];
                            Console.WriteLine($"{value}\t");
                        }
                        Console.WriteLine();
                    }
                }



            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            Console.ReadKey();
        }
    }
}
