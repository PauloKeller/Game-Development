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

# Utility rule file for UnrealLightmass.

# Include the progress variables for this target.
include CMakeFiles/UnrealLightmass.dir/progress.make

CMakeFiles/UnrealLightmass:
	cd /home/paulo/UnrealEngine && bash /home/paulo/UnrealEngine/Engine/Build/BatchFiles/Linux/Build.sh UnrealLightmass Linux Development -game -progress -buildscw

UnrealLightmass: CMakeFiles/UnrealLightmass
UnrealLightmass: CMakeFiles/UnrealLightmass.dir/build.make

.PHONY : UnrealLightmass

# Rule to build all files generated by this target.
CMakeFiles/UnrealLightmass.dir/build: UnrealLightmass

.PHONY : CMakeFiles/UnrealLightmass.dir/build

CMakeFiles/UnrealLightmass.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/UnrealLightmass.dir/cmake_clean.cmake
.PHONY : CMakeFiles/UnrealLightmass.dir/clean

CMakeFiles/UnrealLightmass.dir/depend:
	cd /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug /home/paulo/Workspace/Game-Development/Unreal/The-Unreal-Engine-Developer-Course/BuildingEscape/cmake-build-debug/CMakeFiles/UnrealLightmass.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/UnrealLightmass.dir/depend
