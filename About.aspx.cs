using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_ltr();
    }
    private void fill_ltr()
    {
        try
        {
            var id = (from a in lnq_obj.menu_msts
                      where a.intglcode == Convert.ToInt32(Request.QueryString["id"].ToString())
                      select a).Single();
            Literal1.Text = id.pagecontain;
        }
        catch (Exception ex)
        {

        }
    }
}