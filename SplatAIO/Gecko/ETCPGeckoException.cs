using System;

namespace SplatAIO.Gecko
{
    public enum ETCPErrorCode
    {
        FTDIQueryError,
        noFTDIDevicesFound,
        noTCPGeckoFound,
        FTDIResetError,
        FTDIPurgeRxError,
        FTDIPurgeTxError,
        FTDITimeoutSetError,
        FTDITransferSetError,
        FTDICommandSendError,
        FTDIReadDataError,
        FTDIInvalidReply,
        TooManyRetries,
        REGStreamSizeInvalid,
        CheatStreamSizeInvalid
    }

    public class ETCPGeckoException : Exception
    {
        private ETCPErrorCode PErrorCode;
        public ETCPErrorCode ErrorCode
        {
            get
            {
                return PErrorCode;
            }
        }

        public ETCPGeckoException(ETCPErrorCode code)
            : base()
        {
            PErrorCode = code;
        }
        public ETCPGeckoException(ETCPErrorCode code, string message)
            : base(message)
        {
            PErrorCode = code;
        }
        public ETCPGeckoException(ETCPErrorCode code, string message, Exception inner)
            : base(message, inner)
        {
            PErrorCode = code;
        }
    }
}
