namespace PureModLoader.API.Logger
{
    /// <summary>
    /// Level of logging
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Minimum level, contains only critical logs
        /// </summary>
        Critical,
        /// <summary>
        /// More than minimum level, contains: [critical and error]
        /// </summary>
        Error,
        /// <summary>
        /// Medium log level, contains: [critical, error and warn]
        /// </summary>
        Warn,
        /// <summary>
        /// Less than maximun level, contains: [critical, error, warn and Info]
        /// </summary>
        Info,
        /// <summary>
        /// Maximum level, contains all logs
        /// </summary>
        Trace
    }
}
