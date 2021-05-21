using System;

namespace PureModLoader.API.Logger
{
    public class Logger
    {
        #region Variables

        private string m_Name;
        private LogLevel m_Level;
        public string Name { get { return m_Name; } internal set { m_Name = value; } }
        public LogLevel Level { get { return m_Level; } internal set { m_Level = value; } }

        #endregion

        #region Constructor [Init]
        /// <summary>
        /// Initialize logger with [Name] and [Trace level]
        /// </summary>
        public Logger()
        {
            m_Name = "Name";
            m_Level = LogLevel.Trace;
        }

        /// <summary>
        /// Initialize logger with [Trace level]
        /// </summary>
        /// <param name="name">Logger name (shows in console)</param>
        public Logger(string name)
        {
            m_Name = name;
            m_Level = LogLevel.Trace;
        }

        /// <summary>
        /// Initialize logger
        /// </summary>
        /// <param name="name">Logger name (shows in console)</param>
        /// <param name="level">Loglevel</param>
        public Logger(string name, LogLevel level)
        {
            m_Name = name;
            m_Level = level;
        }

        #endregion

        #region Set
        /// <summary>
        /// Change logger name
        /// </summary>
        /// <param name="name">Logger name (shows in console)</param>
        public void SetName(string name) =>
            m_Name = name;

        /// <summary>
        /// Change logger LogLevel
        /// </summary>
        /// <param name="level">LogLevel</param>
        public void SetLevel(LogLevel level) =>
            m_Level = level;

        #endregion

        #region Log
        /// <summary>
        /// Log message to console with [Trace] level
        /// </summary>
        /// <param name="message">Object to log. It can be anything</param>
        public void Trace(object message)
        {
            if (m_Level >= LogLevel.Trace)
                InternalLog(message, ConsoleColor.White);
        }

        /// <summary>
        /// Log message to console with [Info] level
        /// </summary>
        /// <param name="message">Object to log. It can be anything</param>
        public void Info(object message)
        {
            if (m_Level >= LogLevel.Info)
                InternalLog(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Log message to console with [Warn] level
        /// </summary>
        /// <param name="message">Object to log. It can be anything</param>
        public void Warn(object message)
        {
            if (m_Level >= LogLevel.Warn)
                InternalLog(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Log message to console with [Error] level
        /// </summary>
        /// <param name="message">Object to log. It can be anything</param>
        public void Error(object message)
        {
            if (m_Level >= LogLevel.Error)
                InternalLog(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Log message to console with [Critical] level
        /// </summary>
        /// <param name="message">Object to log. It can be anything</param>
        public void Critical(object message)
        {
            if (m_Level >= LogLevel.Critical)
                InternalLog(message, ConsoleColor.White, ConsoleColor.Red);
        }

        private void Log(object message, LogLevel level)
        {
            if (level == LogLevel.Trace)
                Trace(message);
            else if (level == LogLevel.Info)
                Info(message);
            else if (level == LogLevel.Warn)
                Warn(message);
            else if (level == LogLevel.Error)
                Error(message);
            else if (level == LogLevel.Critical)
                Critical(message);
        }

        #endregion

        #region Internal

        private void InternalLog(object message, ConsoleColor foreColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            SetForeground();
            Console.Write("[");
            SetForeground(ConsoleColor.Blue);
            Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
            SetForeground();
            Console.Write("] [");
            SetForeground(ConsoleColor.Red);
            Console.Write(m_Name);
            SetForeground();
            Console.Write("] ");
            SetForeground(foreColor);
            SetBackground(backColor);
            Console.Write(message);
            SetBackground();
            SetForeground();
            Console.WriteLine();
        }

        private void SetForeground(ConsoleColor color = ConsoleColor.White) =>
            Console.ForegroundColor = color;

        private void SetBackground(ConsoleColor color = ConsoleColor.Black) =>
            Console.BackgroundColor = color;

        #endregion

    }
}
