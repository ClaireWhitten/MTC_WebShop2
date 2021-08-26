using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTCrepository.TDSrepository
{
    public  abstract class _reposResult<TDSentity> where TDSentity : class
    {
        public bool Succeeded { get; set; } = true;
        public int SaveChangeCount { get; set; } = 0;
        public DbUpdateException DbUpdateException { get;  set; } = null;
        public TDSreposErrCode ErrorCode { get; set; } = TDSreposErrCode.OK;
        public int SqlErrorCode { get; set; } = 0;

        //------------------------------------------------------------------------
        public void setErrorCode(DbUpdateException aDbUpdateException)
        {
            ErrorCode = TDSreposErrCode.UNKNOW_ERROR;

            SqlException innerException = aDbUpdateException.InnerException as SqlException;
            if (innerException != null)
            {
                SqlErrorCode = innerException.Number;

                switch (innerException.Number)
                {
                    case 2601:
                        ErrorCode = TDSreposErrCode.DUPLICATE_KEY;
                        break;
                    case 547:
                        ErrorCode = TDSreposErrCode.FOREIGNKEY_CONFLICT;
                        break;
                    default:
                        ErrorCode = TDSreposErrCode.UNKNOW_ERROR;
                        break;
                }
                if (innerException != null && innerException.Number == 2601)
                {
                    ErrorCode = TDSreposErrCode.DUPLICATE_KEY;
                }
                else if (innerException != null && innerException.Number == 547)
                {
                    ErrorCode = TDSreposErrCode.FOREIGNKEY_CONFLICT;
                }
            }
        }
        public void setErrorCode(TDSreposErrCode aCode)
        {
            ErrorCode = aCode;
        }
    }

    //=================================================================================================================
    //=================================================================================================================
    public class TSDreposResultOneObject<TDSentity> : _reposResult<TDSentity> where TDSentity : class
    {
        public TDSentity Data { get;  set; } = null;

    }


    //=================================================================================================================
    //=================================================================================================================

    public class TSDreposResultIenumerable<TDSentity> : _reposResult<TDSentity> where TDSentity : class
    {
        public IEnumerable<TDSentity> Data { get;  set; } = null;

    }

    //=================================================================================================================
    //=================================================================================================================
}

