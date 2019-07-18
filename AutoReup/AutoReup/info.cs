using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoReup
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        
        public void UpdateTotal(string venue, string totalrent,string error,string reup,string rent,string ready, string webrent, string webready,string rateweb,string rateshop)
        {
            lblVenue.Text = venue;
            lblNumberOfRent.Text = totalrent;
            lblError.Text = error;
            lblReup.Text = reup;
            lblRent.Text = rent;
            lblReady.Text = ready;
            lblWebReady.Text = webready;
            lblWebRent.Text = webrent;
            lblRateShop.Text = rateshop+"%";
            lblRateWeb.Text = rateweb + "%";
        }
      

       
    }
}
