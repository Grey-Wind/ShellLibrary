#pragma once

#ifdef __cplusplus
extern "C" {
#endif

    __declspec(dllimport) void RunCommand(const char* command, const char* count, const char* hideWindow);

#ifdef __cplusplus
}
#endif
