using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HotelApplication
{
    public partial class HotelApplicationForm : System.Web.UI.Page
    {
        string rs = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = null;                             //Creating the XML Text Reader for traversing the XML document
            try
            {
                reader = new XmlTextReader(TextBox1.Text);            //entering the xml url in the Textbox
                reader.WhitespaceHandling = WhitespaceHandling.None;  //removing the whitespaces
                while(reader.Read())
                {
                    rs += "TYPE = " + reader.NodeType + "\t";
                    rs += "NAME = " + reader.Name + "\t";
                    rs += "VALUE = " + reader.Value + "\t";
                    rs += " <br/>";
                }
                if(reader.AttributeCount > 0)
                {
                    while(reader.MoveToNextAttribute())                //traversing the nodes and attributes
                    {
                        rs += "TYPE = " + reader.NodeType + "\t";
                        rs += "NAME = " + reader.Name + "\t";
                        rs += "VALUE = " + reader.Value + "\t";
                        rs += "<br/>";
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            Label2.Text = rs;                                      //displaying the output in the label 
            Label2.Visible = true;
        }
    }
}