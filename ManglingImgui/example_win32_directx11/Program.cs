using System;
using System.Numerics;
using System.Runtime.InteropServices;
// using ManglingImgui;
using NWindowsKits;
// dear imgui - standalone example application for DirectX 11
// If you are new to dear imgui, see examples/README.txt and documentation at the top of imgui.cpp.

namespace example_win32_directx11
{
    class Pin : IDisposable
    {
        GCHandle m_handle;

        public IntPtr Ptr => m_handle.AddrOfPinnedObject();

        public static implicit operator IntPtr(Pin pin) => pin.Ptr;

        public void Dispose()
        {
            m_handle.Free();
        }

        public static Pin Create<T>(in T[] value) where T : struct
        {
            return new Pin
            {
                m_handle = GCHandle.Alloc(value, GCHandleType.Pinned)
            };
        }
    }

    class Program
    {
        // Data
        static NWindowsKits.ID3D11Device g_pd3dDevice = new NWindowsKits.ID3D11Device();
        static NWindowsKits.ID3D11DeviceContext g_pd3dDeviceContext = new NWindowsKits.ID3D11DeviceContext();
        static IDXGISwapChain g_pSwapChain = new IDXGISwapChain();
        static ID3D11RenderTargetView g_mainRenderTargetView = new ID3D11RenderTargetView();

        static void Main(string[] args)
        {
            // ImGui_ImplWin32_EnableDpiAwareness();
            // Create application window
            var wc = new WNDCLASSEXW
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEXW)),
                style = C.CS_CLASSDC,
                lpfnWndProc = WndProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                // hInstance = kernel32.GetModuleHandle(null),
                hIcon = default,
                hCursor = default,
                hbrBackground = default,
                lpszMenuName = default,
                lpszClassName = "ImGui Example",
                hIconSm = default,
            };
            if (user32.RegisterClassExW(ref wc) == 0)
            {
                return;
            }
            var hwnd = user32.CreateWindowExW(0, wc.lpszClassName, "Dear ImGui DirectX11 Example",
                C.WS_OVERLAPPEDWINDOW,
                100, 100, 1280, 800,
                default, default, wc.hInstance, default);

            // Initialize Direct3D
            if (!CreateDeviceD3D(hwnd))
            {
                CleanupDeviceD3D();
                user32.UnregisterClassW(wc.lpszClassName, wc.hInstance);
                return;
            }

            // Show the window
            user32.ShowWindow(hwnd, C.SW_SHOWDEFAULT);
            user32.UpdateWindow(hwnd);

            // Setup Dear ImGui context
            // IMGUI_CHECKVERSION();
            ManglingImgui.imgui.CreateContext();
            var ioPtr = ManglingImgui.imgui.GetIO();
            var io = (ManglingImgui.ImGuiIO)Marshal.PtrToStructure(ioPtr, typeof(ManglingImgui.ImGuiIO));
            io.ConfigFlags |= (int)ManglingImgui.ImGuiConfigFlags_._NavEnableKeyboard;       // Enable Keyboard Controls
            io.ConfigFlags |= (int)ManglingImgui.ImGuiConfigFlags_._DockingEnable;           // Enable Docking
            io.ConfigFlags |= (int)ManglingImgui.ImGuiConfigFlags_._ViewportsEnable;         // Enable Multi-Viewport / Platform Windows
                                                                                             // writeback
            Marshal.StructureToPtr(io, ioPtr, false);
#if true
            io.ConfigFlags |= (int)ManglingImgui.ImGuiConfigFlags_._DpiEnableScaleFonts;     // FIXME-DPI: THIS CURRENTLY DOESN'T WORK AS EXPECTED. DON'T USE IN USER APP!
            io.ConfigFlags |= (int)ManglingImgui.ImGuiConfigFlags_._DpiEnableScaleViewports; // FIXME-DPI
