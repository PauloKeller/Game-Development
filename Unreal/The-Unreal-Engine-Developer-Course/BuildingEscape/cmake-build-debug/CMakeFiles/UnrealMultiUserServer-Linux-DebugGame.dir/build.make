# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.15

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /snap/clion/92/bin/cmake/linux/bin/cmake

# The command to remove a file.
RM = /snap/clion/92/bin/cmake/linux/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug

# Utility rule file for UnrealMultiUserServer-Linux-DebugGame.

# Include the progress variables for this target.
include CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/progress.make

CMakeFiles/UnrealMultiUserServer-Linux-DebugGame:
	cd /home/paulo/UnrealEngine && bash /home/paulo/UnrealEngine/Engine/Build/BatchFiles/Linux/Build.sh UnrealMultiUserServer Linux DebugGame -game -progress -buildscw

UnrealMultiUserServer-Linux-DebugGame: CMakeFiles/UnrealMultiUserServer-Linux-DebugGame
UnrealMultiUserServer-Linux-DebugGame: CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/build.make

.PHONY : UnrealMultiUserServer-Linux-DebugGame

# Rule to build all files generated by this target.
CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/build: UnrealMultiUserServer-Linux-DebugGame

.PHONY : CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/build

CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/cmake_clean.cmake
.PHONY : CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/clean

CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/depend:
	cd /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug/CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/UnrealMultiUserServer-Linux-DebugGame.dir/depend

