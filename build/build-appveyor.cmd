ECHO APPVEYOR_REPO_BRANCH: %APPVEYOR_REPO_BRANCH%
ECHO APPVEYOR_REPO_TAG: %APPVEYOR_REPO_TAG%
ECHO APPVEYOR_BUILD_NUMBER : %APPVEYOR_BUILD_NUMBER%
ECHO APPVEYOR_BUILD_VERSION : %APPVEYOR_BUILD_VERSION%

CALL build\tools\NuGet.exe restore src\Gibe.LinkPicker.Umbraco.sln
CALL "%programfiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\amd64\MsBuild.exe" build\package.proj
REM CALL "%programfiles(x86)%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\amd64\MsBuild.exe" build\package.proj