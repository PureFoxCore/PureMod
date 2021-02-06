using System;

namespace PureMod.API.Logger
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

        public Logger()
        {
            m_Name = "Name";
            m_Level = LogLevel.Trace;
        }

        public Logger(string name)
        {
            m_Name = name;
            m_Level = LogLevel.Trace;
        }

        public Logger(string name, LogLevel level)
        {
            m_Name = name;
            m_Level = level;
        }

        #endregion

        #region Set

        public void SetName(string name) =>
            m_Name = name;
        public void SetLevel(LogLevel level) =>
            m_Level = level;

        #endregion

        #region Log

        public void Trace(object message)
        {
            if (m_Level >= LogLevel.Trace)
                InternalLog(message, ConsoleColor.White);
        }

        public void Info(object message)
        {
            if (m_Level >= LogLevel.Info)
                InternalLog(message, ConsoleColor.Green);
        }

        public void Warn(object message)
        {
            if (m_Level >= LogLevel.Warn)
                InternalLog(message, ConsoleColor.Yellow);
        }

        public void Error(object message)
        {
            if (m_Level >= LogLevel.Error)
                InternalLog(message, ConsoleColor.Red);
        }

        public void Critical(object message)
        {
            if (m_Level >= LogLevel.Critical)
                InternalLog(message, ConsoleColor.White, ConsoleColor.Red);
        }

        public void Log(object message, LogLevel level)
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
