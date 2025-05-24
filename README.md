# \#we r of \#milo \#HOLMES

Unthreaded Holmes server implementation for Milo.

For 01-09-2010 Wii build of band3.

## Opcode Implementation Progress (v24)

### Implemented

* [x] kVersion
* [x] kGetStat
* [x] kOpenFile
* [x] kReadFile
* [x] kCloseFile
* [ ] kEnumerate (stubbed)
* [x] kPrint
* [ ] kCacheResource (stubbed)
* [x] kStackTrace (stubbed, but prints the stack)

### Unimplemented

* [ ] kSysExec
* [ ] kWriteFile
* [ ] kMkDir
* [ ] kDelete
* [ ] kCacheFile
* [ ] kCompareFileTimes
* [ ] kTerminate
* [ ] kPollKeyboard
* [ ] kPollJoypad
* [ ] kSendMessage
* [ ] kTruncateFile

## Feature Implementation Progress

* [ ] Stack Trace Parsing
* [ ] External Log Windows
* [ ] Game Successfully Boots
* [ ] Resource Caching (.bmp/.png/.milo)

## Extras

### 01-09-2010 Gecko Codes

```
Holmes gMachineName = 127.0.0.1 (Bank 8) [IPG]
06C989D8 0000000A
3132372E 302E302E
31000000 00000000
```

```
Holmes Always Load Cached Milos [IPG]
04442A98 38600001
00C7A2C1 00000001
00C7A22C 00000001
```

```
Don't Print To Holmes [IPG]
0441F548 60000000
```
