using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace xmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //List для хранения объектов - ООП, Планы компетенции, Компетенции, Планы строки
            List<EduProgram> eduPrograms = new List<EduProgram>(); //ООП

            //Путь до файла xml - уч. программа
            string path = Console.ReadLine();
            //Stream нужен чтобы нормально работать с xml в utf16
            StreamReader reader = new StreamReader(path);
            //Открываем xml по пути
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            //Получаем корень документа "Документ"
            XmlElement root = document.DocumentElement;
            Console.WriteLine("Дата сохранения XML: " + root.GetAttribute("CrWrite"));
            Console.WriteLine("Имя: " + root.GetAttribute("LastName"));
            //Смотрим что под корнем diffgr:diffgram
            foreach (XmlElement sublvl1 in root.ChildNodes)
            {
                //Смотрим что под diffgr:diffgram будет dsMMISDB
                foreach (XmlElement sublvl2 in sublvl1.ChildNodes)
                {
                    //Смотрим полезную нагрузку внутри "Документ/diffgr:diffgram/dsMMISDB"
                    foreach (XmlElement sublvl3 in sublvl2.ChildNodes)
                    {
                        //Первый ChildNodes ООП и он имеет подразделы
                        if (sublvl3.Name == "ООП")
                        {
                            //корневой элемент ООП
                            eduPrograms.Add(new EduProgram(true, sublvl3.GetAttribute("diffgr:id"), "",
                                sublvl3.GetAttribute("Код"), sublvl3.GetAttribute("Шифр"), sublvl3.GetAttribute("Название")));
                        }
                        //Смотрим ООП и все внутренние подразделы для ООП
                        if (sublvl3.ChildNodes != null && sublvl3.Name == "ООП")
                        {
                            foreach (XmlElement sublvl4 in sublvl3.ChildNodes)
                            eduPrograms.Add(new EduProgram(false, sublvl4.GetAttribute("diffgr:id"), sublvl4.GetAttribute("КодРодительскогоООП"),
                               sublvl4.GetAttribute("Код"), sublvl4.GetAttribute("Шифр"), sublvl4.GetAttribute("Название")));
                        }
                    }
                }
             }

            //DocumentCollection document = null;

            //XmlSerializer serializer = new XmlSerializer(typeof(DocumentCollection));

            //StreamReader reader = new StreamReader(path);

            //document = (DocumentCollection)serializer.Deserialize(reader);

            //reader.Close();

            Console.ReadLine();
        }
    }
}
