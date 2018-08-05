using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace USLBM.Mobile.Common
{
    public abstract class Repository<TLoadParam, TEntity> 
    {
        //public static readonly log4net.ILog Logger =
        //    log4net.LogManager.GetLogger(typeof(Repository<TLoadParam,TEntity>));
        public delegate TEntity ExecuteReaderDelegate(IDataReader reader, TEntity entity);
        public delegate TLoadParam ExecuteDataSetDelegate(DataSet dataSet, TLoadParam entity);
        public delegate DbCommand PrepareCommandForLoadDelegate(Database db, TLoadParam id);
        public delegate DbCommand PrepareCommandForSaveDelegate(Database db, TEntity entity);
        public delegate TEntity ReadCommandParametersDelegate(Database db, DbCommand command, TEntity entity);
        
        

        readonly string databaseConnectionString;
        Database database;

        public Repository(string databaseConnectionString)
        {
            // @"Server=PrimeCareDev.centralus.cloudapp.azure.com,1433;Initial Catalog=PeriVision;Integrated Security=false;User ID=sa;Password=Bl4DKO%a$eCi;TrustServerCertificate=False"; //
            this.databaseConnectionString =  databaseConnectionString;
            database = DatabaseFactory.CreateDatabase(databaseConnectionString);
           
        }

        protected TEntity Load(TLoadParam id, PrepareCommandForLoadDelegate prepareCommandMethod, ExecuteReaderDelegate executeReaderMethod)
        {
            return Load(id, prepareCommandMethod, executeReaderMethod, null);
        }

        protected TEntity Load(TLoadParam id, PrepareCommandForLoadDelegate prepareCommandMethod, 
            ExecuteReaderDelegate executeReaderMethod, ReadCommandParametersDelegate readCommandParametersMethod)
        {
            TEntity entity = default(TEntity);
            try
            {
                DbCommand command = prepareCommandMethod(database, id);
                var reader = database.ExecuteReader(command);
                while (reader.Read())
                {
                    entity = executeReaderMethod(reader, entity);
                }

                if(readCommandParametersMethod != null)
                    entity = readCommandParametersMethod(database, command, entity);
            }
            catch (Exception ex)
            {
                // Logger.Error(ex != null ? ex.ToString() : "Unknown Error in Repository.Load()");
                return default(TEntity);
            }
            return entity;
        }
        protected TLoadParam LoadParentChild(TLoadParam entity, PrepareCommandForLoadDelegate prepareCommandMethod,
            ExecuteDataSetDelegate executeDataSetMethod, ReadCommandParametersDelegate readCommandParametersMethod)
        {
           
            try
            {
                DbCommand command = prepareCommandMethod(database, entity);
                var reader = database.ExecuteDataSet(command);
                entity = executeDataSetMethod(reader, entity);

            }
            catch (Exception ex)
            {
                // Logger.Error(ex != null ? ex.ToString() : "Unknown Error in Repository.LoadParentChild()");
                return default(TLoadParam);
            }
            return entity;
        }

        protected List<TEntity> LoadList(TLoadParam id, PrepareCommandForLoadDelegate prepareCommandMethod,
            ExecuteReaderDelegate executeReaderMethod)
        {
            return LoadList(id, prepareCommandMethod, executeReaderMethod, null);
        }

        protected List<TEntity> LoadList(TLoadParam id, PrepareCommandForLoadDelegate prepareCommandMethod,
            ExecuteReaderDelegate executeReaderMethod, ReadCommandParametersDelegate readCommandParametersMethod)
        {
            List<TEntity> entityList = new List<TEntity>();
            TEntity entity = default(TEntity);
            try
            {
                DbCommand command = prepareCommandMethod(database, id);
                var reader = database.ExecuteReader(command);
                while (reader.Read())
                {
                    entity = executeReaderMethod(reader, entity);
                    entityList.Add(entity);
                }

                if (readCommandParametersMethod != null)
                    entity = readCommandParametersMethod(database, command, entity);
            }
            catch (Exception ex)
            {
                // Logger.Error(ex != null ? ex.ToString() : "Unknown Error in Repository.LoadList()");
                return entityList;
            }
            return entityList;
        }

        protected TEntity Save(TEntity entity, PrepareCommandForSaveDelegate prepareCommandMethod, 
            ReadCommandParametersDelegate readCommandParametersMethod)
        {
            try
            {
                DbCommand command = prepareCommandMethod(database, entity);

                database.ExecuteNonQuery(command);

                if (readCommandParametersMethod != null)
                    entity = readCommandParametersMethod(database, command, entity);
            }
            catch (Exception ex)
            {
                // Logger.Error(ex != null ? ex.ToString() : "Unknown Error in Repository.Save()");
            }
            return entity;
        }

        protected bool IsUserProfileChanged(string emaiid, DateTime timelastLogin)
        {
            return false;
        }

        protected string GetString(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetString(ordinal);
            return null;
        }

        protected int GetInt(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetInt32(ordinal);
            return default(int);
        }

        protected Int64 GetInt64(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetInt64(ordinal);
            return default(Int64);
        }

        protected Int16 GetInt16(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetInt16(ordinal);
            return default(Int16);
        }

        protected DateTime GetDateTime(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetDateTime(ordinal);
            return default(DateTime);
        }

        protected bool GetBoolean(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetBoolean(ordinal);
            return default(bool);
        }

        protected Decimal GetDecimal(IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            if (reader.GetValue(ordinal) != DBNull.Value)
                return reader.GetDecimal(ordinal);
            return default(Decimal);
        }
        protected string GetString(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return dataRow[name].ToString();
            return null;
        }

        protected int GetInt(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToInt32(dataRow[name]);
            return default(int);
        }

        protected Int64 GetInt64(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToInt64(dataRow[name]);
            return default(Int64);
        }

        protected Int16 GetInt16(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToInt16(dataRow[name]);
            return default(Int16);
        }

        protected DateTime GetDateTime(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToDateTime(dataRow[name]);
            return default(DateTime);
        }
        protected string GetTime(DataRow dataRow, string name)
        {
            DateTime time=default(DateTime);
            if (dataRow[name] != DBNull.Value)
            {
                time = DateTime.Parse(dataRow[name].ToString());
                return time.ToString("hh:mm:ss tt");
            }
            return null;
        }

        protected bool GetBoolean(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToBoolean(dataRow[name]);
            return default(bool);
        }

        protected Decimal GetDecimal(DataRow dataRow, string name)
        {
            if (dataRow[name] != DBNull.Value)
                return Convert.ToDecimal(dataRow[name]);
            return default(Decimal);
        }
    }
}
