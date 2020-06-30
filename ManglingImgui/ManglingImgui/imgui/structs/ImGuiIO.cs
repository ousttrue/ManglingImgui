// This source code was generated by ClangCaster
using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ManglingImgui
{
    // ../../imgui/imgui.h:1532
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ImGuiIO
    {

        public int ConfigFlags;
        public int BackendFlags;
        public Vector2 DisplaySize;
        public float DeltaTime;
        public float IniSavingRate;
        public IntPtr IniFilename;
        public IntPtr LogFilename;
        public float MouseDoubleClickTime;
        public float MouseDoubleClickMaxDist;
        public float MouseDragThreshold;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)] public int[] KeyMap;
        public float KeyRepeatDelay;
        public float KeyRepeatRate;
        public IntPtr UserData;
        public IntPtr Fonts;
        public float FontGlobalScale;
        public bool FontAllowUserScaling;
        public IntPtr FontDefault;
        public Vector2 DisplayFramebufferScale;
        public bool ConfigDockingNoSplit;
        public bool ConfigDockingWithShift;
        public bool ConfigDockingAlwaysTabBar;
        public bool ConfigDockingTransparentPayload;
        public bool ConfigViewportsNoAutoMerge;
        public bool ConfigViewportsNoTaskBarIcon;
        public bool ConfigViewportsNoDecoration;
        public bool ConfigViewportsNoDefaultParent;
        public bool MouseDrawCursor;
        public bool ConfigMacOSXBehaviors;
        public bool ConfigInputTextCursorBlink;
        public bool ConfigWindowsResizeFromEdges;
        public bool ConfigWindowsMoveFromTitleBarOnly;
        public float ConfigWindowsMemoryCompactTimer;
        public IntPtr BackendPlatformName;
        public IntPtr BackendRendererName;
        public IntPtr BackendPlatformUserData;
        public IntPtr BackendRendererUserData;
        public IntPtr BackendLanguageUserData;
        public IntPtr GetClipboardTextFn;
        public IntPtr SetClipboardTextFn;
        public IntPtr ClipboardUserData;
        public IntPtr RenderDrawListsFn;
        public Vector2 MousePos;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseDown;
        public float MouseWheel;
        public float MouseWheelH;
        public uint MouseHoveredViewport;
        public bool KeyCtrl;
        public bool KeyShift;
        public bool KeyAlt;
        public bool KeySuper;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] public bool[] KeysDown;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)] public float[] NavInputs;
        public bool WantCaptureMouse;
        public bool WantCaptureKeyboard;
        public bool WantTextInput;
        public bool WantSetMousePos;
        public bool WantSaveIniSettings;
        public bool NavActive;
        public bool NavVisible;
        public float Framerate;
        public int MetricsRenderVertices;
        public int MetricsRenderIndices;
        public int MetricsRenderWindows;
        public int MetricsActiveWindows;
        public int MetricsActiveAllocations;
        public Vector2 MouseDelta;
        public int KeyMods;
        public Vector2 MousePosPrev;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public Vector2[] MouseClickedPos;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public double[] MouseClickedTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseClicked;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseDoubleClicked;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseReleased;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseDownOwned;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public bool[] MouseDownWasDoubleClick;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public float[] MouseDownDuration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public float[] MouseDownDurationPrev;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public Vector2[] MouseDragMaxDistanceAbs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)] public float[] MouseDragMaxDistanceSqr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] public float[] KeysDownDuration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)] public float[] KeysDownDurationPrev;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)] public float[] NavInputsDownDuration;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)] public float[] NavInputsDownDurationPrev;
        public ushort InputQueueSurrogate;
        public IntPtr InputQueueCharacters;
    }
}
