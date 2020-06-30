// This source code was generated by ClangCaster
using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ManglingImgui
{
    // ../../imgui/imgui.h:2024
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ImDrawCmd
    {

        public Vector4 ClipRect;
        public IntPtr TextureId;
        public uint VtxOffset;
        public uint IdxOffset;
        public uint ElemCount;
        public ImDrawCallback UserCallback;
        public IntPtr UserCallbackData;
    }
}
