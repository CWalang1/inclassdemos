using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces 
using eRestaurantSystem.BLL;
using eRestaurantSystem.Entities;
using EatIn.UI;
#endregion

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            RefreshWaiterList("0");
            DateHired.Text = DateTime.Today.ToShortDateString();
        }
    }

    protected void RefreshWaiterList(string selectedvalue)
    {
        //force a requery of the drop down list 
        WaiterList.DataBind();
        //insert of the prompt line 
        WaiterList.Items.Insert(0, "Select a waiter");
        //position on a waiter in the list 
        WaiterList.SelectedValue = selectedvalue;


    }

    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        if (WaiterList.SelectedIndex == 0)
        {
            MessageUserControl.ShowInfo("Please select a waiter before clicking Fetch Waiter");
        }
        else
        {
            //we will use a tryrun from the MessageUserControl 
            //this will capture error messages when/if they happen 
            //and properly display in the user control 
            //GetWaiterInfo is your method for accessing BLL and query
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }

    }
    public void GetWaiterInfo()
    {
        //this is a standard lookup instance 
        AdminController sysmgr = new AdminController();
        var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Phone.Text = waiter.Phone;
        Address.Text = waiter.Address;
        DateHired.Text = waiter.HireDate.ToShortDateString();
        if (waiter.ReleaseDate.HasValue)
        {
            DateReleased.Text = waiter.ReleaseDate.ToString();
        }
    }
    protected void Insert_Click(object sender, EventArgs e)
    {
        //this example is using the TryRun inline
        MessageUserControl.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Phone = Phone.Text;
                item.Address = Address.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);
                item.ReleaseDate = null;
                AdminController sysmgr = new AdminController();
                WaiterID.Text = sysmgr.Waiters_Add(item).ToString();
                MessageUserControl.ShowInfo("Waiter Added");
                RefreshWaiterList(WaiterID.Text);
            }
        );
    }

    protected void Update_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(WaiterID.Text))
        {
            MessageUserControl.ShowInfo("Please enter a value");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.WaiterID = int.Parse(WaiterID.Text);
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Phone = Phone.Text;
                item.Address = Address.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);
                if (string.IsNullOrEmpty(DateReleased.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(DateReleased.Text);
                }
                AdminController sysmgr = new AdminController();
                sysmgr.Waiters_Update(item);
                MessageUserControl.ShowInfo("Waiter Added");
                RefreshWaiterList(WaiterID.Text);
            }
       );
        }
    }

    
}