using System.Runtime.InteropServices;

namespace Eternal.Client.Dll.External;

/// <summary>
/// Static class for calling external functions from the Kernel32.dll
/// </summary>
public static class WindowsApi
{
    #region Kernel32
    /// <summary>
    /// The OpenProcess function is used to obtain a handle to a process, which can then be used to perform various operations on the process,
    /// such as reading or writing its memory, modifying its virtual address space, and so on.
    /// </summary>
    /// <param name="dwDesiredAccess">The access rights to request for the process object.</param>
    /// <param name="bInheritHandle">A value indicating whether the returned handle can be inherited by child processes.</param>
    /// <param name="dwProcessId">The identifier of the local process to be opened.</param>
    /// <returns>If the function succeeds, the return value is an open handle to the specified process. 
    /// If the function fails, the return value is IntPtr.Zero. To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
        uint dwDesiredAccess,
        int bInheritHandle,
        uint dwProcessId);
    
    /// <summary>
    /// The CloseHandle function is used to close an open object handle.
    /// </summary>
    /// <param name="hObject">A handle to the object to be closed.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. 
    /// To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int CloseHandle(
        IntPtr hObject);

    /// <summary>
    /// The GetProcAddress function retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
    /// </summary>
    /// <param name="hModule">A handle to the DLL module that contains the function or variable.</param>
    /// <param name="lpProcName">The name of the function or variable.</param>
    /// <returns>If the function succeeds, the return value is the address of the exported function or variable. 
    /// If the function fails, the return value is IntPtr.Zero. To get extended error information, call Marshal.GetLastWin32Error.</returns>    
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetProcAddress(
        IntPtr hModule,
        string lpProcName);

    /// <summary>
    /// The GetModuleHandle function retrieves a handle to the specified module. The module must have been loaded by the calling process.
    /// </summary>
    /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file) or a pointer to the module name string.</param>
    /// <returns>If the function succeeds, the return value is a handle to the specified module. 
    /// If the function fails, the return value is IntPtr.Zero. To get extended error information, call Marshal.GetLastWin32Error.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetModuleHandle(
        string lpModuleName);

    /// <summary>
    /// Reserves, commits, or changes the state of a region of pages in the virtual address space of the specified process. 
    /// The function can also simultaneously provide additional pages of memory for the region.
    /// </summary>
    /// <param name="hProcess">A handle to the process in which to allocate memory.</param>
    /// <param name="lpAddress">The pointer that specifies a desired starting address for the region of pages that you want to allocate.</param>
    /// <param name="dwSize">The size of the region of memory to allocate, in bytes.</param>
    /// <param name="flAllocationType">The type of memory allocation.</param>
    /// <param name="flProtect">The memory protection for the region of pages to be allocated.</param>
    /// <returns>If the function succeeds, the return value is the base address of the allocated region of pages.
    /// If the function fails, the return value is null (IntPtr.Zero).</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr VirtualAllocEx(
        IntPtr hProcess,
        IntPtr lpAddress,
        IntPtr dwSize,
        uint flAllocationType,
        uint flProtect);

    /// <summary>
    /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation will fail.
    /// </summary>
    /// <param name="hProcess">A handle to the process to write memory to.</param>
    /// <param name="lpBaseAddress">A pointer to the base address in the specified process to which data is written.</param>
    /// <param name="buffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
    /// <param name="size">The number of bytes to be written to the specified process.</param>
    /// <param name="lpNumberOfBytesWritten">A pointer to the variable that receives the number of bytes transferred into the specified process.</param>
    /// <returns>If the function succeeds, the return value is nonzero.
    /// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int WriteProcessMemory(
        IntPtr hProcess,
        IntPtr lpBaseAddress,
        byte[] buffer,
        uint size,
        out IntPtr lpNumberOfBytesWritten);

    /// <summary>
    /// Creates a thread that runs in the virtual address space of another process.
    /// </summary>
    /// <param name="hProcess">A handle to the process in which the thread is to be created.</param>
    /// <param name="lpThreadAttribute">Reserved for future use; must be null.</param>
    /// <param name="dwStackSize">The initial size of the stack, in bytes.</param>
    /// <param name="lpStartAddress">A pointer to the application-defined function of the thread to be created.</param>
    /// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
    /// <param name="dwCreationFlags">The flags that control the creation of the thread.</param>
    /// <param name="lpThreadId">A pointer to a variable that receives the thread identifier.</param>
    /// <returns>If the function succeeds, the return value is a handle to the new thread. If the function fails, the return value is null (IntPtr.Zero).</returns>
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr CreateRemoteThread(
        IntPtr hProcess,
        IntPtr lpThreadAttribute,
        IntPtr dwStackSize,
        IntPtr lpStartAddress,
        IntPtr lpParameter,
        uint dwCreationFlags,
        IntPtr lpThreadId);
    #endregion

    #region User32
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr CreateWindowEx(
        uint dwExStyle,
        [MarshalAs(UnmanagedType.LPStr)] string lpClassName,
        [MarshalAs(UnmanagedType.LPStr)] string lpWindowName,
        uint dwStyle,
        int x,
        int y,
        int nWidth,
        int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam
    );
    
    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern IntPtr CreateWindowExA(
        uint dwExStyle,
        [MarshalAs(UnmanagedType.LPStr)] string lpClassName,
        [MarshalAs(UnmanagedType.LPStr)] string lpWindowName,
        uint dwStyle,
        int x,
        int y,
        int nWidth,
        int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr CreateWindowExW(
        uint dwExStyle,
        string lpClassName,
        string lpWindowName,
        uint dwStyle,
        int x,
        int y,
        int nWidth,
        int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam);
    
    
    #endregion
    
    /// <summary>Specifies the protection types for memory regions in Windows.</summary>
    public static class ProtectionType
    {
        /// <summary> The memory region cannot be accessed.</summary>
        public const uint NoAccess = 0x01;
        
        /// <summary>The memory region can be read, but not written to.</summary>
        public const uint Readonly = 0x02;
        
        /// <summary>The memory region can be read from and written to.</summary>
        public const uint ReadWrite = 0x04;
        
        /// <summary>The memory region can be written to, but changes are written to a copy-on-write page.</summary>
        public const uint WriteCopy = 0x08;
        
        /// <summary>The memory region can be executed, but not read from or written to.</summary>
        public const uint Execute = 0x10;
        
        /// <summary>The memory region can be executed and read from, but not written to.</summary>
        public const uint ExecuteRead = 0x20;
        
        /// <summary>The memory region can be executed, read from, and written to.</summary>
        public const uint ExecuteReadWrite = 0x40;
        
        /// <summary>The memory region can be executed and written to, but changes are written to a copy-on-write page.</summary>
        public const uint ExecuteWriteCopy = 0x80;
    }

    /// <summary>
    /// Provides constants for the allocation type parameter of the VirtualAlloc and VirtualAllocEx functions in the kernel32.dll.
    /// </summary>
    public static class AllocationType
    {
        /// <summary>
        /// Allocates memory charges (from the paging file or the physical memory) for the specified reserved memory pages.
        /// The function initializes the memory to zero.This flag can only be used with Readonly, ReadWrite,
        /// and ExecuteReadWrite page protection values of type <see cref="ProtectionType"/>.
        /// </summary>
        public const uint Commit = 0x00001000;
        
        /// <summary>Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.</summary>
        public const uint Reserve = 0x00002000;
        
        /// <summary>Resets the state of the specified pages to committed.</summary>
        public const uint Reset = 0x00080000;
        
        /// <summary>Undoes the last Reset on the pages.</summary>
        public const uint ResetUndo = 0x1000000;
    }
    
    
}