using System;

namespace Common
{
    public enum EndOfLine : byte
    {
        MacOS,
        Dos,
        Unix
    }

    public static class EndOfLineConstants
    {
        public static readonly string CRLF = "\r\n";
        public static readonly string CR = "\r";
        public static readonly string LF = "\n";
        public static readonly string DOS = CRLF;
        public static readonly string MACOS = CR;
        public static readonly string UNIX = LF;
        public static readonly string LINUX = UNIX;
    }

    public static class TextEncoding
    {
        public static EndOfLine DetectEndOfLine(string text)
        {
            if (text.Contains(EndOfLineConstants.DOS))
            {
                return EndOfLine.Dos;
            }
            else if (text.Contains(EndOfLineConstants.UNIX))
            {
                return EndOfLine.Unix;
            }
            else
            {
                return EndOfLine.MacOS;
            }
        }

        public static string FixEndOfLine(string text)
        {
            switch (DetectEndOfLine(text))
            {
                case EndOfLine.Dos:
                    return text.Replace(EndOfLineConstants.DOS,
                        Environment.NewLine);

                case EndOfLine.MacOS:
                    return text.Replace(EndOfLineConstants.MACOS,
                        Environment.NewLine);

                default:
                    return text.Replace(EndOfLineConstants.UNIX,
                        Environment.NewLine);
            }
        }
    }
}
