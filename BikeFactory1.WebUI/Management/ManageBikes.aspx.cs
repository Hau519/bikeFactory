using BikeFactory1.WebUI.BikeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeFactory1.WebUI.Management
{
    public partial class ManageBike : System.Web.UI.Page
    {
        #region Support methods
        private void DisplayListOfBikes()
        {
            var listOfBikes = new List<Bike>();

            try
            {
                listOfBikes = GetListOfBikes_WS();
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }

            dgBikes.DataSource = listOfBikes;
            dgBikes.DataBind();
        }

        private void DisplayBike(Bike bike)
        {
            txtName.Text = bike.Name;
            ddlSuspensionType.SelectedIndex = (int)bike.SuspensionType;
            ddlTireType.SelectedIndex = (int)bike.TireType;
            
        }

        private void ClearFields()
        {
            txtName.Text = "";
            ddlSuspensionType.SelectedIndex = 0;
            ddlTireType.SelectedIndex = 0;  
        }

        private int FindColumn(string name)
        {
            int result = -1;
            for (int i = 0; i < dgBikes.Columns.Count; i++)
            {
                if (dgBikes.Columns[i] is BoundColumn)
                {
                    var boundColumn = (BoundColumn)dgBikes.Columns[i];
                    if (boundColumn.DataField == name)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result;
        }

        #endregion

        #region WS proxy methods vs Data proxy methods

      
        private List<Bike> GetListOfBikes_WS()
        {
            var wsClient = new BikeServiceSoapClient();
            var wsResult = wsClient.GetList();
            return wsResult.ToList();
        }


        private void Insert_WS(Bike bike)
        {
            var wsClient = new BikeServiceSoapClient();
            wsClient.Insert(bike);
        }

        private void Update_WS(Bike bike)
        {
            var wsClient = new BikeServiceSoapClient();
            wsClient.Update(bike);
        }

        private void SearchById_WS(int bikeId)
        {
            var wsClient = new BikeServiceSoapClient();
            var bike = wsClient.SearchById(bikeId);
            DisplayBike(bike);
        }

        private void Delete_WS(int bikeId)
        {
            var wsClient = new BikeServiceSoapClient();
            wsClient.Delete(bikeId);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DisplayListOfBikes();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            var bike = new Bike();
            bike.Name = txtName.Text;
            bike.SuspensionType = (ESuspensionType)ddlSuspensionType.SelectedIndex;
            bike.TireType = (ETireType)ddlTireType.SelectedIndex;

            try
            {
                Insert_WS(bike);
                ClearFields();
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }

            DisplayListOfBikes();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (dgBikes.SelectedIndex < 0)
            {
                StaticMethods.DisplayMessage("Please select a bike", this);
                return;
            }

            try
            {
                var bike = new Bike();
                bike.Id = Convert.ToInt32(dgBikes.SelectedItem.Cells[FindColumn("Id")].Text);
                bike.Name = txtName.Text;
                bike.SuspensionType = (ESuspensionType)ddlSuspensionType.SelectedIndex;
                bike.TireType = (ETireType)ddlTireType.SelectedIndex;
                
                Update_WS(bike);
                dgBikes.SelectedItem.Cells[FindColumn("Name")].Text = txtName.Text;
                dgBikes.SelectedItem.Cells[FindColumn("SuspensionType")].Text = ddlSuspensionType.Text;
                dgBikes.SelectedItem.Cells[FindColumn("TireType")].Text = ddlTireType.Text;
             
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bool found = false;

            for (int i = 0; i < dgBikes.Items.Count; i++)
            {
                if (dgBikes.Items[i].Cells[1].Text == txtSearchById.Text)
                {
                    dgBikes.SelectedIndex = i;
                    dgBikes_SelectedIndexChanged(sender, e);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                StaticMethods.DisplayMessage("Bike not found", this);
                return;
            }
        }

        protected void cvSuspensionType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlSuspensionType.SelectedIndex > 0;
        }

        protected void cvTireType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ddlTireType.SelectedIndex > 0;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgBikes.SelectedIndex < 0)
            {
                StaticMethods.DisplayMessage("Please select a bike", this);
                return;
            }

            try
            {
                int bikeId = Convert.ToInt32(dgBikes.SelectedItem.Cells[1].Text);

                Delete_WS(bikeId);
                DisplayListOfBikes();
                ClearFields();
            }
            catch (Exception ex)
            {
                StaticMethods.DisplayMessage(ex.Message, this);
            }
        }

        protected void lkbSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Default.aspx");
        }

        protected void dgBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgBikes.SelectedIndex < 0)
                return;

            int bikeId = Convert.ToInt32(dgBikes.SelectedItem.Cells[1].Text);
            SearchById_WS(bikeId);
        }
    }
}