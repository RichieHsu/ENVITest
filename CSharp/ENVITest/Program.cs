using Mustache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ENVITest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            string templatePath = @"template/templateA0401.txt";

            String templateA0401 = File.ReadAllText(templatePath);

            HtmlFormatCompiler compiler = new HtmlFormatCompiler();
            Generator generator = compiler.Compile(templateA0401);

            InvoiceA0401 InvoiceA0401 = new InvoiceA0401();

            InvoiceA0401.InvoiceNumber = "QE00000000";
            InvoiceA0401.InvoiceDate = "20171019";
            InvoiceA0401.InvoiceTime = "16:20:17";
            InvoiceA0401.SellerIdentifier = "1234567890";
            InvoiceA0401.SellerName = "家裡蹲";
            InvoiceA0401.BuyerIdentifier = "0123456789";
            InvoiceA0401.BuyerName = "廁所蹲";
            InvoiceA0401.GroupMark = "*";
            InvoiceA0401.DonateMark = "0";

            InvoiceA0401.InvoiceType = "07";

            InvoiceA0401.SalesAmount = "0";
            InvoiceA0401.TaxType = "1";
            InvoiceA0401.TaxRate = "0.05";
            InvoiceA0401.TaxAmount = "5";
            InvoiceA0401.DiscountAmount = "0";
            InvoiceA0401.TotalAmount = "105";
            InvoiceA0401.DiscountAmount = "0";

            InvoiceA0401.ProductItems = new List<InvoiceA0401ProductItem>();

            InvoiceA0401ProductItem productItem = new InvoiceA0401ProductItem();

            productItem.Description = "測試品項";
            productItem.Quantity = "1";
            productItem.Unit = "個";
            productItem.UnitPrice = "100";
            productItem.Amount = "100";
            productItem.SequenceNumber = "1";

            InvoiceA0401.ProductItems.Add(productItem);            

            string resultXML = generator.Render(new
            {
                InvoiceA0401 = InvoiceA0401
            });


            //驗證產出的XML是否符合xsd的規範
            XmlReaderSettings xmlReadersettings = new XmlReaderSettings();
            xmlReadersettings.Schemas.Add("urn:GEINV:eInvoiceMessage:A0401:3.1",@"EInvoiceXSD/v31/A0401.xsd");
            xmlReadersettings.ValidationType = ValidationType.Schema;

            XmlReader reader = XmlReader.Create(new StringReader(resultXML), xmlReadersettings);
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(reader);
                Console.Out.WriteLine(String.Format("XML產出完成"));
                System.Diagnostics.Debug.WriteLine("XML產出完成");
                System.Diagnostics.Debug.WriteLine(resultXML);

            }
            catch (XmlSchemaValidationException ex)
            {
                Console.Out.WriteLine(String.Format("<p>XML驗證錯誤: {0}</p>", ex.Message));
                System.Diagnostics.Debug.WriteLine(String.Format("<p>XML驗證錯誤: {0}</p>", ex.Message));
            }

            Console.Out.WriteLine(resultXML);
            Console.Out.WriteLine();
            Console.Out.WriteLine("按任意健結束...");
            Console.ReadKey();
            //System.Threading.Thread.Sleep(2000);

        }


    }
}
