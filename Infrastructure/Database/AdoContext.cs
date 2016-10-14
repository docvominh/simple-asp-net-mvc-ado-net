using log4net;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Infrastructure.Database
{
    /*
    Use the DataSet in order to do the following with your application:
    - Navigate between multiple discrete tables of results.
    - Manipulate data from multiple sources (for example, a mixture of data from more than one database, from an XML file, and from a spreadsheet).
    - Exchange data between tiers or using an XML Web service. Unlike the DataReader, the DataSet can be passed to a remote client.
    - Reuse the same set of rows to achieve a performance gain by caching them (such as for sorting, searching, or filtering the data).
    - Perform a large amount of processing per row. Extended processing on each row returned using a DataReader ties up the connection serving the DataReader longer than necessary, impacting performance.
    - Manipulate data using XML operations such as Extensible Stylesheet Language Transformations (XSLT transformations) or XPath queries.
    Use the DataReader in your application if you:
    - Do not need to cache the data.
    - Are processing a set of results too large to fit into memory.
    - Need to quickly access data once, in a forward-only and read-only manner.
    - Note The DataAdapter uses the DataReader when filling a DataSet. Therefore, the performance gained by using the DataReader instead of the DataSet
      is that you save on the memory that the DataSet would consume and the cycles it takes to populate the DataSet. This performance gain is,
      for the most part, nominal so you should base your design decisions on the functionality required.

    using this class
     using (AdoContext ado = new AdoContext())
    {
    }
*/

    public class AdoContext : IDisposable
    {
        // Flag: Has Dispose already been called?
        private bool disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Define connection
        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ADOConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public DataTable GetData(string procedureName)
        {
            DataTable table = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Create command
                    SqlCommand cm = new SqlCommand(procedureName, conn);
                    cm.CommandType = CommandType.StoredProcedure;

                    // Open connection
                    conn.Open();

                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                catch (Exception Ex)
                {
                    log.Error(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return table;
        }

        public DataTable GetData(string procedureName, List<SqlParameter> listParam)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Create command
                    SqlCommand cm = new SqlCommand(procedureName, conn);
                    cm.CommandType = CommandType.StoredProcedure;
                    if (listParam != null)
                    {
                        foreach (SqlParameter p in listParam)
                        {
                            cm.Parameters.Add(p);
                        }
                    }

                    // Open connection
                    conn.Open();

                    using (SqlDataReader reader = cm.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                catch (Exception Ex)
                {
                    log.Error(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return table;
        }

        public bool UpdateData(string procedureName, List<SqlParameter> listParam)
        {
            bool status = true;
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Create command
                    SqlCommand cm = new SqlCommand(procedureName, conn);
                    cm.CommandType = CommandType.StoredProcedure;
                    if (listParam != null)
                    {
                        foreach (SqlParameter p in listParam)
                        {
                            cm.Parameters.Add(p);
                        }
                    }

                    // Open connection
                    conn.Open();

                    cm.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    status = false;
                    log.Error(Ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return status;
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}