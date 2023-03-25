
using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Project.DataLayer.Contracts;
using Project.DataLayer.Model;

namespace Project.DataLayer.DataAccessLayer
{
    public class DAL : IDAL
    {
        private readonly AppSettingsForConnectionString _appSettings;
        protected readonly string _ConStr;

        public DAL(IOptions<AppSettingsForConnectionString> appSettings)
        {
            _appSettings = appSettings.Value;
            _ConStr = _appSettings.DbCon;
        }

        #region IDAL
        public void Execute(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public void Execute(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public void Execute(string CommandName, Hashtable param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    foreach (DictionaryEntry de in param)
                    {
                        cmd.Parameters.AddWithValue(de.Key.ToString(), de.Value);
                    }
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public void ExecuteProcedure(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public void ExecuteProcedure(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable Get(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable Get(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetByProcedure(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetByProcedure(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    cmd.CommandTimeout = 10 * 60;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetByProcedureAdapter(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(dt);
                    }
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataSet GetByProcedureAdapterDS(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    DataSet ds = new DataSet();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                    return ds;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public DataSet GetByProcedureAdapterDS(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                    }
                    return ds;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        #endregion
        #region IDALAsync
        public async Task ExecuteAsync(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task ExecuteAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task ExecuteAsync(string CommandName, Hashtable param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    foreach (DictionaryEntry de in param)
                    {
                        cmd.Parameters.AddWithValue(de.Key.ToString(), de.Value);
                    }
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task ExecuteProcedureAsync(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        await cmd.Connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cmd.Connection.Close();

                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task ExecuteProcedureAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    if (cmd.Connection.State == ConnectionState.Closed)
                        await cmd.Connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cmd.Connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataTable> GetAsync(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                    }
                    conn.Close();
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataTable> GetAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.Text;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                    }
                    conn.Close();
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataTable> GetByProcedureAsync(string CommandName)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                    }
                    conn.Close();
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataTable> GetByProcedureAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                    if (conn.State == ConnectionState.Closed)
                        await conn.OpenAsync();
                    DataTable dt = new DataTable();
                    using (IDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                    }
                    conn.Close();
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataTable> GetByProcedureAdapterAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    return await Task.Run(() =>
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                        return dt;
                    });
                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        public async Task<DataSet> GetByProcedureAdapterDSAsync(string CommandName, SqlParameter[] param)
        {
            if (string.IsNullOrWhiteSpace(CommandName))
            {
                throw new ArgumentException("Cannot be empty", nameof(CommandName));
            }
            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                SqlCommand cmd = new SqlCommand(CommandName, conn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                    return await Task.Run(() =>
                    {
                        DataSet ds = new DataSet();
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                        }
                        return ds;
                    });

                }
                catch (SqlException ex)
                {
                    throw new Exception("Execption from db:" + ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                    cmd.Connection.Dispose();
                    conn.Close();
                }
            }
        }
        #endregion
    }
}

