using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Web;
namespace HotelWebSiteFinal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       public string verify(string xmlurl,string xsdurl)
        {
            try
            {
                string output = "";
                XmlSchemaSet sc = new XmlSchemaSet();          //creating the XML Schema Set object
                sc.Add(null, xsdurl);                          //adding the XSD file for checking validation with the XML file

                XDocument doc = XDocument.Load(xmlurl);        //loading the XML file for validation

                doc.Validate(sc, (o, e) =>                       //inline function implementation for validation check
                {
                    if (e.Severity == XmlSeverityType.Error)
                    {
                        output = "Validation Error" + output + e.Message + "</br>";
                    }


                });
                if (output.Length == 0)
                {
                    return "No error";

                }
                else
                {
                    return output;
                }
            }
            catch (Exception)
            {
                return "Entered URL is incorrect";
            }

        }
       public string xpath(string xmlurl, string xpathurl)
       {
        
               string rs = "";
               try{
               XPathDocument xdoc = new XPathDocument(xmlurl);                //creating the wrapped Xpath document from the XML element
               XPathNavigator xpdoc = xdoc.CreateNavigator();                 //creating the Xpath Navigator class for running Xpath queries
               XPathExpression xp;                                            //creating the Xpath expression class
               xp = xpdoc.Compile(xpathurl);
               XPathNodeIterator iterator = xpdoc.Select(xp);                  //generates the node created by Xpath queries and select is used to return those result set

               while(iterator.MoveNext())
               {
                   rs = rs + iterator.Current.Value + "\n\n\n" + "<br/>";
               }
               }
               catch(Exception)
               {
                 rs = "Invalid Path.";  
               }
               if(rs.Equals(""))
               {
                   rs = "Wrong path expression.";
               }
               return rs;
           

           
         
       }
        
    }
}