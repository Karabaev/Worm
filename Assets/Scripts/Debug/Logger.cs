namespace Game.Debug
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.Text;
    using System.IO;
    using System;
    public enum LogTypes
    {
        Info = 1,
        Warning = 2,
        Error = 3
    }

    /// <summary>
    /// Класс-обертка класса Debug для упрощения логирования при отладке.
    /// </summary>
    public static class Logger
    {
        private static string logFileName = "Debug/Debug.log";

        private static void Log(LogTypes type, GameObject sender, string log)
        {
            log = string.Format("{0} Объект: {1}", log, sender);
            Display(type, log);
            WriteToFile(type, log);
        }

        private static void Log(LogTypes type, GameObject sender, string format, params object[] args)
        {
            string log = string.Format(format, args);
            log = string.Format("{0} Объект: {1}", log, sender.name);
            Display(type, log);
            WriteToFile(type, log);
        }

        public static void LogInfo(GameObject sender, string log)
        {
            Log(LogTypes.Info, sender, log);
        }

        public static void LogWarning(GameObject sender, string log)
        {
            Log(LogTypes.Warning, sender, log);
        }

        public static void LogError(GameObject sender, string log)
        {
            Log(LogTypes.Error, sender, log);
        }

        public static void CheckReference(GameObject sender, object obj)
        {
            if(obj == null)
            {
                LogError(sender, "Ссылка на объект не инициализирована.");
            }
        }

        private static void Display(LogTypes type, string log)
        {
            switch (type)
            {
                case LogTypes.Info:
                    Debug.Log(log);
                    break;
                case LogTypes.Warning:
                    Debug.LogWarning(log);
                    break;
                case LogTypes.Error:
                    Debug.LogError(log);
                    break;
                default:
                    break;
            }
        }
        private static void WriteToFile(LogTypes type, string log)
        {
            log = string.Format("{0}: {1}! {2}\n", DateTime.Now, type.ToString(), log);
            using (FileStream stream = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
            {
                byte[] bytes = Encoding.Default.GetBytes(log);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
        }
    }
}

