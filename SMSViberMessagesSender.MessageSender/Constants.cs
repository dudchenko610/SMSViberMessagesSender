namespace SMSViberMessagesSender.MessageSender;

public static class Constants
{
    public static class SmsFlyActions
    {
        public const string GETBALANCE = "GETBALANCE";
        public const string GETSOURCES = "GETSOURCES";
        public const string GETPRICELIST = "GETPRICELIST";
        public const string SENDMESSAGE = "SENDMESSAGE";
        public const string GETMESSAGESTATUS = "GETMESSAGESTATUS";
    }
    
    public static class AppSettings
    {
        public const string SMS_FLY_CONFIGURATION = "SMSFlyConfiguration";
    }
}