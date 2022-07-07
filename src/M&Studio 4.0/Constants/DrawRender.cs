using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MnStudio.Constants
{
    class DrawRender
    {
        #region Initializes
        /// <summary>
        /// Create GDI Object.
        /// </summary>
        /// <return></return>
        /// <example>
        /// CGStartUp()
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGStartUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartUp();

        /// <summary>
        /// Delete GDI Object.
        /// </summary>
        /// <return></return>
        /// <example>
        /// CGCleanUp()
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGCleanUp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CleanUp();

        /// <summary>
        /// Diaplay Pause.
        /// </summary>
        /// <return></return>
        /// <example>
        /// CGPause()
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGPause", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Pause();

        /// <summary>
        /// Diaplay Resume.
        /// </summary>
        /// <return></return>
        /// <example>
        /// CGResume()
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGResume", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Resume();

        public static byte[] StructureToByte(object obj)
        {
            int datasize = Marshal.SizeOf(obj);             // 구조체에 할당된 메모리의 크기를 구한다.
            IntPtr buff = Marshal.AllocHGlobal(datasize);   // 비관리 메모리 영역에 구조체 크기만큼의 메모리를 할당한다.
            Marshal.StructureToPtr(obj, buff, false);       // 할당된 구조체 객체의 주소를 구한다.
            byte[] data = new byte[datasize];               // 구조체가 복사될 배열
            Marshal.Copy(buff, data, 0, datasize);          // 구조체 객체를 배열에 복사
            Marshal.FreeHGlobal(buff);                      // 비관리 메모리 영역에 할당했던 메모리를 해제함
            return data;                                    // 배열을 리턴
        }
        public static object ByteToStructure(byte[] data, Type type)
        {
            IntPtr buff = Marshal.AllocHGlobal(data.Length);    // 배열의 크기만큼 비관리 메모리 영역에 메모리를 할당한다.
            Marshal.Copy(data, 0, buff, data.Length);           // 배열에 저장된 데이터를 위에서 할당한 메모리 영역에 복사한다.
            object obj = Marshal.PtrToStructure(buff, type);    // 복사된 데이터를 구조체 객체로 변환한다.
            Marshal.FreeHGlobal(buff);                          // 비관리 메모리 영역에 할당했던 메모리를 해제함
            if (Marshal.SizeOf(obj) != data.Length)             // 구조체와 원래의 데이터의 크기 비교
            {
                return null;                                    // 크기가 다르면 null 리턴
            }
            return obj;                                         // 구조체 리턴
        }
        #endregion

        #region Setup
        /// <summary>
        /// Set Fade Speed
        /// </summary>
        /// <param name="speed"></param>
        /// <return></return>
        /// <example>
        /// FadeIn(BYTE lSpeed=20);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGFadeIn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FadeIn(byte speed);

        /// <summary>
        /// Set Fade Speed
        /// </summary>
        /// <param name="speed"></param>
        /// <return></return>
        /// <example>
        /// FadeOut(BYTE lSpeed=20);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGFadeOut", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FadeOut(byte speed);

        /// <summary>
        /// Set Fade Value
        /// </summary>
        /// <return></return>
        /// <param name="fadeValue"></param>
        /// <example>
        /// void SetFadeValue(int nFadeValue);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFadeValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFadeValue(int fadeValue);

        /// <summary>
        /// Set Fade Level
        /// </summary>
        /// <param name="level"></param>
        /// <return></return>
        /// <example>
        /// SetFade(BYTE lLevel);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGSetFade", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFade(byte level);

        /// <summary>
        /// Get Fade Level
        /// </summary>
        /// <param name="level"></param>
        /// <return></return>
        /// <example>
        /// GetFade(BYTE& lLevel);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CGGetFade", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetFade(out byte level);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="fps"></param>
        /// <example>
        /// void SetFPS(float fFPS) { m_fFPS = fFPS; }
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFPS", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFPS(int fps);

        /// <summary>
        /// 
        /// </summary>
        /// <return>float</return>
        /// <example>
        /// float GetFPS() { return m_fFPS; }
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFPS", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.R4)]
        public static extern float GetFPS();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="format"></param>
        /// <example> 
        /// void SetVideoOffset(int nHOffset, int nVOffset);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetVideoFormat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVideoFormat(int format);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="hOffset"></param>
        /// <param name="vOffset"></param>
        /// <example>
        /// void SetVideoOffset(int nHOffset, int nVOffset);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetVideoOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVideoOffset(int hOffset, int vOffset);

        /// <summary>
        /// 
        /// </summary>
        /// <return>int</return>
        /// <example>
        /// int GetVideoHOffset();
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetVideoHOffset", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetVideoHOffset();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="isShow"></param>
        /// <example>
        ///  void ShowPreviewDlg(bool bShow);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Auto, EntryPoint = "ShowPreviewDlg", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowPreview(int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <example>
        /// void SetPreviewSize(int width, int height);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Auto, EntryPoint = "SetPreviewSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPreviewSize(int width, int height);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <example>
        /// void ShowConfiguration();
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowConfiguration", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowConfiguration();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="handle"></param>
        /// <param name="alpha"></param>
        /// <example>
        /// void SetAlpha(HANDLE hObj, BYTE lAlpha);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetAlpha", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAlpha(IntPtr handle, int alpha);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="handle"></param>
        /// <param name="type"></param>
        /// <example>
        /// void GetObjType(HANDLE hObj, LONG& lType);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Auto, EntryPoint = "GetObjType", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetObjType(IntPtr handle, out int type);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name="handle"></param>
        /// <param name="alpha"></param>
        /// <example>
        /// void SetAlpha(HANDLE hObj, BYTE lAlpha);
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckedDraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CheckedDraw();
        #endregion

        #region Create Object
        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Auto, EntryPoint = "CreateTextObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateTextObj(out IntPtr handle, RECT rect, string text, int height, int width, int weight, int align
            , int italic, string name, uint face, uint edge, Boolean isShow, int alpha, int interval, int lineInterval, int fontType, int textType
            , int blur, int shadow, int shadowX, int shadowY, int shadowBlur);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTypewriteObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateTypewriteObj(out IntPtr handle, out RECT rect, string text, int height, int width, int weight, int align, int italic, string name
            , uint face, uint edge, int delay, int alpha, int interval, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCountObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateCountObj(ref IntPtr handle, ref RECT rect, string text, int height, int width, int weight, int align, int italic
            , string name, uint face, uint edge, int delay, int alpha, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCrawlObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateCrawlObj(ref IntPtr handle, ref RECT rect, string text, int height, int width, int weight, int align, int italic, string name
            , uint face, uint edge, int speed, int margin, int resolution, int alpha, int interval, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTickerObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateTickerObj(ref IntPtr handle, ref RECT rect, string text, int height, int width, int weight, int align, int italic, string name
            , uint face, uint edge, int speed, int alpha, int interval, int speed1, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateBitmapObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateBitmapObj(ref IntPtr handle, ref RECT rect, [MarshalAs(UnmanagedType.LPTStr)]string text, int isShow, int alpha);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSpriteObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateSpriteObj(ref IntPtr handle, ref RECT rect, string text, int frame, int repeat, int alpha, string freq, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateGrowBarObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateGrowBarObj(ref IntPtr handle, ref RECT rect, string text, int origin, int speed, int alpha, int isShow);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateAnimationObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateAnimationObj(ref IntPtr handle, ref RECT rect, string path1, string path2, int isShow, int nAnimation
            , int animationSpeed, int distance, int alpha, int index, int size);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateAnimationTextObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreateAnimationTextObj(ref IntPtr handle, ref RECT rect, string text, int height, int width
            , int align, int italic, string name, uint face, uint edge, int isShow, int alpha, int interval);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "CreatePieChartObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void CreatePieChartObj(ref IntPtr handle, ref RECT rect, int isShow, int animation, int animationSpeed, int distance, int alpha
            , int index, int fadeValue, int size, int indexCount, int chartHeight, int startAngle, int inclineAngle, ref StringBuilder topColor
            , ref StringBuilder bottomColor, ref StringBuilder visibleColor, ref StringBuilder hiddenColor, ref StringBuilder startColor
            , ref StringBuilder endColor, ref StringBuilder retAlpha, ref StringBuilder rank, ref StringBuilder name, ref StringBuilder count
            , ref StringBuilder percent, ref StringBuilder retIndex, int isPopup);
        #endregion

        #region Draw
        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowObj(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "HideObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void HideObj(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetHide", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetHide(IntPtr handle, int isHide);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteAllObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteAllObj();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObj", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteObj(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPieChartChecked", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPieChartChecked(ref IntPtr handle, int isChecked);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPieChartPopupLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPieChartPopupLength(ref IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPieChartTextPositionX", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPieChartTextPositionX(ref IntPtr handle, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPieChartTextPositionY", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPieChartTextPositionY(ref int handle, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTextPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextPosition(ref IntPtr handle, float x, float y, int location);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        ///  
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Ansi, EntryPoint = "SetText", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetText(IntPtr handle, [MarshalAs(UnmanagedType.LPWStr)]string text, [MarshalAs(UnmanagedType.Bool)]Boolean first, [MarshalAs(UnmanagedType.Bool)]Boolean replace, uint color);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetStringPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetStringPosition(ref IntPtr handle, float x, float y, int location);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetText_withEdge", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTextWithEdge(IntPtr handle, string text, int first, int replace, uint color, int size, int weight, uint colorEdge);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetPath", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPath(IntPtr handle, string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBitmapPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBitmapPosition(ref IntPtr handle, float x, float y);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "AddText", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddText(IntPtr handle, string text, int replace, uint color);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "AddText_withEdge", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTextWithEdge(int handle, string text, int replace, uint color, int size, int weight, uint edgeColor);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "AddIcon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIcon(IntPtr handle, string icon);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "AddImage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddImage(IntPtr handle, string icon);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetLength", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLength(IntPtr handle, long length);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetGrow", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGrow();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetGrowBarZero", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGrowBarZero();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTypewriting", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IsTypewriting(IntPtr handle, ref int isTypeWriting);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFittedText", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetFittedText(IntPtr handle, string inValue, string outValue);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "StopTypewriting", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopTypewriting(IntPtr handle, ref int isTypeWriting);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "ClearObject", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearObject();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        /// </example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetNext", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetNext(IntPtr handle, string path1, string path2);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetAnimationText", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAnimationText(IntPtr handle, string text, int replace, uint color);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDraw(IntPtr handle, int isDraw);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetRedrawStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRedrawStatus(IntPtr handle, int status);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDraw_FirstTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDrawFirstTime(IntPtr handle, int isHide);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCGHold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCGHold(IntPtr handle, int isHide);

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetNextDraw", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetNextDraw(IntPtr handle, int isHide);

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "IsTicker", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IsTicker();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTickerMultiLine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTickerMultiLine();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        /// <param name=""></param>
        /// <example>
        /// 
        ///</example>
        [DllImport("CGDraw.dll", CharSet = CharSet.Unicode, EntryPoint = "SetTickerLineSpeed", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTickerLineSpeed();
        #endregion
    }
}
