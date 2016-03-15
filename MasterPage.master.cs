using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill();
    }
    //private void fill_repeter()
    //{
    //    var id = (from a in lnq_obj.menu_msts
    //              select new
    //              {
    //                  code = a.intglcode,
    //                  menuname = a.menu
    //              }).ToList();
    //    Repeater1.DataSource = id;
    //    Repeater1.DataBind();
    //}
    //private void fill_repeter1()
    //{
    //    var id = (from a in lnq_obj.submenu_msts
    //              select new
    //              {
    //                  code = a.intglcode,
    //                  submenu = a.submenu
    //              }).ToList();
    //    Repeater1.DataSource = id;
    //    Repeater1.DataBind();
    //}
    private void fill()
    {
        try
        {
            var id = (from a in lnq_obj.menu_msts
                      //  orderby a.number ascending
                      select new
                      {
                          code = a.intglcode,
                          menu = a.menu
                      }).ToList();
            Repeater1.DataSource = id;
            Repeater1.DataBind();

            for (int i = 0; i < id.Count(); i++)
            {


                Repeater data = (Repeater)Repeater1.Items[i].FindControl("Repeater2");
                var id2 = (from a in lnq_obj.submenu_msts
                           where a.menu == id[i].code
                           select new
                           {
                               code1 = a.intglcode,
                               submenu = a.submenu
                           }).ToList();
                data.DataSource = id2;
                data.DataBind();
            }
        }
        catch (Exception ex) { }
    }
}
