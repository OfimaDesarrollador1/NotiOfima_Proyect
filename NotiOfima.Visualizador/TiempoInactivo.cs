using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NotiOfima.Visualizador
{
    /// <summary>
    /// Clase que permite identificar el tiempo de inactividad del usuario.
    /// </summary>
    class TiempoInactivo
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        
        /* El método realiza varias acciones. En primer lugar, un valor LASTINPUTINFO se crea y se inicializa su tamaño. 
         Si la función devuelve true, el tiempo resultante del campo dwTime se resta del tiempo de sistema  y se transforma en un valor TimeSpan, 
         que se devuelve. Si GetLastInputInfo falla, se devuelve null. */
        public TimeSpan? GetInactiveTime()
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            if (GetLastInputInfo(ref info))
                return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
            else
                return null;
        }
    }



    /*La estructura cuenta con dos campos. cbSize se debe establecer en el tamaño de la estructura antes de llama GetLastInputInfo. 
     dwTime se establecerá en el momento de la entrada del usuario por última vez por la llamada a GetLastInputInfo. 
     Este valor devuelto se mide en milisegundos. */
    [StructLayout(LayoutKind.Sequential)]
    public struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
}
