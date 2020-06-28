set(TARGET_NAME imgui)
add_library(${TARGET_NAME} SHARED)
target_sources(${TARGET_NAME}
PRIVATE
    ${CMAKE_CURRENT_LIST_DIR}/../imgui/imgui.cpp
    ${CMAKE_CURRENT_LIST_DIR}/../imgui/imgui_draw.cpp
    ${CMAKE_CURRENT_LIST_DIR}/../imgui/imgui_widgets.cpp
)
target_compile_definitions(${TARGET_NAME}
PRIVATE
    "IMGUI_USER_CONFIG=\"userconfig.h\""
)
target_include_directories(${TARGET_NAME}
PRIVATE
    ${CMAKE_CURRENT_LIST_DIR}
)