#endif
            // Setup Dear ImGui style
            ManglingImgui.imgui.StyleColorsDark();
            //ManglingImgui.imgui.StyleColorsClassic();

            // When viewports are enabled we tweak WindowRounding/WindowBg so platform windows can look identical to regular ones.
            var stylePtr = ManglingImgui.imgui.GetStyle();
            var style = (ManglingImgui.ImGuiStyle)Marshal.PtrToStructure(stylePtr, typeof(ManglingImgui.ImGuiStyle));
            if ((io.ConfigFlags & (int)ManglingImgui.ImGuiConfigFlags_._ViewportsEnable) != 0)
            {
                style.WindowRounding = 0.0f;
                style.Colors[(int)ManglingImgui.ImGuiCol_._WindowBg].W = 1.0f;
            }

            // Setup Platform/Renderer bindings
            ManglingImgui.imgui.ImGui_ImplWin32_Init(hwnd.ptr);
            ManglingImgui.imgui.ImGui_ImplDX11_Init(g_pd3dDevice.Ptr, g_pd3dDeviceContext.Ptr);

            // Our state
            var show_demo_window = new[] { true };
            var show_another_window = new[] { false };
            var clear_color = new Vector4(0.45f, 0.55f, 0.60f, 1.00f);

            // Main loop
            MSG msg = default;

            float f = 0.0f;
            int counter = 0;

            // ZeroMemory(&msg, sizeof(msg));
            while (msg.message != NWindowsKits.C.WM_QUIT)
            {
                // Poll and handle messages (inputs, window resize, etc.)
                // You can read the io.WantCaptureMouse, io.WantCaptureKeyboard flags to tell if dear imgui wants to use your inputs.
                // - When io.WantCaptureMouse is true, do not dispatch mouse input data to your main application.
                // - When io.WantCaptureKeyboard is true, do not dispatch keyboard input data to your main application.
                // Generally you may always pass all inputs to dear imgui, and hide them from your application based on those two flags.
                if (user32.PeekMessageW(ref msg, default, 0U, 0U, C.PM_REMOVE) != 0)
                {
                    user32.TranslateMessage(ref msg);
                    user32.DispatchMessageW(ref msg);
                    continue;
                }

                // Start the Dear ImGui frame
                ManglingImgui.imgui.ImGui_ImplDX11_NewFrame();
                ManglingImgui.imgui.ImGui_ImplWin32_NewFrame();
                ManglingImgui.imgui.NewFrame();

                // 1. Show the big demo window (Most of the sample code is in ManglingImgui.imgui.ShowDemoWindow()! You can browse its code to learn more about Dear ImGui!).
                if (show_demo_window[0])
                {
                    using var pin = Pin.Create(show_demo_window);
                    ManglingImgui.imgui.ShowDemoWindow(pin);
                }

                // 2. Show a simple window that we create ourselves. We use a Begin/End pair to created a named window.
                {
                    ManglingImgui.imgui.Begin("Hello, world!");                          // Create a window called "Hello, world!" and append into it.

                    ManglingImgui.imgui.Text("This is some useful text.");               // Display some text (you can use a format strings too)
                    ManglingImgui.imgui.Checkbox("Demo Window", ref show_demo_window[0]);      // Edit bools storing our window open/close state
                    ManglingImgui.imgui.Checkbox("Another Window", ref show_another_window[0]);

                    ManglingImgui.imgui.SliderFloat("float", ref f, 0.0f, 1.0f);            // Edit 1 float using a slider from 0.0f to 1.0f
                    ManglingImgui.imgui.ColorEdit3("clear color", ref clear_color.W); // Edit 3 floats representing a color

                    if (ManglingImgui.imgui.Button("Button"))                            // Buttons return true when clicked (most widgets return true when edited/activated)
                        counter++;
                    ManglingImgui.imgui.SameLine();
                    ManglingImgui.imgui.Text($"counter = {counter}");

                    var p = ManglingImgui.imgui.GetIO();
                    var i = (ManglingImgui.ImGuiIO)Marshal.PtrToStructure(p, typeof(ManglingImgui.ImGuiIO));
                    ManglingImgui.imgui.Text($"Application average {1000.0f / i.Framerate:F3} ms/frame ({i.Framerate:F1} FPS)");
                    ManglingImgui.imgui.End();
                }

                // 3. Show another simple window.
                if (show_another_window[0])
                {
                    using var pin = Pin.Create(show_another_window);
                    ManglingImgui.imgui.Begin("Another Window", pin);   // Pass a pointer to our bool variable (the window will have a closing button that will clear the bool when clicked)
                    ManglingImgui.imgui.Text("Hello from another window!");
                    if (ManglingImgui.imgui.Button("Close Me"))
                        show_another_window[0] = false;
                    ManglingImgui.imgui.End();
                }

                // Rendering
                ManglingImgui.imgui.Render();
                g_pd3dDeviceContext.OMSetRenderTargets(1, ref g_mainRenderTargetView.Ptr, default);
                g_pd3dDeviceContext.ClearRenderTargetView(g_mainRenderTargetView.Ptr, ref clear_color.W);
                var drawDataPtr = ManglingImgui.imgui.GetDrawData();
                var drawData = (ManglingImgui.ImDrawData)Marshal.PtrToStructure(drawDataPtr, typeof(ManglingImgui.ImDrawData));
                ManglingImgui.imgui.ImGui_ImplDX11_RenderDrawData(ref drawData);

                // Update and Render additional Platform Windows
                if ((io.ConfigFlags & (int)ManglingImgui.ImGuiConfigFlags_._ViewportsEnable) != 0)
                {
                    ManglingImgui.imgui.UpdatePlatformWindows();
                    ManglingImgui.imgui.RenderPlatformWindowsDefault();
                }

                g_pSwapChain.Present(1, 0); // Present with vsync
                //g_pSwapChain.Present(0, 0); // Present without vsync
            }

            // Cleanup
            ManglingImgui.imgui.ImGui_ImplDX11_Shutdown();
            ManglingImgui.imgui.ImGui_ImplWin32_Shutdown();
            ManglingImgui.imgui.DestroyContext();

            CleanupDeviceD3D();
            user32.DestroyWindow(hwnd);
            user32.UnregisterClassW(wc.lpszClassName, wc.hInstance);
        }

        static bool CreateDeviceD3D(HWND hWnd)
        {
            // Setup swap chain
            DXGI_SWAP_CHAIN_DESC sd = default;
            // ZeroMemory(&sd, sizeof(sd));
            sd.BufferCount = 2;
            sd.BufferDesc.Width = 0;
            sd.BufferDesc.Height = 0;
            sd.BufferDesc.Format = DXGI_FORMAT._R8G8B8A8_UNORM;
            sd.BufferDesc.RefreshRate.Numerator = 60;
            sd.BufferDesc.RefreshRate.Denominator = 1;
            sd.Flags = (uint)DXGI_SWAP_CHAIN_FLAG._ALLOW_MODE_SWITCH;
            sd.BufferUsage = C.DXGI_USAGE_RENDER_TARGET_OUTPUT;
            sd.OutputWindow = hWnd;
            sd.SampleDesc.Count = 1;
            sd.SampleDesc.Quality = 0;
            sd.Windowed = 1;
            sd.SwapEffect = DXGI_SWAP_EFFECT._DISCARD;

            D3D_FEATURE_LEVEL createDeviceFlags = default;
            //createDeviceFlags |= D3D11_CREATE_DEVICE_DEBUG;
            D3D_FEATURE_LEVEL featureLevel = default;
            var featureLevelArray = new D3D_FEATURE_LEVEL[] { D3D_FEATURE_LEVEL._11_0, D3D_FEATURE_LEVEL._10_0, };
            if (d3d11.D3D11CreateDeviceAndSwapChain(default, D3D_DRIVER_TYPE._HARDWARE, default, (uint)createDeviceFlags, ref featureLevelArray[0], 2, C.D3D11_SDK_VERSION, ref sd,
                ref g_pSwapChain.NewPtr, ref g_pd3dDevice.NewPtr, ref featureLevel, ref g_pd3dDeviceContext.NewPtr) != 0)
                return false;

            CreateRenderTarget();
            return true;
        }

        static void CleanupDeviceD3D()
        {
            CleanupRenderTarget();
            g_pSwapChain.Dispose();
            g_pd3dDeviceContext.Dispose();
            g_pd3dDevice.Dispose();
        }

        static void CreateRenderTarget()
        {
            using var pBackBuffer = new ID3D11Texture2D();
            g_pSwapChain.GetBuffer(0, ref pBackBuffer.GetIID(), ref pBackBuffer.NewPtr);

            D3D11_TEXTURE2D_DESC desc = default;
            pBackBuffer.GetDesc(ref desc);

            var rtDesc = new D3D11_RENDER_TARGET_VIEW_DESC
            {
                Format = desc.Format,
                ViewDimension = D3D11_RTV_DIMENSION._TEXTURE2D,
            };
            g_pd3dDevice.CreateRenderTargetView(pBackBuffer.Ptr, ref rtDesc, ref g_mainRenderTargetView.NewPtr);
        }

        static void CleanupRenderTarget()
        {
            g_mainRenderTargetView.Dispose();
        }

        static short LOWORD(long src)
        {
            return (short)src;
        }

        static short HIWORD(long src)
        {
            return (short)(src >> 16);
        }

        // Win32 message handler
        static long WndProc(HWND hWnd, uint msg, ulong wParam, long lParam)
        {
            // TODO:
            // if (ManglingImgui.imgui.ImGui_ImplWin32_WndProcHandler(hWnd, msg, wParam, lParam))
            //     return 1;

            switch (msg)
            {
                case C.WM_SIZE:
                    if (g_pd3dDevice != null && wParam != C.SIZE_MINIMIZED)
                    {
                        CleanupRenderTarget();
                        g_pSwapChain.ResizeBuffers(0, (uint)LOWORD(lParam), (uint)HIWORD(lParam), DXGI_FORMAT._UNKNOWN, 0);
                        CreateRenderTarget();
                    }
                    return 0;

                case C.WM_SYSCOMMAND:
                    if ((wParam & 0xfff0) == C.SC_KEYMENU) // Disable ALT application menu
                        return 0;
                    break;

                case C.WM_DESTROY:
                    user32.PostQuitMessage(0);
                    return 0;

                    //     case C.WM_DPICHANGED:
                    //         if (ManglingImgui.imgui.GetIO().ConfigFlags & ImGuiConfigFlags_DpiEnableScaleViewports)
                    //         {
                    //             //const int dpi = HIWORD(wParam);
                    //             //printf("WM_DPICHANGED to %d (%.0f%%)\n", dpi, (float)dpi / 96.0f * 100.0f);
                    //             const RECT* suggested_rect = (RECT*)lParam;
                    // ::SetWindowPos(hWnd, null, suggested_rect.left, suggested_rect.top, suggested_rect.right - suggested_rect.left, suggested_rect.bottom - suggested_rect.top, SWP_NOZORDER | SWP_NOACTIVATE);
                    //         }
                    //         break;
            }
            return user32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }
    }
}
