project(imgui)
cmake_minimum_required(VERSION 3.0.0)

set (CMAKE_ARCHIVE_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/Debug/lib)
set (CMAKE_LIBRARY_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/Debug/lib)
set (CMAKE_RUNTIME_OUTPUT_DIRECTORY_DEBUG ${CMAKE_BINARY_DIR}/Debug/bin)
set (CMAKE_ARCHIVE_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/Release/lib)
set (CMAKE_LIBRARY_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/Release/lib)
set (CMAKE_RUNTIME_OUTPUT_DIRECTORY_RELEASE ${CMAKE_BINARY_DIR}/Release/bin)

# subdirs(dll)

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
