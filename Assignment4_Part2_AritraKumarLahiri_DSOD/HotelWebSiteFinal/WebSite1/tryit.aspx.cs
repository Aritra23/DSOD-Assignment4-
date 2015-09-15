using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HotelForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client ob = new ServiceReference1.Service1Client();  //creating the service reference object for mapping the Verification service
            string xmltextbox = TextBox1.Text;   //textbox holding the XML url
            string xsdtextbox = TextBox2.Text;   //textbox holding the XSD url
            if(xmltextbox == "" || xsdtextbox =="")
            {
                Label3.Text = "Please enter data";  //label to display the value when no url is entered
                Label3.Visible = true;
            }
            else
            {
                Label3.Text = ob.verify(xmltextbox, xsdtextbox);   //label to display the validation value
                Label3.Visible = true;
            }
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();   //creating the service reference for the Xpath search operation
            string xmltext = TextBox3.Text;     // Textbox for holding the xml url
            string xpathtext = TextBox4.Text;   // Textbox for holding the Xpath expression
            if(xmltext == "" || xpathtext == "")
            {
                Label6.Text = "Please Enter Valid Data";
                Label6.Visible = true;
            }
            else
            {
                Label6.Text = obj.xpath(xmltext,xpathtext); // displaying the output for xpath search operation
                Label6.Visible = true;
            }
        }
    }
