using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

                    if(InputName.Value==null || InputName.Value==""){
                        ErrorName.Text = "Please Enter the Client Name!";
                        if (InputMasking.Value == null || InputMasking.Value == "")
                        {
                            ErrorMasking.Text = "Please Enter the Masking Name!";
                        }else{
                            if (InputMasking.Value.Length != 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 digits Masking Name!";
                            }
                        }
                    }else {
                        ErrorName.Text = "";
                        if (InputMasking.Value == null || InputMasking.Value == "")
                        {
                            ErrorMasking.Text = "Please Enter the Masking Name!";
                        }
                        else
                        {
                            if (InputMasking.Value.Length != 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 digits Masking Name!";
                            }
                            else {
                                ErrorMasking.Text = "";
                                Client client = new Client();
                                client.Name = InputName.Value;
                                client.Masking = InputMasking.Value;

                                if (active.Checked)
                                {
                                    client.StatusId = 1;
                                }
                                else
                                {
                                    client.StatusId = 0;
                                }
                                client.CreatedOn = DateTime.Now;
                                client.CreatedBy = 1;
                                client.UpdatedOn = DateTime.Now;
                                client.UpdatedBy = 1;



                                SMSPortalEntity.Clients.Add(client);
                                SMSPortalEntity.SaveChanges();
                            }
                        }
                    
                    }

                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}