using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace sampleWbform.Pages
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFilterOptions();

                if (Session["EditRecordId"] != null)
                {
                    int RecordId = Convert.ToInt32(Session["EditRecordId"]);
                    BindData(RecordId);
                }

            }
        }

        public class Record
        {
            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Remark is required.")]
            public string Remark { get; set; }

            [Required(ErrorMessage = "Detail ODE is required.")]
            public string DetailODE { get; set; }

            [Required(ErrorMessage = "Region is required.")]
            public string regionName { get; set; }

            [Required(ErrorMessage = "Region ID is required.")]
            public string regionID { get; set; }

            [Required(ErrorMessage = "Wiliya is required.")]
            public string WiliyaName { get; set; }

            [Required(ErrorMessage = "Wiliya ID is required.")]
            public string WiliyaID { get; set; }

            [Required(ErrorMessage = "Area is required.")]
            public string AreaName { get; set; }

            [Required(ErrorMessage = "Area ID is required.")]
            public string AreaID { get; set; }

            [Required(ErrorMessage = "Village is required.")]
            public string VillageName { get; set; }

            [Required(ErrorMessage = "Village ID is required.")]
            public string VillageID { get; set; }

            [Required(ErrorMessage = "Entity Type is required.")]
            public string EntityTypeName { get; set; }

            [Required(ErrorMessage = "Entity Type ID is required.")]
            public string EntityTypeID { get; set; }
        }


        private void BindData(int itemID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, EntityType, Email, PhoneNumber, Region, Willaya, Area, Village, DetailsODE, Remarks, AreaName, EntityTypeName, RegionName, VillageName, WillayaName " +
                    "FROM Item WHERE id = @ItemID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Check if a record is found
                        {
                            // Bind the data to the form controls
                            txtName.Text = reader["Name"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhone.Text = reader["PhoneNumber"].ToString();
                            txtRemark.Text = reader["Remarks"].ToString();
                            txtDetailODE.Text = reader["DetailsODE"].ToString();

                            // Assuming you have dropdowns for Region, Willaya, Area, Village, etc.
                            RegionDropDown.SelectedValue = reader["Region"].ToString();
                            WiliyaDropDown.SelectedValue = reader["Willaya"].ToString();
                            AreaDropDown.SelectedValue = reader["Area"].ToString();
                            VillageDropDown.SelectedValue = reader["Village"].ToString();
                            EntityTypeDropDown.SelectedValue = reader["EntityType"].ToString();
                        }
                        else
                        {
                            // Handle the case when no item is found with the given ID
                            lblMessage.Text = "Item not found!";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Visible = true;
                        }
                    }
                }
            }

            //Name = txtName.Text,
            //        Email = txtEmail.Text,
            //        Phone = txtPhone.Text,
            //        Remark = txtRemark.Text,
            //        DetailODE = txtDetailODE.Text,
            //        regionName = RegionDropDown.SelectedItem.Text,
            //        regionID = RegionDropDown.SelectedValue,
            //        WiliyaName = WiliyaDropDown.SelectedItem.Text,
            //        WiliyaID = RegionDropDown.SelectedValue,
            //        AreaName = AreaDropDown.SelectedItem.Text,
            //        AreaID = AreaDropDown.SelectedValue,
            //        VillageName = VillageDropDown.SelectedItem.Text,
            //        VillageID = VillageDropDown.SelectedValue,
            //        EntityTypeName = EntityTypeDropDown.SelectedItem.Text,
            //        EntityTypeID = EntityTypeDropDown.SelectedValue,
        }

        private void LoadFilterOptions()
        {
            // Example: Populate with static data, or fetch from database
            RegionDropDown.Items.Clear();
            WiliyaDropDown.Items.Clear();
            AreaDropDown.Items.Clear();
            VillageDropDown.Items.Clear();
            //EntityDropDown.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Regions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    // Populate RegionDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Regions", RegionDropDown, "Name", "Id", "Select Region");

                    // Populate WiliyaDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Wiliyats", WiliyaDropDown, "Name", "Id", "Select Wiliyats");

                    PopulateDropdown(con, "SELECT Id, Name FROM EntityType", EntityTypeDropDown, "Name", "Id", "Select EntityType");

                    //Populate AreaDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Areas", AreaDropDown, "Name", "Id", "Select Area");

                    // Populate VillageDropDown
                    PopulateDropdown(con, "SELECT Id, Name FROM Villages", VillageDropDown, "Name", "Id", "Select Village");

                    PopulateDropdown(con, "SELECT Id, Name FROM EntityType", EntityTypeDropDown, "Name", "Id", "Select EntityType");

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

        protected void EntityTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        { }
        protected void RegionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDown.Items.Clear();
            VillageDropDown.Items.Clear();
            //BindData();
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Regions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    PopulateDropdown(con, "SELECT Id, Name FROM Wiliyats where RegionId=" + RegionDropDown.SelectedItem.Value, WiliyaDropDown, "Name", "Id", "Select Wiliyats");
                }
            }

            // The selected Id i need to filter and display in the table
        }
        protected void WiliyatDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Regions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    PopulateDropdown(con, "SELECT Id, Name FROM Areas where WiliyatId=" + WiliyaDropDown.SelectedItem.Value, AreaDropDown, "Name", "Id", "Select Area");
                }
            }
            //BindData();
            // The selected Id i need to filter and display in the table
        }

        protected void AreaDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Regions";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    PopulateDropdown(con, "SELECT Id, Name FROM Villages where AreaId=" + AreaDropDown.SelectedItem.Value, VillageDropDown, "Name", "Id", "Select Village");
                }
            }
            //BindData();
            // The selected Id i need to filter and display in the table
        }
        protected void VillageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Capture form values


                Record record = new Record
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Remark = txtRemark.Text,
                    DetailODE = txtDetailODE.Text,
                    regionName = RegionDropDown.SelectedItem.Text,
                    regionID = RegionDropDown.SelectedValue,
                    WiliyaName = WiliyaDropDown.SelectedItem.Text,
                    WiliyaID = RegionDropDown.SelectedValue,
                    AreaName = AreaDropDown.SelectedItem.Text,
                    AreaID = AreaDropDown.SelectedValue,
                    VillageName = VillageDropDown.SelectedItem.Text,
                    VillageID = VillageDropDown.SelectedValue,
                    EntityTypeName = EntityTypeDropDown.SelectedItem.Text,
                    EntityTypeID = EntityTypeDropDown.SelectedValue,
                };

                if (Session["EditRecordId"] != null)
                {
                    //int RecordId = Convert.ToInt32(Session["EditRecordId"]);
                    int? recordId = Session["EditRecordId"] as int?;

                    if (recordId.HasValue)
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                        string query = "UPDATE Item SET " +
                                   "Name = @Name, " +
                                   "EntityType = @EntityType, " +
                                   "Email = @Email, " +
                                   "PhoneNumber = @PhoneNumber, " +
                                   "Region = @Region, " +
                                   "Willaya = @Willaya, " +
                                   "Area = @Area, " +
                                   "Village = @Village, " +
                                   "DetailsODE = @DetailsODE, " +
                                   "Remarks = @Remarks, " +
                                   "AreaName = @AreaName, " +
                                   "EntityTypeName = @EntityTypeName, " +
                                   "RegionName = @RegionName, " +
                                   "VillageName = @VillageName, " +
                                   "WillayaName = @WillayaName " +
                                   "WHERE Id = @RecordId";

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                // Set parameters for the update query
                                cmd.Parameters.AddWithValue("@Name", record.Name);
                                cmd.Parameters.AddWithValue("@EntityType", record.EntityTypeID); // Assuming EntityType is part of your model
                                cmd.Parameters.AddWithValue("@Email", record.Email);
                                cmd.Parameters.AddWithValue("@PhoneNumber", record.Phone);
                                cmd.Parameters.AddWithValue("@Region", record.regionID);
                                cmd.Parameters.AddWithValue("@Willaya", record.WiliyaID);
                                cmd.Parameters.AddWithValue("@Area", record.AreaID);
                                cmd.Parameters.AddWithValue("@Village", record.VillageID);
                                cmd.Parameters.AddWithValue("@DetailsODE", record.DetailODE);
                                cmd.Parameters.AddWithValue("@Remarks", record.Remark);
                                cmd.Parameters.AddWithValue("@AreaName", record.AreaName);
                                cmd.Parameters.AddWithValue("@EntityTypeName", record.EntityTypeName); // Assuming EntityTypeName is part of your model
                                cmd.Parameters.AddWithValue("@RegionName", record.regionName);
                                cmd.Parameters.AddWithValue("@VillageName", record.VillageName);
                                cmd.Parameters.AddWithValue("@WillayaName", record.WiliyaName);
                                cmd.Parameters.AddWithValue("@RecordId", recordId.Value); // Pass the RecordId to identify which record to update

                                // Open connection, execute query, close connection
                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // Display success message
                                    lblMessage.Text = "Record updated successfully!";
                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                    lblMessage.Visible = true;
                                }
                                else
                                {
                                    lblMessage.Text = "Failed to update record.";
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                    lblMessage.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        // If RecordId is not available in the session, show an error message
                        lblMessage.Text = "Record not found or session expired.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Visible = true;
                    }

                }
                else
                {

                    string query = "INSERT INTO Item (Name, EntityType, Email, PhoneNumber, Region, Willaya, Area, Village, DetailsODE, Remarks, AreaName, EntityTypeName, RegionName, VillageName, WillayaName) " +
                       "VALUES (@Name, @EntityType, @Email, @PhoneNumber, @Region, @Willaya, @Area, @Village, @DetailsODE, @Remarks, @AreaName, @EntityTypeName, @RegionName, @VillageName, @WillayaName)";
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            // Set parameters for the query
                            cmd.Parameters.AddWithValue("@Name", record.Name);
                            cmd.Parameters.AddWithValue("@EntityType", record.EntityTypeID); // Assuming EntityType is part of your model
                            cmd.Parameters.AddWithValue("@Email", record.Email);
                            cmd.Parameters.AddWithValue("@PhoneNumber", record.Phone);
                            cmd.Parameters.AddWithValue("@Region", record.regionID);
                            cmd.Parameters.AddWithValue("@Willaya", record.WiliyaID);
                            cmd.Parameters.AddWithValue("@Area", record.AreaID);
                            cmd.Parameters.AddWithValue("@Village", record.VillageID);
                            cmd.Parameters.AddWithValue("@DetailsODE", record.DetailODE);
                            cmd.Parameters.AddWithValue("@Remarks", record.Remark);
                            cmd.Parameters.AddWithValue("@AreaName", record.AreaName);
                            cmd.Parameters.AddWithValue("@EntityTypeName", record.EntityTypeName); // Assuming EntityTypeName is part of your model
                            cmd.Parameters.AddWithValue("@RegionName", record.regionName);
                            cmd.Parameters.AddWithValue("@VillageName", record.VillageName);
                            cmd.Parameters.AddWithValue("@WillayaName", record.WiliyaName);

                            // Open connection, execute query, close connection
                            conn.Open();
                            //cmd.ExecuteNonQuery();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Display success message
                                lblMessage.Text = "Record inserted successfully!";
                                lblMessage.Visible = true;
                            }
                            else
                            {
                                lblMessage.Text = "Failed to insert record.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                lblMessage.Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "Please correct the errors.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }
    }
}