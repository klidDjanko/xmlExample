using System;
using System.Xml.Serialization;

namespace xmlExample
{
    /*Попытки мучения с Deserialize*/


    [Serializable()]
    public class dsMMISDB
    {
        [XmlArray("ООП")]
        [XmlArrayItem("ООП", typeof(OOP))]
        public OOP oop { get; set; }
    }

    [Serializable()]
    public class OOP
    {
        [XmlElement("id")]
        public string id { get; set; }

        [XmlElement("Код")]
        public string Code { get; set; }

        [XmlElement("Шифр")]
        public string Code2 { get; set; }
    }


    [Serializable()]
    [XmlRoot("Документ")]
    public class DocumentCollection
    {
        [XmlArrayItem("ООП")]
        [XmlArray("ООП")]
        public OOP oop { get; set; }
    }
}
