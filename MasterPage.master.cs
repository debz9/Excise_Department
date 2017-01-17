using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["wb"] == null)
            {
                red();
            }
            else
            {
                Label1.Text = Session["name"].ToString();                
                switch (Session["wb"].ToString())
                {
                    case "01":
                    admin();
                    break;
                    case "02":
                    Mis();
                    break;
                    case "03":
                    operate();
                    break;
                    case "04":
                    supervisor();
                    break;
                    default: red();
                    break;
                 }
                MenuItem da = new MenuItem();
                da.Text = System.DateTime.Now.DayOfWeek.ToString() +" "+ System.DateTime.Now.ToShortDateString();
                da.Enabled = false;
                date.Items.Add(da);
            }
        }
    }
    protected void red()
    {
        Response.Redirect("Log_in.aspx");
    }
    protected void admin()
    {
        MenuItem Home = new MenuItem();
        Home.NavigateUrl = "Home.aspx";
        Home.Text = "Home";
        Menu1.Items.Add(Home);

        MenuItem maker =new MenuItem();
        maker.NavigateUrl="super.aspx";
        maker.Text ="Vehicle Make Entry";
        MenuItem model = new MenuItem();
        model.NavigateUrl = "model.aspx";
        model.Text = "Vehicle Model Entry";
        MenuItem vehicle = new MenuItem();
        vehicle.Text = "Vehicle Enty";
        vehicle.ChildItems.Add(maker);
        vehicle.ChildItems.Add(model);
        Menu1.Items.Add(vehicle);

        MenuItem makerv = new MenuItem();
        makerv.NavigateUrl = "superv.aspx";
        makerv.Text = "Vehicle Make";
        MenuItem modelv = new MenuItem();
        modelv.NavigateUrl = "modelv.aspx";
        modelv.Text = "Vehicle Model";
        MenuItem Mis = new MenuItem();
        Mis.Text = "MIS";
        Mis.ChildItems.Add(makerv);
        Mis.ChildItems.Add(modelv);
        Menu1.Items.Add(Mis);

        MenuItem user = new MenuItem();
        user.NavigateUrl = "user.aspx";
        user.Text = "User Entry";
        Menu1.Items.Add(user);
        MenuItem chng = new MenuItem();
        chng.NavigateUrl = "chng_pass.aspx";
        chng.Text = "Change Password";
        MenuItem Pro = new MenuItem();
        Pro.NavigateUrl = "pro.aspx";
        Pro.Text = "Profile";
        MenuItem house = new MenuItem();
        house.Text = "House Keeping";
        house.ChildItems.Add(chng);
        house.ChildItems.Add(Pro);
        Menu1.Items.Add(house);
        MenuItem Log = new MenuItem();
        Log.NavigateUrl = "Log_in.aspx";
        Log.Text = "Log Out";
        Menu1.Items.Add(Log);
    }
    protected void Mis()
    {
        MenuItem Home = new MenuItem();
        Home.NavigateUrl = "Home.aspx";
        Home.Text = "HOME";
        Menu1.Items.Add(Home);

        MenuItem makerv = new MenuItem();
        makerv.NavigateUrl = "superv.aspx";
        makerv.Text = "VEHICLE MAKE";
        MenuItem modelv = new MenuItem();
        modelv.NavigateUrl = "modelv.aspx";
        modelv.Text = "VEHICLE MODEL";
        MenuItem Mis = new MenuItem();
        Mis.Text = "MIS";
        Mis.ChildItems.Add(makerv);
        Mis.ChildItems.Add(modelv);
        Menu1.Items.Add(Mis);

        MenuItem chng = new MenuItem();
        chng.NavigateUrl = "chng_pass.aspx";
        chng.Text = "CHANGE PASSWORD";
        MenuItem Pro = new MenuItem();
        Pro.NavigateUrl = "pro.aspx";
        Pro.Text = "PROFILE";
        MenuItem house = new MenuItem();
        house.Text = "HOUSE KEEPING";
        house.ChildItems.Add(chng);
        house.ChildItems.Add(Pro);
        Menu1.Items.Add(house);
        MenuItem Log = new MenuItem();
        Log.NavigateUrl = "Log_in.aspx";
        Log.Text = "LOGOUT";
        Menu1.Items.Add(Log);
    }
    protected void operate()
    {
        MenuItem Home = new MenuItem();
        Home.NavigateUrl = "Home.aspx";
        Home.Text = "HOME";
        Menu1.Items.Add(Home);
        MenuItem maker = new MenuItem();
        maker.NavigateUrl = "super.aspx";
        maker.Text = "VEHICLE MAKE";
        MenuItem model = new MenuItem();
        model.NavigateUrl = "model.aspx";
        model.Text = "VEHICLE MODEL";
        MenuItem vehicle = new MenuItem();
        vehicle.Text = "VEHICLE ENTRY";
        vehicle.ChildItems.Add(maker);
        vehicle.ChildItems.Add(model);
        Menu1.Items.Add(vehicle);

        MenuItem makerv = new MenuItem();
        makerv.NavigateUrl = "superv.aspx";
        makerv.Text = "VEHICLE MAKE";
        MenuItem modelv = new MenuItem();
        modelv.NavigateUrl = "modelv.aspx";
        modelv.Text = "VEHICLE MODEL";
        MenuItem Mis = new MenuItem();
        Mis.Text = "MIS";
        Mis.ChildItems.Add(makerv);
        Mis.ChildItems.Add(modelv);
        Menu1.Items.Add(Mis);

        MenuItem chng = new MenuItem();
        chng.NavigateUrl = "chng_pass.aspx";
        chng.Text = "CHANGE PASSWORD";
        MenuItem Pro = new MenuItem();
        Pro.NavigateUrl = "pro.aspx";
        Pro.Text = "PROFILE";
        MenuItem house = new MenuItem();
        house.Text = "HOUSE KEEPING";
        house.ChildItems.Add(chng);
        house.ChildItems.Add(Pro);
        Menu1.Items.Add(house);
        MenuItem Log = new MenuItem();
        Log.NavigateUrl = "Log_in.aspx";
        Log.Text = "LOGOUT";
        Menu1.Items.Add(Log);
    }
    protected void supervisor()
    {
        MenuItem Home = new MenuItem();
        Home.NavigateUrl = "Home.aspx";
        Home.Text = "HOME";
        Menu1.Items.Add(Home);
        MenuItem maker = new MenuItem();
        maker.NavigateUrl = "super.aspx";
        maker.Text = "VEHICLE MAKE";
        MenuItem model = new MenuItem();
        model.NavigateUrl = "model.aspx";
        model.Text = "VEHICLE MODEL";
        MenuItem vehicle = new MenuItem();
        vehicle.Text = "VEHICLE ENTRY";
        vehicle.ChildItems.Add(maker);
        vehicle.ChildItems.Add(model);
        Menu1.Items.Add(vehicle);

        MenuItem makerv = new MenuItem();
        makerv.NavigateUrl = "superv.aspx";
        makerv.Text = "VEHICLE MAKE";
        MenuItem modelv = new MenuItem();
        modelv.NavigateUrl = "modelv.aspx";
        modelv.Text = "VEHICLE MODEL";
        MenuItem Mis = new MenuItem();
        Mis.Text = "MIS";
        Mis.ChildItems.Add(makerv);
        Mis.ChildItems.Add(modelv);
        Menu1.Items.Add(Mis);

        MenuItem chng = new MenuItem();
        chng.NavigateUrl = "chng_pass.aspx";
        chng.Text = "CHANGE PASSWORD";
        MenuItem Pro = new MenuItem();
        Pro.NavigateUrl = "pro.aspx";
        Pro.Text = "PROFILE";
        MenuItem house = new MenuItem();
        house.Text = "HOUSE KEEPING";
        house.ChildItems.Add(chng);
        house.ChildItems.Add(Pro);
        Menu1.Items.Add(house);
        MenuItem Log = new MenuItem();
        Log.NavigateUrl = "Log_in.aspx";
        Log.Text = "LOGOUT";
        Menu1.Items.Add(Log);
    }
}
