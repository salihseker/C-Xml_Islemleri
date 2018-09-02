using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XML_Islemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            //xmlOlusturma();
            //listeXmlOlusturma();
            xmlOkuma();
        }


        private static void xmlOlusturma()
        {
            /*
            <?xml version="1.0" encoding="utf-8" standalone="yes"?>
            <Kullanicilar>
              <!--Yorum ekleme v.s.-->
              <Kullanici ID="1">
                <Isim>Salih</Isim>
                <Soyisim>ŞEKER</Soyisim>
                <WebSite>www.salihseker.com</WebSite>
              </Kullanici>
            </Kullanicilar>

             */

            XDocument XDoc = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("Kullanicilar",
                new XComment("Yorum ekleme v.s."),
                new XElement("Kullanici", new XAttribute("ID", "1"),
                new XElement("Isim", "Salih"),
                new XElement("Soyisim", "ŞEKER"),
                new XElement("WebSite", "www.salihseker.com")
                )
                )
                );
            XDoc.Save(@"D:\xmlOlusturmaOrnek.xml");

        }

        private static void listeXmlOlusturma()
        {

            List<Kullanici> Kullaniciler = new List<Kullanici>();

            Kullanici k1 = new Kullanici();
            k1.ID = Guid.NewGuid();
            k1.Isim = "Salih";
            k1.Soyisim = "SEKER";
            k1.Numara = 1;
            k1.Github = "github.com/salihseker";

            Kullaniciler.Add(k1);

            Kullanici k2 = new Kullanici();
            k2.ID = Guid.NewGuid();
            k2.Isim = "Kerami";
            k2.Soyisim = "Ozsoy";
            k2.Numara = 2;
            k2.Github = "github.com/keramiozsoy";

            Kullaniciler.Add(k2);

            XDocument Doc = new XDocument(
                new XDeclaration("1.1", "UTF-8", "yes"),
                new XElement("Kullanciciler", Kullaniciler.Select(I =>
                            new XElement("Kullanici",
                                          new XElement("ID", I.ID),
                                          new XElement("Isim", I.Isim),
                                          new XElement("Soyisim", I.Soyisim),
                                          new XElement("Numara", I.Numara),
                                          new XElement("Github", I.Github)
                                     )
                                )
                            )
                );

            Doc.Save(@"D:\Kullanicilar.xml");

        }

        private static void xmlOkuma()
        {

            XDocument docOku = XDocument.Load(@"D:\Kullanicilar.xml");//xml XDocument nesnesine yükleniyor
            List<XElement> okunanXElement = docOku.Descendants("Kullanici").ToList();//Node ların adının Kullanici olduğu belirtiliyor.

            foreach (var item in okunanXElement)//Okunan Nodların içerikleri ekrana yazdırılıyor
            {
                Console.WriteLine("ID : " + item.Element("ID").Value);
                Console.WriteLine("Isim : " + item.Element("Isim").Value);
                Console.WriteLine("Soyisim : " + item.Element("Soyisim").Value);
                Console.WriteLine("Numara : " + item.Element("Numara").Value);
                Console.WriteLine("Github : " + item.Element("Github").Value);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

    }
}
