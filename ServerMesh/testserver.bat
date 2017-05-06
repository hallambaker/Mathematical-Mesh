setlocal
cd %~dp0
cd ..\Documentation

delete TestMeshLog.jlog
delete TestPortalLog.jlog
servermesh /start prismproof.org host1.prismproof.org /nomulti /mlog TestMeshLog.jlog /plog TestPortalLog.jlog

exit /b 0