using System;
using System.Drawing;
using System.Windows.Forms;

namespace Common
{
    public enum TaskBarPosition
    {
        Left,
        Right,
        Top,
        Bottom,
        Hidden,
        Unknown
    }

    public class TaskBar
    {
        public static TaskBarPosition Position
        {
            get
            {
                Screen s = Screen.FromPoint(Cursor.Position);
                if (s.WorkingArea.Width == s.Bounds.Width
                    && s.WorkingArea.Height == s.Bounds.Height)
                {
                    return TaskBarPosition.Hidden;
                }
                else if (s.WorkingArea.Width == s.Bounds.Width)
                {
                    if (s.WorkingArea.Y != 0)
                    {
                        return TaskBarPosition.Top;
                    }
                    else
                    {
                        return TaskBarPosition.Bottom;

                    }
                }
                else if (s.WorkingArea.Height == s.Bounds.Height)
                {
                    if (s.WorkingArea.X != 0)
                    {
                        return TaskBarPosition.Left;
                    }
                    else
                    {
                        return TaskBarPosition.Right;
                    }
                }
                else
                {
                    return TaskBarPosition.Unknown;
                }
            }
        }

        public static void Dock(Form form)
        {
            if (form.WindowState != FormWindowState.Normal)
            {
                return;
            }
            Screen s = Screen.FromPoint(Cursor.Position);
            int x = form.Location.X;
            int y = form.Location.Y;
            switch (Position)
            {
                case TaskBarPosition.Left:
                    x = s.WorkingArea.X;
                    y = s.Bounds.Height - form.Height;
                    break;
                case TaskBarPosition.Right:
                    x = s.WorkingArea.Width - form.Width;
                    y = s.Bounds.Height - form.Height;
                    break;
                case TaskBarPosition.Top:
                    x = s.WorkingArea.Width - form.Width;
                    y = s.WorkingArea.Y;
                    break;
                case TaskBarPosition.Bottom:
                    x = s.Bounds.Width - form.Width;
                    y = s.WorkingArea.Height - form.Height;
                    break;
                case TaskBarPosition.Hidden:
                case TaskBarPosition.Unknown:
                    break;
                default:
                    break;
            }
            form.TopMost = true;
            form.Location = new Point(x, y);
            form.BringToFront();
        }
    }
}
