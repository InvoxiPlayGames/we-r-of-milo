# \#we r of \#milo \#HOLMES

Unthreaded Holmes server implementation for Milo.

For 01-09-2010 Wii build of band3.

## Implementation Progress (v24)

### Implemented

* [x] kVersion
* [x] kOpenFile
* [x] kReadFile (possibly incorrect)
* [x] kCloseFile
* [ ] kPrint (not! response behaviour needs checking)
* [x] kStackTrace (stubbed, but prints the stack)

### Unimplemented

* [ ] kSysExec
* [ ] kGetStat
* [ ] kWriteFile
* [ ] kMkDir
* [ ] kDelete
* [ ] kEnumerate
* [ ] kCacheFile
* [ ] kCompareFileTimes
* [ ] kTerminate
* [ ] kCacheResource
* [ ] kPollKeyboard
* [ ] kPollJoypad
* [ ] kSendMessage
* [ ] kTruncateFile

## 01-09-2010 Gecko Codes

```
Holmes gMachineName = 127.0.0.1 (Bank 8) [IPG]
06C989D8 0000000A
3132372E 302E302E
31000000 00000000
```

```
Don't Print To Holmes [IPG]
0441F548 60000000
```
