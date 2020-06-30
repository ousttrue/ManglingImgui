// This source code was generated by ClangCaster
using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ManglingImgui
{
    // ../../imgui/imgui.h:2227
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ImDrawData
    {

        public bool Valid;
        public IntPtr CmdLists;
        public int CmdListsCount;
        public int TotalIdxCount;
        public int TotalVtxCount;
        public Vector2 DisplayPos;
        public Vector2 DisplaySize;
        public Vector2 FramebufferScale;
        public IntPtr OwnerViewport;
    }
}
