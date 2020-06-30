// This source code was generated by ClangCaster
using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ManglingImgui
{
    public static partial class imgui
    {
        // ../../imgui/examples/imgui_impl_dx11.h:19
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_Init@@YA_NPEAUID3D11Device@@PEAUID3D11DeviceContext@@@Z")]
        public static extern bool ImGui_ImplDX11_Init(
            IntPtr device,
            IntPtr device_context
        );

        // ../../imgui/examples/imgui_impl_dx11.h:20
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_Shutdown@@YAXXZ")]
        public static extern void ImGui_ImplDX11_Shutdown(
        );

        // ../../imgui/examples/imgui_impl_dx11.h:21
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_NewFrame@@YAXXZ")]
        public static extern void ImGui_ImplDX11_NewFrame(
        );

        // ../../imgui/examples/imgui_impl_dx11.h:22
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_RenderDrawData@@YAXPEAUImDrawData@@@Z")]
        public static extern void ImGui_ImplDX11_RenderDrawData(
            ref ImDrawData draw_data
        );

        // ../../imgui/examples/imgui_impl_dx11.h:25
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_InvalidateDeviceObjects@@YAXXZ")]
        public static extern void ImGui_ImplDX11_InvalidateDeviceObjects(
        );

        // ../../imgui/examples/imgui_impl_dx11.h:26
        [DllImport("imgui.dll", EntryPoint = "?ImGui_ImplDX11_CreateDeviceObjects@@YA_NXZ")]
        public static extern bool ImGui_ImplDX11_CreateDeviceObjects(
        );

    }
}