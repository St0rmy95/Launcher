using System;
using System.Runtime.InteropServices;

namespace Launcher
{
    public class Protocols
    {
        // General Packets
        public const ushort T_ERROR = (0xFE << 8) | 0x00;

        public const ushort T_PC_CONNECT_ALIVE = (0x10 << 8) | 0x03;

        //Server Group
        public const ushort T_PC_CONNECT_GET_SERVER_GROUP_LIST = (0x10 << 8) | 0x13;
        public const ushort T_PC_CONNECT_GET_SERVER_GROUP_LIST_OK = (0x10 << 8) | 0x14;

        // Single Version
        public const ushort T_PC_CONNECT_SINGLE_FILE_VERSION_CHECK = (0x10 << 8) | 0x10;
        public const ushort T_PC_CONNECT_SINGLE_FILE_VERSION_CHECK_OK = (0x10 << 8) | 0x11;
        public const ushort T_PC_CONNECT_SINGLE_FILE_UPDATE_INFO = (0x10 << 8) | 0x12;

        // Version
        public const ushort T_PC_CONNECT_VERSION = (0x10 << 8) | 0x04;
        public const ushort T_PC_CONNECT_UPDATE_INFO = (0x10 << 8) | 0x05;
        public const ushort T_PC_CONNECT_VERSION_OK = (0x10 << 8) | 0x06;
        public const ushort T_PC_CONNECT_REINSTALL_CLIENT = (0x10 << 8) | 0x07;

        //Login
        public const ushort T_PC_CONNECT_LOGIN = (0x10 << 8) | 0x08;
        public const ushort T_PC_CONNECT_LOGIN_OK = (0x10 << 8) | 0x09;
        public const ushort T_PC_CONNECT_LOGIN_BLOCKED = (0x10 << 8) | 0xF0;
    }

    public struct MSG_ERROR
    {
        public ushort MsgType;
        public ushort ErrorCode;
        public bool CloseConnection;
        public int ErrParam1;
        public int ErrParam2;
        public ushort StringLength;
    }

    public struct ATUM_DATE_TIME
    {
        ushort Year;
        char Month;
        char Day;
        char Hour;
        char Minute;
        char Second;

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2} {3:00}:{4:00}:{5:00}",(int)Day, (int)Month, Year, (int)Hour, (int)Minute, (int)Second);
        }
    }

    // Server Group
    public struct MEX_SERVER_GROUP_INFO_FOR_LAUNCHER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] ServerGroupName;
        public int Crowdedness;
    }

    public struct MSG_PC_CONNECT_GET_SERVER_GROUP_LIST_OK
    {
        public int NumOfServerGroup;
        public MEX_SERVER_GROUP_INFO_FOR_LAUNCHER ServerGroup;
    }

    // Server Check
    public struct MSG_PC_CONNECT_SINGLE_FILE_VERSION_CHECK
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] DeleteFileListVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] NoticeVersion;
    }

    public struct MSG_PC_CONNECT_SINGLE_FILE_UPDATE_INFO
    {
        public int nAutoUpdateServerType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] NewDeleteFileListVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] NewNoticeVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] FtpIP;
        public ushort FtpPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] FtpAccountName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] FtpPassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] DeleteFileListDownloadPath;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] NoticeFileDownloadPath;
    }

    // Version Check
    public struct MSG_PC_CONNECT_VERSION
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] ClientVersion;
    }

    public struct MSG_PC_CONNECT_UPDATE_INFO
    {
        public int nAutoUpdateServerType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] OldVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] UpdateVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] FtpIP;
        public ushort FtpPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] FtpAccountName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] FtpPassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] FtpUpdateDownloadDir;
    }

    public struct MSG_PC_CONNECT_REINSTALL_CLIENT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] LatestVersion;
    }

    // Login
    public struct MSG_PC_CONNECT_LOGIN_BLOCKED
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] szAccountName;
        public int nBlockedType;
        public ATUM_DATE_TIME atimeStart;
        public ATUM_DATE_TIME atimeEnd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public char[] szBlockedReasonForUser;
        [MarshalAs(UnmanagedType.Bool)]
        public bool IsMacBlocked;
    }

    public struct MSG_PC_CONNECT_LOGIN
    {
        public byte LoginType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] AccountName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Password;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] FieldServerGroupName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] PrivateIP;
        public int MGameSEX;
        public int MGameYear;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] WebLoginAuthKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] ClientIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] MACAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] SelectiveShutdownInfo;
    }

    public struct MSG_PC_CONNECT_LOGIN_OK
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] AccountName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] FieldServerIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] IMServerIP;
        public ushort FieldServerPort;
        public ushort IMServerPort;
        public bool OpeningMoviePlay;
        public bool ConnectToTestServer;
    }
}
