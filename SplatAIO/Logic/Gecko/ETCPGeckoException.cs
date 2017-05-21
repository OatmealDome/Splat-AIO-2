using System;

namespace SplatAIO.Logic.Gecko
{
    public enum EtcpErrorCode
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
        public ETCPGeckoException(EtcpErrorCode code)
        {
            ErrorCode = code;
        }

        public ETCPGeckoException(EtcpErrorCode code, string message)
            : base(message)
        {
            ErrorCode = code;
        }

        public ETCPGeckoException(EtcpErrorCode code, string message, Exception inner)
            : base(message, inner)
        {
            ErrorCode = code;
        }

        public EtcpErrorCode ErrorCode { get; }
    }
}