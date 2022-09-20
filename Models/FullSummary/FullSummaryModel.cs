using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcApp1.Models.FullSummary
{
    public class FullSummaryModel
    {
        public string studentName {  get; set; }
        public string classYear { get: set;  }
        public string societyName { get; set;  }
        
        
        
        
        IList<sd_getDeanNotesResult> results = context2010.sd_getDeanNotes(hfEmaddr.Value).ToList();
            if (results.Count() > 0)
        {
            gvNotes.DataSource = context2010.sd_getDeanNotes(hfEmaddr.Value);
            gvNotes.DataBind();
        }

    }
    tblElectives.Visible = true;
    gvTypeA.DataSource = context2010.sd_GetElectiveCourses(emaddr, 'A');
    gvTypeA.DataBind();
    gvTypeB.DataSource = context2010.sd_GetElectiveCourses(emaddr, 'B');
    gvTypeB.DataBind();
}

protected void ddlStudents_SelectedIndexChanged(object sender, EventArgs e)
{
    string ddlStudValue = ddlStudents.SelectedValue;
    Response.Redirect("FullSummary.aspx?ln=emaddr" + ddlStudValue + "");
}

protected void ddlLoaPhd_SelectedIndexChanged(object sender, EventArgs e)
{
    string ddlStudValue = ddlLoaPhd.SelectedValue;
    Response.Redirect("FullSummary.aspx?ln=emaddr" + ddlStudValue + "");
}


        protected void gvFull_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rIndex = e.Row.RowIndex;
                string stemaddr = gvFull.DataKeys[rIndex].Values["stemaddr"].ToString().Trim();
                string mdyr = gvFull.DataKeys[rIndex].Values["mdyr"].ToString().Trim();
                Image imgPicture = (Image)e.Row.FindControl("imgPicture");
                imgPicture.ImageUrl = DataBinder.Eval(e.Row.DataItem, "stpict").ToString();

                Label lblSociety = (Label)e.Row.FindControl("lblSociety");
                lblSociety.Text = clsCheckValues.getLblSociety(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "advisor_campus_id")).Trim());

                LinkButton lbBlk1 = (LinkButton)e.Row.FindControl("lbBlk1");
                lbBlk1.Text = getFinalGrade(stemaddr, 1);
                e.Row.Cells[1].BackColor = getGradeColor(getFinalGrade(stemaddr, 1));
                LinkButton lbBlk2 = (LinkButton)e.Row.FindControl("lbBlk2");
                lbBlk2.Text = getFinalGrade(stemaddr, 2);
                e.Row.Cells[2].BackColor = getGradeColor(getFinalGrade(stemaddr, 2));
                LinkButton lbBlk3 = (LinkButton)e.Row.FindControl("lbBlk3");
                lbBlk3.Text = getFinalGrade(stemaddr, 3);
                e.Row.Cells[3].BackColor = getGradeColor(getFinalGrade(stemaddr, 3));
                LinkButton lbBlk4 = (LinkButton)e.Row.FindControl("lbBlk4");
                lbBlk4.Text = getFinalGrade(stemaddr, 4);
                e.Row.Cells[4].BackColor = getGradeColor(getFinalGrade(stemaddr, 4));
                LinkButton lbBlk5 = (LinkButton)e.Row.FindControl("lbBlk5");
                lbBlk5.Text = getFinalGrade(stemaddr, 5);
                e.Row.Cells[5].BackColor = getGradeColor(getFinalGrade(stemaddr, 5));
                LinkButton lbBlk6 = (LinkButton)e.Row.FindControl("lbBlk6");
                lbBlk6.Text = getFinalGrade(stemaddr, 6);
                e.Row.Cells[6].BackColor = getGradeColor(getFinalGrade(stemaddr, 6));

                var catAvgScore = context2010.sd_GetCATavgScore(stemaddr).SingleOrDefault();
                if (catAvgScore != null)
                {
                    e.Row.Cells[7].Text = "<div style='width:100%; height: 100%'><br/><a href=\"CATDataGrid.aspx?ln=emaddr" + stemaddr + "\">" + context2010.sd_GetCATavgScore(stemaddr).SingleOrDefault().Average.ToString() + "</a></div>";
                }

                
                string cell7 = clinicalDetails(stemaddr, "FAMC");
                string[] strsCell7 = cell7.Split(',');
                string dismon7 = strsCell7[0];
                string overall7 = strsCell7[1];
                string bgColor7 = strsCell7[2];
                string hospitalID7 = strsCell7[3];
                if (string.IsNullOrWhiteSpace(overall7))
                {
                    e.Row.Cells[8].Text = "<div class='" + bgColor7 + "' style='width:100%; height: 100%'><span>"+dismon7+"</span></div>";
                }
                else
                {
                    e.Row.Cells[8].Text = "<div style='width:100%; height: 100%'><span class='" + bgColor7 + "'>"+dismon7+"</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=FAMC&hid=" + hospitalID7 + "&overall=" + overall7 + "\" target='_blank'>" + overall7 + "</a></div>";
                }

                string cell8 = clinicalDetails(stemaddr, "MEDC");
                string[] strsCell8 = cell8.Split(',');
                string dismon8 = strsCell8[0];
                string overall8 = strsCell8[1];
                string bgColor8 = strsCell8[2];
                string hospitalID8 = strsCell8[3];
                if (string.IsNullOrWhiteSpace(overall8))
                {
                    e.Row.Cells[9].Text = String.Format("<div class='" + bgColor8 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon8);
                }
                else
                {
                    e.Row.Cells[9].Text = "<div style='width:100%; height: 100%'><span class='" + bgColor8 + "'>"+dismon8+"</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=MEDC&hid=" + hospitalID8 + "&overall=" + overall8 + "\" target='_blank'>" + overall8 + "</a></div>";
                }

                string cell9 = clinicalDetails(stemaddr, "NSCI");
                string[] strsCell9 = cell9.Split(',');
                string dismon9 = strsCell9[0];
                string overall9 = strsCell9[1];
                string bgColor9 = strsCell9[2];
                string hospitalID9 = strsCell9[3];
                if (string.IsNullOrWhiteSpace(overall9))
                {
                    e.Row.Cells[10].Text = String.Format("<div class='" + bgColor9 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon9);
                }
                else
                {
                    e.Row.Cells[10].Text = "<div style='width:100%; height: 100%'><span class='" + bgColor9 + "'>"+dismon9+"</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=NSCI&hid=" + hospitalID9 + "&overall=" + overall9 + "\" target='_blank'>" + overall9 + "</a></div>";
                }


                string cell10 = clinicalDetails(stemaddr, "OBGC");
                string[] strsCell10 = cell10.Split(',');
                string dismon10 = strsCell10[0];
                string overall10 = strsCell10[1];
                string bgColor10 = strsCell10[2];
                string hospitalID10 = strsCell10[3];
                if (string.IsNullOrWhiteSpace(overall10))
                {
                    e.Row.Cells[11].Text = String.Format("<div class='" + bgColor10 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon10);
                }
                else
                {
                    e.Row.Cells[11].Text = "<div style='width:100%; height: 100%'><span class='" + bgColor10 + "'>" + dismon10 + "</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=OBGC&hid=" + hospitalID10 + "&overall=" + overall10 + "\" target='_blank'>" + overall10 + "</a></div>";
                }

                string cell11 = clinicalDetails(stemaddr, "PEDC");
                string[] strsCell11 = cell11.Split(',');
                string dismon11 = strsCell11[0];
                string overall11 = strsCell11[1];
                string bgColor11 = strsCell11[2];
                string hospitalID11 = strsCell11[3];
                if (string.IsNullOrWhiteSpace(overall11))
                {
                    e.Row.Cells[12].Text = String.Format("<div class='" + bgColor11 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon11);
                }
                else
                {
                    e.Row.Cells[12].Text = "<div  style='width:100%; height: 100%'><span class='" + bgColor11 + "'>"+dismon11+"</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=PEDC&hid=" + hospitalID11 + "&overall=" + overall11 + "\" target='_blank'>" + overall11 + "</a></div>";
                }

                string cell12 = clinicalDetails(stemaddr, "PSYC");
                string[] strsCell12 = cell12.Split(',');
                string dismon12 = strsCell12[0];
                string overall12 = strsCell12[1];
                string bgColor12 = strsCell12[2];
                string hospitalID12 = strsCell12[3];
                if (string.IsNullOrWhiteSpace(overall12))
                {
                    e.Row.Cells[13].Text = String.Format("<div class='" + bgColor12 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon12);
                }
                else
                {
                    e.Row.Cells[13].Text = "<div  style='width:100%; height: 100%'><span class='" + bgColor12 + "'>" + dismon12 + "</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=PSYC&hid=" + hospitalID12 + "&overall=" + overall12 + "\" target='_blank'>" + overall12 + "</a></div>";
                }


                string cell13 = clinicalDetails(stemaddr, "SURC");
                string[] strsCell13 = cell13.Split(',');
                string dismon13 = strsCell13[0];
                string overall13 = strsCell13[1];
                string bgColor13 = strsCell13[2];
                string hospitalID13 = strsCell13[3];
                if (string.IsNullOrWhiteSpace(overall13))
                {
                    e.Row.Cells[14].Text = String.Format("<div class='" + bgColor13 + "' style='width:100%; height: 100%'><span>{0}</span></div><br/>", dismon13);
                }
                else
                {
                    e.Row.Cells[14].Text = "<div  style='width:100%; height: 100%'><span class='" + bgColor13 + "'>" + dismon13 + "</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=SURC&hid=" + hospitalID13 + "&overall=" + overall13 + "\" target='_blank'>" + overall13 + "</a></div>";
                }

                string cell14 = clinicalDetails(stemaddr, "AGEC");
                string[] strsCell14 = cell14.Split(',');
                string dismon14 = strsCell14[0];
                string overall14 = strsCell14[1];
                string bgColor14 = strsCell14[2];
                string hospitalID14 = strsCell14[3];
                if (string.IsNullOrWhiteSpace(overall14))
                {
                    e.Row.Cells[15].Text = "<div class='" + bgColor14 + "' style='width:100%; height: 100%'><span>" + dismon14 + "</span></div>";
                }
                else
                {
                    e.Row.Cells[15].Text = "<div  style='width:100%; height: 100%'><span class='" + bgColor14 + "'>" + dismon14 + "</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=AGEC&hid=" + hospitalID14 + "&overall=" + overall14 + "\" target='_blank'>" + overall14 + "</a></div>";
                }

                string cell15 = clinicalDetails(stemaddr, "EMGC");
                string[] strsCell15 = cell15.Split(',');
                string dismon15 = strsCell15[0];
                string overall15 = strsCell15[1];
                string bgColor15 = strsCell15[2];
                string hospitalID15 = strsCell15[3];
                if (string.IsNullOrWhiteSpace(overall15))
                {
                    e.Row.Cells[16].Text = "<div class='" + bgColor15 + "' style='width:100%; height: 100%'><span>" + dismon15 + "</span></div>";
                }
                else
                {
                    e.Row.Cells[16].Text = "<div  style='width:100%; height: 100%'><span class='" + bgColor15 + "'>" + dismon15 + "</span><br/><a href=\"ClinicalBasView.aspx?stemaddr=" + stemaddr + "&clname=EMGC&hid=" + hospitalID15 + "&overall=" + overall15 + "\" target='_blank'>" + overall15 + "</a></div>";
                }

                var aamc = easelContext.usmle_getaamcidbyemaddr(stemaddr).FirstOrDefault();
                if (aamc != null)
                {
                    string aamcID = aamc.aamc_id.Trim();
                    if (!string.IsNullOrEmpty(aamcID))
                    {
                        Label lblStep1 = (Label)e.Row.FindControl("lblStep1");
                        Label lblCS = (Label)e.Row.FindControl("lblCS");
                        Label lblCK = (Label)e.Row.FindControl("lblCK");
                        IList<usmle_score_selectbyaamcidbyexamResult> step1Lst = easelContext.usmle_score_selectbyaamcidbyexam(aamcID, "step1").ToList();
                        if (step1Lst.Count > 0)
                        {
                            foreach (var step1 in step1Lst)
                            {
                                lblStep1.Text += step1.score + "<br/>";
                            }
                        }
                        IList<usmle_score_selectbyaamcidbyexamResult> csLst = easelContext.usmle_score_selectbyaamcidbyexam(aamcID, "step2cs").ToList();
                        if (csLst.Count > 0)
                        {
                            foreach (var cs in csLst)
                            {
                                lblCS.Text += (cs.pass_fail.ToString().Trim() == "F" ? "<font color='red'>F</font>" : cs.pass_fail.ToString()) + "<br/>";
                            }
                        }
                        IList<usmle_score_selectbyaamcidbyexamResult> ckLst = easelContext.usmle_score_selectbyaamcidbyexam(aamcID, "step2ck").ToList();
                        if (ckLst.Count > 0)
                        {
                            foreach (var ck in ckLst)
                            {
                                lblCK.Text += ck.score + "<br/>";
                            }
                        }
                    }

                }

            }
        }
     
        private string getFinalGrade(string emaddr, int blockNo)
        { 
            string decision = string.Empty;
            string release = string.Empty;
            string finalGrade = string.Empty;
            var record = context2010.sd_GetBLKFinalGradeByStudent(blockNo, emaddr).FirstOrDefault();
            if (record != null)
            {
                decision = record.finalGrade.Trim();
                release = record.release.Trim();
            }

            if (decision.Equals("4") && release.Equals("Y"))
            {
                finalGrade = "M";
            }
            else
            {
                if (release.Equals("Y"))
                {
                    if (!decision.Equals("4"))
                    {
                        finalGrade = "NM";
                    }
                    
                }
                else
                {
                    finalGrade = "I";
                }
            }
            return finalGrade;
        }

        private System.Drawing.Color getGradeColor(string text)
        {
            System.Drawing.Color cid = System.Drawing.Color.Transparent;
            switch (text)
            {
                case "M":
                    cid = System.Drawing.ColorTranslator.FromHtml("#BCF5A9");
                    break;
                case "NM":
                    cid = System.Drawing.Color.Orange;
                    break;
                case "I":
                    cid = System.Drawing.ColorTranslator.FromHtml("#F3F781");
                    break;
            }
            return cid;
        }

        private string clinicalDetails(string stemaddr, string subj)
        {
            string dismon = string.Empty;
            string overall = string.Empty;
            string grade = string.Empty;
            string dirRelease = string.Empty;
            string locID = string.Empty;
            string hospitalID = string.Empty;
            string bgColor = string.Empty;
            //IList<sd_getClinDetailsResult> results = context.sd_getClinDetails(stemaddr, subj).ToList();
            IList<sd_GetClinDetailsResult> results = context2010.sd_GetClinDetails(stemaddr, subj).ToList();
            foreach (var item in results)
            {
                dismon = item.dismon;
                overall = item.overall.Trim();
                grade = item.grade;
                dirRelease = item.dirRelease;
                locID = item.locid;
            }
            if (!string.IsNullOrEmpty(overall) && !string.IsNullOrEmpty(locID))
            {
                switch (locID.Substring(0, 1))
                {
                    case "C":
                        bgColor = "greenLight";//ccf
                        hospitalID = "3";
                        break;
                    case "K":
                        bgColor = "blueColor";//Kaiser
                        hospitalID = "4";
                        break;
                    case "M":
                        bgColor = "brown";//MHMC
                        hospitalID = "2";
                        break;
                    case "U":
                        bgColor = "blueLight";//uh/va
                        hospitalID = "1";
                        break;
                    default:
                        bgColor = "beige";//Final
                        hospitalID = "1";
                        break;
                }

            }
            else
            {
                if (dirRelease == "Y")
                {
                    grade = "Preliminary";
                }
            }
            return dismon + "," + grade + "," + bgColor + "," + hospitalID;
        }

        protected void lbBlk_Click(object sender, System.EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["eCurriculum2010ConnectionString"].ConnectionString;
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.NamingContainer;
            int rIndex = row.RowIndex;
            GridView gvFull = (GridView)row.NamingContainer;
            string nblk = lnk.ToolTip;
            string scyear = gvFull.DataKeys[rIndex].Values["mdyr"] == null ? "" : gvFull.DataKeys[rIndex].Values["mdyr"].ToString().Trim();
            string gyr = (Convert.ToInt32(scyear)+4).ToString();

            string stemaddr = gvFull.DataKeys[rIndex].Values["stemaddr"].ToString().Trim();
            string userID = SocietyDeans.SimpleSSOHelper.usercaseid;

            System.Data.SqlClient.SqlParameter[] parms = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@apcode",System.Data.SqlDbType.Int),
                new System.Data.SqlClient.SqlParameter("@userid",System.Data.SqlDbType.VarChar),
                new System.Data.SqlClient.SqlParameter("@studid",System.Data.SqlDbType.VarChar)
            };
            parms[0].Value = 3;
            parms[1].Value = userID;
            parms[2].Value = stemaddr;


            System.Data.SqlClient.SqlParameter[] parms2 = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@blkID",System.Data.SqlDbType.Int),
                new System.Data.SqlClient.SqlParameter("@emaddr",System.Data.SqlDbType.Char),
                new System.Data.SqlClient.SqlParameter("@syearForFoundation",System.Data.SqlDbType.Int),
            };
            parms2[0].Value = nblk;
            parms2[1].Value = stemaddr;
            parms2[2].Direction = System.Data.ParameterDirection.Output;
            SocietyDeans.clsCheckValues.ExecuteReader(connString, System.Data.CommandType.StoredProcedure, "sd_GetSYearForFoundation", parms2);
            scyear = parms2[2].Value.ToString();

            string repname = string.Empty;

            if (  Convert.ToInt32(scyear) < 2007 || (Convert.ToInt32(scyear) == 2007 && Convert.ToInt32(nblk) < 5))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myscript", "popupPage('" + nblk + "','" + scyear + "')", true);
            }
            else if (Convert.ToInt32(scyear) > 2013)
            {
                string strEncrypted = Encrypt(nblk + ";" + SimpleSSOHelper.usercaseid + ";" + gyr + ";" + stemaddr, System.Text.Encoding.Unicode);
                string url = "https://med-ed.case.edu/eAssessment/summaryAndPLP/endOfBlockSummaryAdmin.aspx?v=" + strEncrypted;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myscript",
                    "window.open('" + url + "', 'eAssessmentStudent', 'toolbar=yes, scrollbars=1; resizable=1;');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "myscript", "popupPage2('" + nblk + "','" + stemaddr + "')", true);
            }
        }

        public static string Encrypt(String input, System.Text.Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        protected void noteAdd_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.ToString().Trim();
            string note = txtNote.Text.ToString().Trim();
            context2010.sd_addDeanNotes(hfEmaddr.Value, DateTime.Now, USERID, title, note);
            Response.Redirect(Request.RawUrl);
        }

        protected void noteEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rIndex = row.RowIndex;
            GridView gvNotes = (GridView)row.NamingContainer;
            string nid = gvNotes.DataKeys[rIndex].Values["nid"].ToString().Trim();
            string emaddr = gvNotes.DataKeys[rIndex].Values["emaddr"].ToString().Trim();
            TextBox editTitle = (TextBox)row.FindControl("editTitle");
            TextBox editNote = (TextBox)row.FindControl("editNote");
            string title = editTitle.Text.ToString().Trim();
            string note = editNote.Text.ToString().Trim();
            string noteFile = gvNotes.DataKeys[rIndex].Values["notefile"].ToString().Trim();
            FileUpload fUpload = (FileUpload)row.FindControl("fUpload");
            string pathName = string.Empty;
            if (fUpload != null && !string.IsNullOrEmpty(fUpload.FileName.ToString().Trim()))
            {
                DirectoryInfo di;
                string path = Server.MapPath("/societydeans/noteFileUpload");
                path += "\\" + emaddr + "\\" + nid + "\\";
                pathName = path + fUpload.FileName;
                if (!(Directory.Exists(path)))
                {
                    di = Directory.CreateDirectory(path);   //Create the directory.
                }
                if (File.Exists(noteFile))
                {
                    File.Delete(noteFile);
                }

                fUpload.SaveAs(pathName);

            }
            if ((!string.IsNullOrEmpty(noteFile) && string.IsNullOrEmpty(pathName)) || (string.IsNullOrEmpty(noteFile) && string.IsNullOrEmpty(pathName)))
            {
                context2010.sd_updateDeanNotes(Convert.ToInt32(nid), title, note, noteFile);
            }
            else if (!string.IsNullOrEmpty(pathName))
            {
                context2010.sd_updateDeanNotes(Convert.ToInt32(nid), title, note, pathName);
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void noteDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton noteDelete = (ImageButton)sender;
            GridViewRow row = (GridViewRow)noteDelete.NamingContainer;
            int rIndex = row.RowIndex;
            GridView gvNotes = (GridView)row.NamingContainer;
            string nid = gvNotes.DataKeys[rIndex].Values["nid"].ToString().Trim();
            context2010.sd_deleteDeanNotes(Convert.ToInt32(nid));
            Response.Redirect(Request.RawUrl);
        }

        protected void gvNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rIndex = e.Row.RowIndex;
                string adLogin = gvNotes.DataKeys[rIndex].Values["adlogin"].ToString().Trim();
                Label lblSDInitial = (Label)e.Row.FindControl("lblSDInitial");
                
                if(registrarContext.sd_GetSDInitialByCaseid(adLogin).FirstOrDefault() == null)
                {
                    if (adLogin.ToLower().Equals("mag167"))
                    {
                        lblSDInitial.Text = "SM";
                    }
                }
                else
                {
                    lblSDInitial.Text = registrarContext.sd_GetSDInitialByCaseid(adLogin).FirstOrDefault().initial;
                }
                HyperLink hlinkFileName = (HyperLink)e.Row.FindControl("hlinkFileName");
                string noteFile = gvNotes.DataKeys[rIndex].Values["notefile"].ToString().Trim();
                if (!string.IsNullOrEmpty(noteFile.Trim().Replace("&nbsp;", "")) && !string.IsNullOrWhiteSpace(noteFile.Trim()))
                {
                    string hlinkurl = "/" + noteFile.Substring(noteFile.IndexOf("societydeans")).Replace("\\", "/");
                    hlinkFileName.NavigateUrl = hlinkurl.Trim();
                }
                ImageButton noteEdit = (ImageButton)e.Row.FindControl("noteEdit");
                ImageButton noteDelete = (ImageButton)e.Row.FindControl("noteDelete");
                if (USERID.ToUpper() != adLogin.ToUpper())
                {
                    //gvNotes.Columns[2].Visible = false;
                    noteEdit.Visible = false;
                    noteDelete.Visible = false;
                }
                else
                {
                    //gvNotes.Columns[2].Visible = true;
                    noteEdit.Visible = true;
                    noteDelete.Visible = true;
                }
            }
        }

        protected void gvTypeA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rIndex = e.Row.RowIndex;
                HyperLink hlGradeA = (HyperLink)e.Row.FindControl("hlGradeA");
                string emaddr = gvTypeA.DataKeys[rIndex].Values["emaddr"].ToString().Trim();
                string subject = gvTypeA.DataKeys[rIndex].Values["subj"].ToString().Trim();
                string catalogNbr = gvTypeA.DataKeys[rIndex].Values["new_num"].ToString().Trim();
                string overall = DataBinder.Eval(e.Row.DataItem, "overall").ToString();
                hlGradeA.Text = GetGrade(overall);
                hlGradeA.NavigateUrl = "ElectivesView.aspx?emaddr=" + emaddr + "&subj=" + subject + "&nbr=" + catalogNbr;
            }
        }

        protected void gvTypeB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rIndex = e.Row.RowIndex;
                HyperLink hlGradeB = (HyperLink)e.Row.FindControl("hlGradeB");
                string emaddr = gvTypeB.DataKeys[rIndex].Values["emaddr"].ToString().Trim();
                string subject = gvTypeB.DataKeys[rIndex].Values["subj"].ToString().Trim();
                string catalogNbr = gvTypeB.DataKeys[rIndex].Values["new_num"].ToString().Trim();
                string overall = DataBinder.Eval(e.Row.DataItem, "overall").ToString();
                string ccfid = (DataBinder.Eval(e.Row.DataItem, "ccfid") == null ? "" : DataBinder.Eval(e.Row.DataItem, "ccfid").ToString());
                hlGradeB.Text = GetGrade(overall);
                hlGradeB.NavigateUrl = "ElectivesView.aspx?emaddr=" + emaddr + "&subj=" + subject + "&nbr=" + catalogNbr + "&ccfid=" + ccfid;
            }
        }

        private string GetGrade(string overall)
        {
            string grade = string.Empty;
            switch (overall.ToUpper().Substring(0, 1))
            {
                case "COM":
                    grade = "Commendable";
                    break;
                case "C":
                    grade = "Commendable";
                    break;
                case "S":
                    grade = "Satisfactory";
                    break;
                case "H":
                    grade = "Honors";
                    break;
                case "I":
                    grade = "Incomplete";
                    break;
                case "U":
                    grade = "Unsatisfactory";
                    break;
                case "N":
                    grade = "Did Not Achieve Expectations";
                    break;
                case "AE":
                    grade = "Achieve Expectations";
                    break;
                case "A":
                    grade = "Achieve Expectations";
                    break;
                default:
                    grade = overall;
                    break;
            }
            return grade;
        }
        
    }
}