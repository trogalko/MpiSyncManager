using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Temiang.Avicenna.Common;
using Temiang.Avicenna.BusinessObject.Mpi;
using Temiang.Avicenna.BusinessObject;
using System.IO;
using System.Threading.Tasks;

namespace MpiSyncManager
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public HostManager HostManager { get; set; }
        private DataTable _dtbMpi;
        private bool _isFromMenu;
        private ContextMenu _menu;
        private string RscmKencanaOrgID = "687";

        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            try
            {
                this._dtbMpi = GetPrintJob();
                this.gridListMpiSync.DataSource = this._dtbMpi;
                if (this._dtbMpi.Rows.Count > 0)
                {
                    foreach (GridViewDataColumn column in this.gridListMpiSync.Columns)
                    {
                        column.BestFit();
                    }
                }
                this.tmrPrint.Enabled = true;
            }
            catch (Exception ex)            
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable GetPrintJob()
        {
            try
            {
                MpiSyncKunjunganQuery mskQ = new MpiSyncKunjunganQuery("a");
                //mskQ.es.Top = 50;
                mskQ.Select(mskQ.RegistrationNo, mskQ.MedicalNo, mskQ.PatientID, mskQ.CreatedDateTime, mskQ.CreatedByUser, mskQ.IsClosed, mskQ.IsDischarged, mskQ.IsEditedKunjungan, mskQ.IsNewKunjungan);
                mskQ.Where((mskQ.IsClosed == true || mskQ.IsDischarged == true || mskQ.IsEditedKunjungan == true || mskQ.IsNewKunjungan == true) && mskQ.IsSkipped == false);
                return mskQ.LoadDataTable();
                /*
                AppProgramQuery joinQuery = new AppProgramQuery("b");
                PrintJobQuery query2 = new PrintJobQuery("a");
                AppUserQuery query3 = new AppUserQuery("c");
                PrinterQuery query4 = new PrinterQuery("d");
                query2.InnerJoin(joinQuery).On(new object[] { joinQuery.ProgramID == query2.ProgramID });
                query2.InnerJoin(query3).On(new object[] { query2.UserID == query3.UserID });
                query2.InnerJoin(query4).On(new object[] { query2.PrinterID == query4.PrinterID });
                query2.Select(new object[] { query2.PrintNo, query4.PrinterName, query3.UserName, joinQuery.ProgramName });
                return query2.LoadDataTable();
                */
            }
            catch (Exception)
            {
            }
            return null;
        }

        private void tmrPrint_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss:fff");
            Exception exception = new Exception();            
                    if (this._dtbMpi.Rows.Count == 0)
                    {
                        this.tmrPrint.Enabled = false;
                        this._dtbMpi = this.GetPrintJob();
                        this.gridListMpiSync.DataSource = this._dtbMpi;
                        if (this._dtbMpi.Rows.Count == 0)
                        {
                            this.tmrPrint.Enabled = true;
                            return;
                        }
                    }
                    this.tmrPrint.Enabled = false;
                    Registration reg = new Registration();
                    Patient pat = new Patient();
                    string regno = (string)gridListMpiSync.Rows[0].Cells["RegistrationNo"].Value;
                    string patientID = (string)gridListMpiSync.Rows[0].Cells["PatientID"].Value;
                    string RscmPatientID = string.Empty;
                    string AdmissionID = string.Empty;
                    bool IsClosed = false;
                    bool IsDischarged = false;
                    bool IsEditedKunjungan = false;
                    bool IsNewKunjungan = false;
                    IsClosed = (bool)(gridListMpiSync.Rows[0].Cells["IsClosed"].Value);
                    IsDischarged = (bool)(gridListMpiSync.Rows[0].Cells["IsDischarged"].Value);
                    IsEditedKunjungan = (bool)(gridListMpiSync.Rows[0].Cells["IsEditedKunjungan"].Value);
                    IsNewKunjungan = (bool)(gridListMpiSync.Rows[0].Cells["IsNewKunjungan"].Value);
                    //Start the logger
                    try
                    {

                        // Tampungan hasil pencarian pasien
                        Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response Pasien_Cari = new Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response();
                        if (reg.LoadByPrimaryKey(regno))
                        {
                            if (pat.LoadByPrimaryKey(patientID))
                            {
                                // Cari pasien ID di MPI Pusat
                                //Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response pasien_cari = new Temiang.Avicenna.BusinessObject.Mpi.PasienCari.response();
                                //Temiang.Avicenna.BusinessObject.Mpi.PasienCari.responsePatientsPatient pasien = new Temiang.Avicenna.BusinessObject.Mpi.PasienCari.responsePatientsPatient();
                                if (pat.MedicalNo != null)
                                    Pasien_Cari = Mpi.ListPasienCari(pat.MedicalNo);
                                if (Pasien_Cari.patients.Count() > 0)
                                {
                                    foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienCari.responsePatients rP in Pasien_Cari.patients)
                                    {
                                        if (rP.patient != null)
                                        {
                                            if (rP.patient.Count() > 0)
                                            {
                                                foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienCari.responsePatientsPatient rPP in rP.patient)
                                                {
                                                    RscmPatientID = rPP.patient_id;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Cari data kunjungan pasien di MPI Pusat
                            }
                        }
                        //////////  DISCHARGE PATIENT /////////////
                        //Discharge outstanding semua kunjungan inpatient kencana
                        //dan create kunjungan baru-yg langsung di-discharge jika data kunjungan belum ada
                        if (IsDischarged && !string.IsNullOrEmpty(RscmPatientID))
                        {
                            // List kunjungan pasien
                            bool IsNothingDischarged = false;
                            Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response pasien_kunjungan = new Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response();
                            pasien_kunjungan = Mpi.ListPasienKunjungan(RscmPatientID);
                            if (pasien_kunjungan.patient.Length > 0)
                            {
                                foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatient pk_rp in pasien_kunjungan.patient)
                                {
                                    foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatientAdmission pk_rpa in pk_rp.admission)
                                    {
                                        if (pk_rpa.inpatient_ind == "1" && pk_rpa.admission_org_id == RscmKencanaOrgID && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                        //if (pk_rpa.inpatient_ind == "1" && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                        {
                                            AdmissionID = pk_rpa.admission_id;
                                            Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                            MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                            if (msk.LoadByPrimaryKey(regno, patientID))
                                            {
                                                msk.AdmissionID = AdmissionID;
                                                msk.MpiPatientID = RscmPatientID;
                                                msk.IsNewKunjungan = false;
                                                msk.IsEditedKunjungan = false;
                                                msk.IsClosed = false;
                                                msk.IsDischarged = false;
                                                msk.LastUpdatedByUser = "system";
                                                msk.LastUpdatedDateTime = DateTime.Now;
                                                msk.Save();
                                                IsNothingDischarged = true;
                                            }
                                        }

                                        if (pk_rpa.inpatient_ind == "1" && pk_rpa.admission_org_id != RscmKencanaOrgID && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                        //if (pk_rpa.inpatient_ind == "1" && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                        {
                                            //Skip, bukan pasien kencana
                                            AdmissionID = pk_rpa.admission_id;
                                            //Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                            MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                            if (msk.LoadByPrimaryKey(regno, patientID))
                                            {
                                                msk.AdmissionID = AdmissionID;
                                                msk.MpiPatientID = RscmPatientID;
                                                msk.IsNewKunjungan = false;
                                                msk.IsEditedKunjungan = false;
                                                msk.IsClosed = false;
                                                msk.IsDischarged = false;
                                                msk.IsSkipped = true;
                                                msk.LastUpdatedByUser = "system";
                                                msk.LastUpdatedDateTime = DateTime.Now;
                                                msk.Save();
                                                IsNothingDischarged = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!IsNothingDischarged && !string.IsNullOrEmpty(RscmPatientID))
                            {
                                //Create kunjungan baru
                                //Request new admission ID ke MPI Pusat
                                List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                //Insert data kunjungan baru (yang akan langsung di-discharge)
                                AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                if (!string.IsNullOrEmpty(AdmissionID))
                                    //Discharge kunjungan ini segera
                                    Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID) && !string.IsNullOrEmpty(AdmissionID))
                                {
                                    msk.AdmissionID = AdmissionID;
                                    msk.MpiPatientID = RscmPatientID;
                                    msk.IsNewKunjungan = false;
                                    msk.IsEditedKunjungan = false;
                                    msk.IsClosed = false;
                                    msk.IsDischarged = false;
                                    msk.LastUpdatedByUser = "system";
                                    msk.LastUpdatedDateTime = DateTime.Now;
                                    msk.Save();
                                }
                            }
                        }
                        //Pasien Baru belum terdaftar rekam medis nya di MPI
                        if (IsDischarged && string.IsNullOrEmpty(RscmPatientID))
                        {
                            //Request Rscm Pasien ID Baru ke pusat dan daftarkan rekam medis Pasien Baru
                            List<KeyValuePair<string, string>> RscmPasienIdBaru = new List<KeyValuePair<string, string>>();
                            RscmPasienIdBaru = Mpi.PasienLama();
                            Registration Registration = new Registration();
                            Registration.LoadByPrimaryKey(regno);
                            Patient Patient = new Patient();
                            Patient.LoadByPrimaryKey(patientID);

                            Registration Registration_1 = new Registration();
                            Registration_1.LoadByPrimaryKey(regno);
                            Patient Patient_1 = new Patient();
                            Patient_1.LoadByPrimaryKey(patientID);

                            if (Registration_1.RegistrationNo != null && Patient_1.MedicalNo != null && RscmPasienIdBaru != null)
                            {
                                RscmPatientID = Mpi.InsertPatientData(Registration_1, Patient_1, RscmPasienIdBaru);
                            }
                            //Create kunjungan baru
                            //Request new admission ID ke MPI Pusat
                            List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                            pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                            //Insert data kunjungan baru (yang akan langsung di-discharge)
                            AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                            if (!string.IsNullOrEmpty(AdmissionID))
                                //Discharge kunjungan ini segera
                                Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                            MpiSyncKunjungan msk = new MpiSyncKunjungan();
                            if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID) && !string.IsNullOrEmpty(AdmissionID))
                            {
                                msk.AdmissionID = AdmissionID;
                                msk.MpiPatientID = RscmPatientID;
                                msk.IsNewKunjungan = false;
                                msk.IsEditedKunjungan = false;
                                msk.IsClosed = false;
                                msk.IsDischarged = false;
                                msk.IsSkipped = false;
                                msk.LastUpdatedByUser = "system";
                                msk.LastUpdatedDateTime = DateTime.Now;
                                msk.Save();
                            }
                        }

                        ////////////// KUNJUNGAN BARU /////////////////////
                        //Create data kunjungan baru
                        if (IsNewKunjungan && !IsDischarged)
                        {
                            //Rekam Medis Pasien sudah terdaftar di MPI
                            if (!string.IsNullOrEmpty(RscmPatientID))
                            {
                                //Create kunjungan baru
                                //Request new admission ID ke MPI Pusat
                                List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                //Insert data kunjungan baru (yang akan langsung di-discharge)
                                if (pasien_kunjungan_baru != null)
                                    AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                // Check if AdmissionID is not empty.
                                // If Empty, its mean there is an un-discharge registration
                                // Discharge it first
                                if (string.IsNullOrEmpty(AdmissionID))
                                {
                                    // List kunjungan pasien
                                    Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response pasien_kunjungan = new Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response();
                                    pasien_kunjungan = Mpi.ListPasienKunjungan(RscmPatientID);
                                    if (pasien_kunjungan.patient.Length > 0)
                                    {
                                        foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatient pk_rp in pasien_kunjungan.patient)
                                        {
                                            foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatientAdmission pk_rpa in pk_rp.admission)
                                            {
                                                //if (pk_rpa.inpatient_ind == "1" && pk_rpa.admission_org_id == RscmKencanaOrgID && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                                //remove checking for RSCM Kencana only
                                                if (pk_rpa.inpatient_ind == "1" && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                                {
                                                    AdmissionID = pk_rpa.admission_id;
                                                    //Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                                    MpiSyncKunjungan Mpsk = new MpiSyncKunjungan();
                                                    if (Mpsk.LoadByPrimaryKey(regno, patientID))
                                                    {
                                                        Mpsk.AdmissionID = AdmissionID;
                                                        Mpsk.MpiPatientID = RscmPatientID;
                                                        Mpsk.IsNewKunjungan = false;
                                                        Mpsk.IsEditedKunjungan = false;
                                                        Mpsk.IsClosed = false;
                                                        Mpsk.IsDischarged = false;
                                                        Mpsk.IsSkipped = true;
                                                        Mpsk.LastUpdatedByUser = "system";
                                                        Mpsk.LastUpdatedDateTime = DateTime.Now;
                                                        Mpsk.Save();
                                                    }
                                                }
                                                else if (pk_rpa.inpatient_ind == "1" && pk_rpa.admission_org_id == RscmKencanaOrgID && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                                {
                                                    AdmissionID = pk_rpa.admission_id;
                                                    Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                                    MpiSyncKunjungan Mpsk = new MpiSyncKunjungan();
                                                    if (Mpsk.LoadByPrimaryKey(regno, patientID))
                                                    {
                                                        Mpsk.AdmissionID = AdmissionID;
                                                        Mpsk.MpiPatientID = RscmPatientID;
                                                        Mpsk.IsNewKunjungan = false;
                                                        Mpsk.IsEditedKunjungan = false;
                                                        Mpsk.IsClosed = false;
                                                        Mpsk.IsDischarged = false;
                                                        Mpsk.IsSkipped = false;
                                                        Mpsk.LastUpdatedByUser = "system";
                                                        Mpsk.LastUpdatedDateTime = DateTime.Now;
                                                        Mpsk.Save();
                                                    }
                                                }
                                                else if (pk_rpa.inpatient_ind == "1" && pk_rpa.discharge_dttm != "0000-00-00 00:00:00")
                                                {
                                                    AdmissionID = pk_rpa.admission_id;
                                                    //Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                                    MpiSyncKunjungan Mpsk = new MpiSyncKunjungan();
                                                    if (Mpsk.LoadByPrimaryKey(regno, patientID))
                                                    {
                                                        Mpsk.AdmissionID = AdmissionID;
                                                        Mpsk.MpiPatientID = RscmPatientID;
                                                        Mpsk.IsNewKunjungan = false;
                                                        Mpsk.IsEditedKunjungan = false;
                                                        Mpsk.IsClosed = false;
                                                        Mpsk.IsDischarged = false;
                                                        Mpsk.IsSkipped = true;
                                                        Mpsk.LastUpdatedByUser = "system";
                                                        Mpsk.LastUpdatedDateTime = DateTime.Now;
                                                        Mpsk.Save();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Repeat the steap
                                    //Create kunjungan baru
                                    //Request new admission ID ke MPI Pusat
                                    //List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                    //pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                    ////Insert data kunjungan baru (yang akan langsung di-discharge)
                                    //AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                    //if (!string.IsNullOrEmpty(AdmissionID))
                                    //{
                                    //    MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                    //    if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                    //    {
                                    //        msk.AdmissionID = AdmissionID;
                                    //        msk.MpiPatientID = RscmPatientID;
                                    //        msk.IsNewKunjungan = false;
                                    //        msk.IsEditedKunjungan = false;
                                    //        msk.IsClosed = false;
                                    //        msk.IsDischarged = false;
                                    //        msk.LastUpdatedByUser = "system";
                                    //        msk.LastUpdatedDateTime = DateTime.Now;
                                    //        msk.Save();
                                    //    }
                                    //}
                                }
                                else
                                {
                                    MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                    if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                    {
                                        msk.AdmissionID = AdmissionID;
                                        msk.MpiPatientID = RscmPatientID;
                                        msk.IsNewKunjungan = false;
                                        msk.IsEditedKunjungan = false;
                                        msk.IsClosed = false;
                                        msk.IsDischarged = false;
                                        msk.IsSkipped = false;
                                        msk.LastUpdatedByUser = "system";
                                        msk.LastUpdatedDateTime = DateTime.Now;
                                        msk.Save();
                                    }
                                }
                            }
                            //Rekam Medis Pasien Baru belum terdaftar di MPI
                            else
                            {
                                //Request Rscm Pasien ID Baru ke pusat dan daftarkan rekam medis Pasien Baru
                                List<KeyValuePair<string, string>> RscmPasienIdBaru = new List<KeyValuePair<string, string>>();
                                RscmPasienIdBaru = Mpi.PasienLama();
                                Registration Registration_2 = new Registration();
                                Registration_2.LoadByPrimaryKey(regno);
                                Patient Patient_2 = new Patient();
                                Patient_2.LoadByPrimaryKey(patientID);

                                if (Registration_2.RegistrationNo != null && Patient_2.MedicalNo != null && RscmPasienIdBaru != null)
                                    RscmPatientID = Mpi.InsertPatientData(Registration_2, Patient_2, RscmPasienIdBaru);
                                //Create kunjungan baru
                                //Request new admission ID ke MPI Pusat
                                List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                //Insert data kunjungan baru (yang akan langsung di-discharge)
                                AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                {
                                    msk.AdmissionID = AdmissionID;
                                    msk.MpiPatientID = RscmPatientID;
                                    msk.IsNewKunjungan = false;
                                    msk.IsEditedKunjungan = false;
                                    msk.IsClosed = false;
                                    msk.IsDischarged = false;
                                    msk.IsSkipped = false;
                                    msk.LastUpdatedByUser = "system";
                                    msk.LastUpdatedDateTime = DateTime.Now;
                                    msk.Save();
                                }
                            }
                        }

                        ///////////// EDIT KUNJUNGAN  /////////////////////
                        //Modifikasi data kunjungan
                        if (IsEditedKunjungan && !IsDischarged)
                        {
                            //Rekam Medis Pasien sudah terdaftar di MPI
                            if (!string.IsNullOrEmpty(RscmPatientID))
                            {
                                //Create kunjungan baru
                                //Request new admission ID ke MPI Pusat
                                List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                //Jika null, maka ada kunjungan yang belum di-discharge
                                if (pasien_kunjungan_baru != null)
                                    AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                //Discharge dulu kunjungan yang nge-blok
                                if (string.IsNullOrEmpty(AdmissionID))
                                {
                                    // List kunjungan pasien
                                    Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response pasien_kunjungan = new Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.response();
                                    pasien_kunjungan = Mpi.ListPasienKunjungan(RscmPatientID);
                                    if (pasien_kunjungan.patient.Length > 0)
                                    {
                                        foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatient pk_rp in pasien_kunjungan.patient)
                                        {
                                            foreach (Temiang.Avicenna.BusinessObject.Mpi.PasienKunjungan.responsePatientAdmission pk_rpa in pk_rp.admission)
                                            {
                                                //if (pk_rpa.inpatient_ind == "1" && pk_rpa.admission_org_id == RscmKencanaOrgID && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                                //remove checking for RSCM Kencana only
                                                if (pk_rpa.inpatient_ind == "1" && pk_rpa.discharge_dttm == "0000-00-00 00:00:00")
                                                {
                                                    AdmissionID = pk_rpa.admission_id;
                                                    //Mpi.PatientDischarge(RscmPatientID, AdmissionID, DateTime.Now, RscmKencanaOrgID, reg.RegistrationNo);
                                                    MpiSyncKunjungan Mpsk = new MpiSyncKunjungan();
                                                    if (Mpsk.LoadByPrimaryKey(regno, patientID))
                                                    {
                                                        Mpsk.AdmissionID = AdmissionID;
                                                        Mpsk.MpiPatientID = RscmPatientID;
                                                        Mpsk.IsNewKunjungan = false;
                                                        Mpsk.IsEditedKunjungan = false;
                                                        Mpsk.IsClosed = false;
                                                        Mpsk.IsDischarged = false;
                                                        Mpsk.IsSkipped = true;
                                                        Mpsk.LastUpdatedByUser = "system";
                                                        Mpsk.LastUpdatedDateTime = DateTime.Now;
                                                        Mpsk.Save();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    //Repeat the steap
                                    //Create kunjungan baru
                                    //Request new admission ID ke MPI Pusat
                                    //List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                    //pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                    ////Insert data kunjungan baru (yang akan langsung di-discharge)
                                    //AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                    //if (!string.IsNullOrEmpty(AdmissionID))
                                    //{
                                    //    MpiSyncKunjungan msk1 = new MpiSyncKunjungan();
                                    //    if (msk1.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                    //    {
                                    //        msk1.AdmissionID = AdmissionID;
                                    //        msk1.MpiPatientID = RscmPatientID;
                                    //        msk1.IsNewKunjungan = false;
                                    //        msk1.IsEditedKunjungan = false;
                                    //        msk1.IsClosed = false;
                                    //        msk1.IsDischarged = false;
                                    //        msk1.LastUpdatedByUser = "system";
                                    //        msk1.LastUpdatedDateTime = DateTime.Now;
                                    //        msk1.Save();
                                    //    }
                                    //}
                                }
                                else
                                {
                                    MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                    if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                    {
                                        msk.AdmissionID = AdmissionID;
                                        msk.MpiPatientID = RscmPatientID;
                                        msk.IsNewKunjungan = false;
                                        msk.IsEditedKunjungan = false;
                                        msk.IsClosed = false;
                                        msk.IsDischarged = false;
                                        msk.IsSkipped = false;
                                        msk.LastUpdatedByUser = "system";
                                        msk.LastUpdatedDateTime = DateTime.Now;
                                        msk.Save();
                                    }
                                }
                            }
                            //Rekam Medis Pasien Baru belum terdaftar di MPI
                            else
                            {
                                //Request Rscm Pasien ID Baru ke pusat dan daftarkan rekam medis Pasien Baru
                                List<KeyValuePair<string, string>> RscmPasienIdBaru = new List<KeyValuePair<string, string>>();
                                RscmPasienIdBaru = Mpi.PasienLama();
                                Registration Registration_3 = new Registration();
                                Registration_3.LoadByPrimaryKey(regno);
                                Patient Patient_3 = new Patient();
                                Patient_3.LoadByPrimaryKey(patientID);

                                if (Registration_3.RegistrationNo != null && Patient_3.MedicalNo != null && RscmPasienIdBaru != null)
                                    RscmPatientID = Mpi.InsertPatientData(Registration_3, Patient_3, RscmPasienIdBaru);
                                //Create kunjungan baru
                                //Request new admission ID ke MPI Pusat
                                List<KeyValuePair<string, string>> pasien_kunjungan_baru = new List<KeyValuePair<string, string>>();
                                pasien_kunjungan_baru = Mpi.pasien_kunjungan_baru(RscmPatientID, RscmKencanaOrgID);
                                //Insert data kunjungan baru (yang akan langsung di-discharge)
                                AdmissionID = Mpi.InsertKunjunganData(reg, pat, pasien_kunjungan_baru);
                                MpiSyncKunjungan msk = new MpiSyncKunjungan();
                                if (msk.LoadByPrimaryKey(reg.RegistrationNo, patientID))
                                {
                                    msk.AdmissionID = AdmissionID;
                                    msk.MpiPatientID = RscmPatientID;
                                    msk.IsNewKunjungan = false;
                                    msk.IsEditedKunjungan = false;
                                    msk.IsClosed = false;
                                    msk.IsDischarged = false;
                                    msk.IsSkipped = false;
                                    msk.LastUpdatedByUser = "system";
                                    msk.LastUpdatedDateTime = DateTime.Now;
                                    msk.Save();
                                }
                            }
                        }
                        //string errorMessage = string.Empty;  
                        //Refresh the Grid
                        this._dtbMpi = GetPrintJob();
                        this.gridListMpiSync.DataSource = this._dtbMpi;
                        if (this._dtbMpi.Rows.Count > 0)
                        {
                            foreach (GridViewDataColumn column in this.gridListMpiSync.Columns)
                            {
                                column.BestFit();
                            }
                        }
                        tmrPrint.Enabled = true;
                    }
                    catch (Exception EX)
                    {
                        exception = EX;
                        string strFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                        LogException(strFileName, EX.ToString());
                        //Refresh the Grid
                        this._dtbMpi = GetPrintJob();
                        this.gridListMpiSync.DataSource = this._dtbMpi;
                        if (this._dtbMpi.Rows.Count > 0)
                        {
                            foreach (GridViewDataColumn column in this.gridListMpiSync.Columns)
                            {
                                column.BestFit();
                            }
                        }
                        tmrPrint.Enabled = true;
                    }                
        }

        private void cmdPause_Click(object sender, EventArgs e)
        {
            //this.txtLog.Text = "";
            if (this.cmdPause.Text == "Pause")
            {
                this.tmrPrint.Enabled = false;
                this.cmdPause.Text = "Start";
                this.cmdPreview.Enabled = true;
            }
            else
            {
                this.tmrPrint.Enabled = true;
                this.cmdPause.Text = "Pause";
                this.cmdPreview.Enabled = false;
            }
        }

        private void SendPatientDataFromKencanaToMpi()
        {
 
        }

        private void SendNewKunjunganDataFromKencanaToMpi()
        {
 
        }

        private void SendUpdatedKunjunganDataFromKencanaToMpi()
        {

        }

        private void SendDischargeDataFromKencanaToMpi()
        {
 
        }

        private void LogException(string strFileName, string strContent)
        {
            StreamWriter writer = null;
            StringBuilder strBuilder = null;
            string dir = "C:\\LogError\\";
            //check folder exist
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            string strErrorTime = DateTime.Now.ToString();
            string path = Path.Combine(dir, strFileName + ".log");
            strBuilder = new StringBuilder("Log :");
            strBuilder.Append(strErrorTime + " | ");
            strBuilder.Append(strContent);

            writer = new StreamWriter(path, true);
            writer.Write(strBuilder);
            writer.Close();
        }
    }
}
