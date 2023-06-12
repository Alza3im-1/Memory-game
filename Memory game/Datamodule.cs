using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;

namespace Memory_game
{
    public partial class Datamodule : IDisposable
    {
        // be:at 78.46.109.3 SYS Diogenes 

        // die Connection
        public FbConnection fbConnection;

        // Das Dataset
        public DataSet ds = new DataSet();

        // Konstruktor
        public Datamodule(string usr, string pw, string db, string datasource, int port)
        {
            FbConnectionStringBuilder fb = new FbConnectionStringBuilder();

            fb.UserID = usr;
            fb.Password = pw;
            fb.Role = "beat_standard";
            fb.Database = db;
            fb.DataSource = datasource;
            fb.Port = port;
            fb.Dialect = 3;
            fb.Charset = "ISO8859_1";
            fb.ConnectionLifeTime = 0;
            fb.ConnectionTimeout = 15;
            fb.Pooling = true;
            fb.PacketSize = 8192;
            fb.ServerType = FbServerType.Default;

            fbConnection = new FbConnection(fb.ToString());
        }

        // Destruktor, Dispose() und FinalizeInstance()
        ~Datamodule()
        {
            FinalizeInstance();
        }
        public void Dispose()
        {
            FinalizeInstance();
            GC.SuppressFinalize(this);
        }

