using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ConsumingData
{
    //Using attributes to serialize and deserialize xml and json objects.
    [Serializable]
    [DataContract]
    public class Book
    {
        [XmlAttribute]
        [DataMember]
        public string Name { get; set; }
        [XmlAttribute]
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public int TheYearOfPublishing { get; set; }
        [DataMember]
        public int Pages { get; set; }
        [DataMember]
        public string Description { get; set; }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("\nObject serialized");
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("\nObject deserialized");
        }

        

        public Book(string name, string publisher, int theYearOfPublishing, int pages)
        {
            Name = name;
            Publisher = publisher;
            TheYearOfPublishing = theYearOfPublishing;
            Pages = pages;
        }
        public Book(string name, string publisher, int theYearOfPublishing, int pages, string description) : this(name, publisher, theYearOfPublishing, pages)
        {
            Description = description;
        }
        public Book()
        {

        }

        public string GetInfo()
        {
            if (Description == null)
                return $"Title of the book: {Name}\nPublisher: {Publisher}\nThe year of publishing: {TheYearOfPublishing}\nNumber of pages: {Pages}";
            else
                return $"Title of the book: {Name}\nPublisher: {Publisher}\nThe year of publishing: {TheYearOfPublishing}\nNumber of pages: {Pages}\nDescription: {Description}";
        }

        public void PrintInfo() => Console.WriteLine("\n" + GetInfo() + "\n");
    }
}
