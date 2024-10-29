using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sampleWbform.Pages
{
    public partial class itemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFilterOptions();
                BindData();

            }
        }
        private void LoadFilterOptions()
        {
            // Example: Populate with static data, or fetch from database
            RegionDropDown.Items.Clear();
            WiliyaDropDown.Items.Clear();
            AreaDropDown.Items.Clear();
            VillageDropDown.Items.Clear();
            EntityDropDown.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Regions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    // Populate RegionDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Regions", RegionDropDown, "Name", "Id","Select Region");

                    // Populate WiliyaDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Wiliyats", WiliyaDropDown, "Name", "Id", "Select Wiliyats");

                    // Populate AreaDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Areas", AreaDropDown, "Name", "Id", "Select Area");

                    // Populate VillageDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Villages", VillageDropDown, "Name", "Id", "Select Village");

                    PopulateDropdown(con, "SELECT Id, Name FROM EntityType", EntityDropDown, "Name", "Id", "Select EntityType");

                    //using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    //{
                    //    DataTable dt = new DataTable();
                    //    adapter.Fill(dt);

                    //    RegionDropDown.DataSource = dt;
                    //    RegionDropDown.DataTextField = "Name"; // The column to display in dropdown
                    //    RegionDropDown.DataValueField = "Id";  // The column to use as the value
                    //    RegionDropDown.DataBind();
                    //}
                }
            }
            //RegionDropDown.Items.Insert(0, new ListItem("Select Region", "0"));

          
        }
        void PopulateDropdown(SqlConnection connection, string query, DropDownList dropdown, string textField, string valueField, string defaultValue)
        {
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dropdown.DataSource = dt;
                    dropdown.DataTextField = textField;
                    dropdown.DataValueField = valueField;
                    dropdown.DataBind();

                    // Optionally, add a default item at the top
                    dropdown.Items.Insert(0, new ListItem(defaultValue, "0"));
                }
            }
        }
        protected void RegionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
            // The selected Id i need to filter and display in the table
        }
        private void BindData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            string selectedRegion = RegionDropDown.SelectedValue;
            string selectedWiliaya = WiliyaDropDown.SelectedValue;
            string selectedArea = AreaDropDown.SelectedValue;
            string selectedVillage = VillageDropDown.SelectedValue;
            string selectedEntity = EntityDropDown.SelectedValue;
             
            string query = "SELECT Name, EntityTypeName, VillageName, WillayaName, RegionName, AreaName FROM item";
            bool hasWhereClause = false; // Track if WHERE clause has been added

            // Add a WHERE clause if a specific region is selected
            if (!string.IsNullOrEmpty(selectedRegion) && selectedRegion != "0")
            {
                //query += " WHERE Region = @selectedRegion";
                query += hasWhereClause ? " AND Region = @selectedRegion" : " WHERE Region = @selectedRegion";

                hasWhereClause = true;
            }
            if (!string.IsNullOrEmpty(selectedEntity) && selectedEntity != "0")
            {
                //query += " WHERE Region = @selectedRegion";
                query += hasWhereClause ? " AND EntityType = @selectedEntity" : " WHERE EntityType = @selectedEntity";

                hasWhereClause = true;
            }
            if (!string.IsNullOrEmpty(selectedWiliaya) && selectedWiliaya != "0")
            {
                query += hasWhereClause ? " AND Willaya = @selectedWiliaya" : " WHERE Willaya = @selectedWiliaya";
                hasWhereClause = true;
            }
            if (!string.IsNullOrEmpty(selectedArea) && selectedArea != "0")
            {
                query += hasWhereClause ? " AND Area = @selectedArea" : " WHERE Area = @selectedArea";
                hasWhereClause = true;
            }
            if (!string.IsNullOrEmpty(selectedVillage) && selectedVillage != "0")
            {
                query += hasWhereClause ? " AND Village = @selectedVillage" : " WHERE Village = @selectedVillage";
                hasWhereClause = true;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add the @selectedRegion parameter only if filtering is applied
                    if (!string.IsNullOrEmpty(selectedRegion) && selectedRegion != "0")
                    {
                        cmd.Parameters.AddWithValue("@selectedRegion", selectedRegion);
                    }
                    if (!string.IsNullOrEmpty(selectedWiliaya) && selectedWiliaya != "0")
                    {
                        cmd.Parameters.AddWithValue("@selectedWiliaya", selectedWiliaya);
                    }
                    if (!string.IsNullOrEmpty(selectedArea) && selectedArea != "0")
                    {
                        cmd.Parameters.AddWithValue("@selectedArea", selectedArea);
                    }
                    if (!string.IsNullOrEmpty(selectedVillage) && selectedVillage != "0")
                    {
                        cmd.Parameters.AddWithValue("@selectedVillage", selectedVillage);
                    }
                    if (!string.IsNullOrEmpty(selectedEntity) && selectedEntity != "0")
                    {
                        cmd.Parameters.AddWithValue("@selectedEntity", selectedEntity);
                    }
                    




                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to GridView (or other data control)
                        ItemGridView.DataSource = dt;
                        ItemGridView.DataBind();
                    }
                }
            }

        }
    }
}