        private void FinalizeInstance()
        {
            /*
                FbConnection.ClearPool(fbConnection);
            */
            try
            {
                if (fbConnection.State == ConnectionState.Open)
                {
                    FbConnection.ClearPool(fbConnection);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        // Allgemeine Konstanten
        TimeSpan OneDay = new TimeSpan(1, 0, 0, 0);

        // Allgemeine Variablen
        public string usr = string.Empty;

        // Allgemeine Methoden
        public string GetSQLType(Type dotNetType)
        {
            if (dotNetType == typeof(DateTime))
                return "TIMESTAMP";
            if (dotNetType == typeof(Char))
                return "CHAR(1)";
            if (dotNetType == typeof(Boolean))
                return "BOOLEAN"; // BOOLEAN ist kein Datentyp - es ist eine Domain
            if (dotNetType == typeof(Single))
                return "FLOAT";
            if (dotNetType == typeof(Double))
                return "DOUBLE PRECISION";
            if (dotNetType == typeof(SByte) || dotNetType == typeof(Byte) || dotNetType == typeof(Int16))
                return "SMALLINT";
            if (dotNetType == typeof(UInt16) || dotNetType == typeof(Int32))
                return "INTEGER";
            if (dotNetType == typeof(UInt32) || dotNetType == typeof(Int64))
                return "BIGINT";
            return null;
        }
        public string GetServerVersion()
        {
            string sv = string.Empty;
            try
            {
                fbConnection.Open();
                sv = fbConnection.ServerVersion;
                fbConnection.Close();
            }
            catch (FbException ex)
            {
                sv = "ERROR : " + ex.Message;
            }
            return (sv);
        }
        public string GetDatabaseName()
        {
            string sv = string.Empty;
            try
            {
                fbConnection.Open();
                sv = fbConnection.Database;
                fbConnection.Close();
            }
            catch (Exception ex)
            {
                sv = "ERROR : " + ex.Message;
            }
            return (sv);
        }
        public string GetDatasourceName()
        {
            string sv = string.Empty;
            try
            {
                fbConnection.Open();
                sv = fbConnection.DataSource;
                fbConnection.Close();
            }
            catch (Exception ex)
            {
                sv = "ERROR : " + ex.Message;
            }
            return (sv);
        }
        public void ExecuteSimpleDML(string sql)
        {
            FbCommand command = new FbCommand();
            command.Connection = fbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            fbConnection.Open();
            try
            {
                command.Transaction = fbConnection.BeginTransaction();
                command.Prepare();
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (FbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fbConnection.Close();
            }
        }
        public void ExecuteSimpleDML(ref FbCommand cmd)
        {
            cmd.Connection = fbConnection;
            cmd.CommandType = CommandType.Text;
            fbConnection.Open();
            try
            {
                cmd.Transaction = fbConnection.BeginTransaction();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            finally
            {
                fbConnection.Close();
            }
        }

        public object GetSimpleScalar(string sql)
        {
            //Anwendungsbeispiel:
            //double cnt = 0.0;
            //cnt = (double)dm.GetSimpleScalar("select avg(koeff_val) from ac_koeffizienten");

            object n;
            FbCommand command = new FbCommand();
            command.Connection = fbConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;

            fbConnection.Open();
            try
            {
                command.Prepare();
                command.Transaction = fbConnection.BeginTransaction();
                n = command.ExecuteScalar();
                command.Transaction.Commit();
            }
            finally
            {
                fbConnection.Close();
            }

            return (n);
        }
        public object GetSimpleScalar(ref FbCommand cmd)
        {
            //Anwendungsbeispiel:
            //double cnt = 0.0;
            //cnt = (double)dm.GetSimpleScalar("select avg(koeff_val) from ac_koeffizienten");

            object n;

            cmd.Connection = fbConnection;
            cmd.CommandType = CommandType.Text;

            fbConnection.Open();
            try
            {
                cmd.Prepare();
                cmd.Transaction = fbConnection.BeginTransaction();
                n = cmd.ExecuteScalar();
                cmd.Transaction.Commit();
            }
            finally
            {
                fbConnection.Close();
            }

            return (n);
        }

        public void ExecuteScript(string sqlScript, bool autoCommit)
        {
            //Es war im �ltern Virsion So aber in neuen will die methode kein Steringreader die akzipter jetz nur sttring 
            //FbScript script = new FbScript(new StringReader(sqlScript));
            FbScript script = new FbScript(sqlScript);
            script.Parse();
            fbConnection.Open();
            try
            {
                //war fr�her so und wei� genau nicht was der macht aber hab script gel�scht und hat es funktionert 
                //FbBatchExecution batch = new FbBatchExecution(fbConnection, script);
                FbBatchExecution batch = new FbBatchExecution(fbConnection);

                // habe den appendsqlStatements gerufen um zu test ob f�nktioner 
                // im Firebird clint 2.5.2.0 Wirde alles ist fbbatchexecution metode gemacht ich glaube in neue virsion w�rde eigen methode erstellt 
                //
                //
                //test
                batch.AppendSqlStatements(script);
                //
                //
                batch.Execute(autoCommit);
            }
            catch
            {
                //
            }
            finally
            {
                fbConnection.Close();
            }
        }
        public void ExecuteBatch(IList<string> sqlStatements, bool autoCommit)
        {
            fbConnection.Open();
            try
            {
                //war fr�her so und wei� genau nicht was der macht aber hab script gel�scht und hat es funktionert 
                //FbBatchExecution batch = new FbBatchExecution(fbConnection, script);
                FbBatchExecution batch = new FbBatchExecution(fbConnection);

                foreach (string statement in sqlStatements)
                {

                    // wird  Kommentiert weil wei� genau nicht was der macht 
                    //batch.SqlStatements.Add(statement);
                }
                batch.Execute(autoCommit);
            }
            finally
            {
                fbConnection.Close();
            }
        }
        public void ExecuteBatch(string sqlScriptFilePath, bool autoCommit)
        {
            FbScript script = new FbScript(sqlScriptFilePath);
            script.Parse();
            fbConnection.Open();
            try
            {
                ////war fr�her so und wei� genau nicht was der macht aber hab script gel�scht und hat es funktionert 
                /////FbBatchExecution batch = new FbBatchExecution(fbConnection, script);
                FbBatchExecution batch = new FbBatchExecution(fbConnection);
                //
                //
                //
                //test
                batch.AppendSqlStatements(script);
                //
                //
                //



                batch.Execute(autoCommit);
            }
            finally
            {
                fbConnection.Close();
            }
        }
        public void ExecuteBatch(TextReader reader, bool autoCommit)
        {
            FbScript script = new FbScript(reader.ToString());
            script.Parse();
            fbConnection.Open();
            try
            {
                FbBatchExecution batch = new FbBatchExecution(fbConnection);
                batch.Execute(autoCommit);
            }
            finally
            {
                fbConnection.Close();
            }
        }



        protected string[] BuildSchemaQueryRestrictions(string table_catalog, string table_schema, string table_name, string table_type)
        {
            return new string[] { table_catalog, table_schema, table_name, table_type };
        }
        public bool TableExists(string tableName, bool caseSensitiveName)
        {
            fbConnection.Open();
            try
            {
                if (!caseSensitiveName)
                {
                    tableName = tableName.ToUpperInvariant();
                }
                DataTable dt = fbConnection.GetSchema("TABLES", BuildSchemaQueryRestrictions(null, null, tableName, null));
                using (DataTableReader dtr = dt.CreateDataReader())
                {
                    return dtr.Read();
                }
            }
            finally
            {
                fbConnection.Close();
            }
        }

        public void LoadData2Table(string sql_string, string tablename)
        {
            using (FbCommand listcmd = new FbCommand())
            {
                listcmd.Connection = fbConnection;
                listcmd.CommandType = CommandType.Text;
                listcmd.CommandText = sql_string;

                using (FbDataAdapter daplist = new FbDataAdapter())
                {
                    ResetTable(ref ds, tablename);

                    daplist.SelectCommand = listcmd;
                    if (fbConnection.State == ConnectionState.Closed)
                    {
                        fbConnection.Open();
                    }
                    try
                    {
                        daplist.SelectCommand.Prepare();
                        listcmd.Transaction = fbConnection.BeginTransaction();
                        daplist.Fill(ds, tablename);
                        listcmd.Transaction.Commit();
                    }
                    finally
                    {
                        fbConnection.Close();
                    }
                }
            }
        }




        public void ResetTable(ref DataSet ds, string tableName)
        {
            int tableIndex = ds.Tables.IndexOf(tableName);
            if (tableIndex != -1)
            {
                for (int i = ds.Tables[tableIndex].Rows.Count - 1; i >= 0; i--)
                {
                    ds.Tables[tableIndex].Rows[i].Delete();
                }
                ds.Tables[tableIndex].AcceptChanges();
            }
        }
        public void RemoveTable(ref DataSet ds, string tableName)
        {
            if (ds.Tables.Contains(tableName))
            {
                try
                {
                    ds.Tables.Remove(tableName);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }
    }
}