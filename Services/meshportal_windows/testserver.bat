setlocal
cd %~dp0
cd ..\Documentation

delete TestMeshLog.jlog
delete TestPortalLog.jlog
servermesh /start mathmesh.com host1.mathmesh.org /nomulti /mlog TestMeshLog.jlog /plog TestPortalLog.jlog

exit /b 0