set(TARGET_NAME imgui)
set(IMGUI_DIR ${CMAKE_CURRENT_LIST_DIR}/../imgui)
add_library(${TARGET_NAME} SHARED)
target_sources(${TARGET_NAME}
PRIVATE
    ${IMGUI_DIR}/imgui.cpp
    ${IMGUI_DIR}/imgui_draw.cpp
    ${IMGUI_DIR}/imgui_widgets.cpp
    ${IMGUI_DIR}/examples/imgui_impl_win32.cpp
    ${IMGUI_DIR}/examples/imgui_impl_dx11.cpp
)
target_compile_definitions(${TARGET_NAME}
PRIVATE
    "IMGUI_USER_CONFIG=\"userconfig.h\""
)
target_include_directories(${TARGET_NAME}
PRIVATE
    ${CMAKE_CURRENT_LIST_DIR}
    ${IMGUI_DIR}
)
