using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Transactions;
using System.Linq;
using System.Data.Common;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing.Imaging;

namespace OpenFIGI_API
{
    public class InstrumentDB
    {



        private static  string STORED_PROC
        {
            get
            {
                return "JR_TEST_PKG.SEC_DES_TO_ISIN_SP";
            }
        }
        private static string cnxStr
        {
            get
            {
                return "Data Source=" +
                "                  (DESCRIPTION =" +
                "                           (ADDRESS = (PROTOCOL = TCP)(HOST = mchn.uk.ldn)(PORT = 0000))" +
                "                       (CONNECT_DATA=" +
                "                           (SERVER = DEDICATED)" +
                "                           (SERVICE_NAME = srcvnm)" +
                "                       )" +
                "                  );" +
                "User Id=usr;" +
                "Password=psd;";
            }
        }

        public static List<string> SecIDtoISIN(List<string> secIDlist)
        {
            List<string> ISINlist;
            string[] secIDArr = secIDlist.ToArray();
            using (OracleConnection cn = new OracleConnection(cnxStr))
            {
                OracleDataAdapter da = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.InitialLONGFetchSize = 1000;
                cmd.CommandText = STORED_PROC;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter
                {
                    ParameterName = "SECDES_LIST",
                    OracleDbType = OracleDbType.Varchar2,
                    CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                    Value = secIDArr
                }
                );
                cmd.Parameters.Add("ISIN_DATA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("ERROR_MSG", OracleDbType.Varchar2).Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                ISINlist = new List<string>();
                foreach (DataRow rw in dt.Rows)
                {
                    ISINlist.Add(rw["ISIN"].ToString());
                }
            }
            return ISINlist;
        }


        public static List<string> SecIDtoISIN_TEST(List<string> secIDlist)
        {

            List<string> ISINlist;

            string[] secIDArr = secIDlist.ToArray();

            switch (6)
            {
                case 1:
                    string cmndTxt = $"BEGIN {STORED_PROC}(:SECDES_TBL :ISIN_DATA); END;";
                    using (OracleConnection cnx = new OracleConnection(cnxStr))
                    {
                        using (OracleCommand cmnd = new OracleCommand("SELECT SYSDATE FROM DUAL", cnx))
                        {
                            cnx.Open();
                            OracleDataReader rdr = cmnd.ExecuteReader();
                            List<string> results = new List<string>();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    results.Add(rdr[0].ToString());
                                }
                            }

                        }
                    }
                    break;

                case 4:

                    using (OracleConnection cn = new OracleConnection(cnxStr))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = cn;
                        cmd.InitialLONGFetchSize = 1000;
                        cmd.CommandText = "JR_TEST_PKG.JR_TEST_SP1";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("ISIN_DATA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ISINlist = new List<string>();
                        foreach (DataRow rw in dt.Rows)
                        {
                            ISINlist.Add(rw["ISIN"].ToString());
                        }
                    }
                    break;

                case 5:

                    using (OracleConnection cn = new OracleConnection(cnxStr))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = cn;
                        cmd.InitialLONGFetchSize = 1000;
                        cmd.CommandText = "JR_TEST_PKG.JR_TEST_SP2";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "SECDES_LIST",
                            OracleDbType = OracleDbType.Varchar2,
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = secIDArr
                        }
                        );

                        cmd.Parameters.Add("ISIN_DATA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ISINlist = new List<string>();
                        foreach (DataRow rw in dt.Rows)
                        {
                            ISINlist.Add(rw["ISIN"].ToString());
                        }
                    }
                    break;

                case 6:

                    using (OracleConnection cn = new OracleConnection(cnxStr))
                    {
                        OracleDataAdapter da = new OracleDataAdapter();
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = cn;
                        cmd.InitialLONGFetchSize = 1000;
                        cmd.CommandText = STORED_PROC;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = "SECDES_LIST",
                            OracleDbType = OracleDbType.Varchar2,
                            CollectionType = OracleCollectionType.PLSQLAssociativeArray,
                            Value = secIDArr
                        }
                        );
                        cmd.Parameters.Add("ISIN_DATA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("ERROR_MSG", OracleDbType.Varchar2).Direction = ParameterDirection.Output;

                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ISINlist = new List<string>();
                        foreach (DataRow rw in dt.Rows)
                        {
                            ISINlist.Add(rw["ISIN"].ToString());
                        }
                    }
                    break;

                default:
                    break;
            }



            //ISINlist = secIDlist;
            return ISINlist;
        }


    }
}
