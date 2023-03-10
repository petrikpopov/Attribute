using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace _10._03._2023HM
{
    [Serializable]
    [DataContract]
    public class Phone
    {
        [DataMember]
        public string Name_Phone{ set; get; }
        [DataMember]
        public string Name_Company { set; get; }
        [DataMember]
        public int Price_Phone { set; get; }
        [DataMember]
        public string Date_of_Preparation { set; get; }

        public Phone(string NP, string NC, int PP, string DoP)
        {
            Name_Phone = NP;
            Name_Company = NC;
            Price_Phone = PP;
            Date_of_Preparation = DoP;
        }

        public Phone() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            XmlSerializer xmlSerializer = null;
            FileStream fileStream = null; 
            DataContractJsonSerializer dataContractJson = null;
            Phone phone = new Phone("Apple", "Apple", 45000,"2021");
            Console.WriteLine("1)XML - десериализация объекта");
            Console.WriteLine("2)XML - сериализация объекта");
            Console.WriteLine("3)JSON - сериализация объекта");
            Console.WriteLine("4)JSON - сериализация объекта");
            int p = Convert.ToInt32(Console.ReadLine());
            switch (p)
            {
                case 1:
                    fileStream = new FileStream("../../Phone.xml", FileMode.Open);
                    xmlSerializer = new XmlSerializer(typeof(Phone));
                    phone = (Phone)xmlSerializer.Deserialize(fileStream);
                    Console.WriteLine(phone.Name_Phone + " " + phone.Name_Company + "" + phone.Price_Phone + " " + phone.Date_of_Preparation + " ");
                    fileStream.Close();
                    break;
                case 2:
                    fileStream = new FileStream("../../Phone1.xml", FileMode.Open);
                    xmlSerializer = new XmlSerializer(typeof(Phone));
                    xmlSerializer.Serialize(fileStream, phone);
                    fileStream.Close();
                    break;
                case 3:
                    fileStream = new FileStream("../../Phone1.json", FileMode.Open);
                    dataContractJson = new DataContractJsonSerializer(typeof(Phone));
                    dataContractJson.WriteObject(fileStream, phone);
                    fileStream.Close();
                    break;
                case 4:
                    fileStream = new FileStream("../../Phone.json", FileMode.Open);
                    dataContractJson = new DataContractJsonSerializer(typeof(Phone));
                    phone = (Phone)dataContractJson.ReadObject(fileStream);
                    Console.WriteLine(phone.Name_Phone+" "+phone.Name_Company+" "+phone.Price_Phone+" "+phone.Date_of_Preparation+" ");
                    fileStream.Close();
                    break;

            }
        }
    }
}
