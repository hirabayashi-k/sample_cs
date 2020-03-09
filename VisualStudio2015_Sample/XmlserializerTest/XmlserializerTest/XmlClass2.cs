using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlserializerTest
{
    public class XmlClass2
    {
        [XmlRoot("book")]
        public class Book
        {
            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("publised")]
            public DateTime Published { get; set; }

            [XmlArray("authors")]
            [XmlArrayItem("author")]
            public List<Author> Authors { get; set; }
        }

        public class Author
        {
            [XmlElement("authorName")]
            public string AuthorName { get; set; }
        }
    }
}
