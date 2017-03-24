using System;

namespace SplatAIO.Logic.Gecko
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
        public ETCPGeckoException(ETCPErrorCode code)
        {
            ErrorCode = code;
        }

        public ETCPGeckoException(ETCPErrorCode code, string message)
            : base(message)
        {
            ErrorCode = code;
        }

        public ETCPGeckoException(ETCPErrorCode code, string message, Exception inner)
            : base(message, inner)
        {
            ErrorCode = code;
        }

        public ETCPErrorCode ErrorCode { get; }
    }
}