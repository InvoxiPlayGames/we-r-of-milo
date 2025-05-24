using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace we_r_of_milo
{
    public enum HolmesVersion
    {
        kHolmesUnknown = 0,
        kHolmesVer15 = 15,
        kHolmesVer24 = 24,
        kHolmesVer48 = 48,
        kHolmesVer63 = 63
    }

    public enum HolmesPacketsV15
    {
        kVersion,
        kSysExec,
        kGetStat,
        kOpenFile,
        kWriteFile,
        kReadFile,
        kOpenReadCloseFile,
        kCloseFile,
        kPrint,
        kMkDir,
        kDelete,
        kEnumerate,
        kCacheFile,
        kCompareFileTimes,
        kTerminate,
        kCacheResource,
        kPollKeyboard,
        kPollJoypad,
        kStackTrace,
        kInvalidOpcode
    }

    public enum HolmesPacketsV24
    {
        kVersion,
        kSysExec,
        kGetStat,
        kOpenFile,
        kWriteFile,
        kReadFile,
        kCloseFile,
        kPrint,
        kMkDir,
        kDelete,
        kEnumerate,
        kCacheFile,
        kCompareFileTimes,
        kTerminate,
        kCacheResource,
        kPollKeyboard,
        kPollJoypad,
        kStackTrace,
        kSendMessage,
        kTruncateFile,
        kInvalidOpcode
    }

    public enum HolmesPacketsV48
    {
        kVersion,
        kSysExec,
        kGetStat,
        kOpenFile,
        kWriteFile,
        kCloseFile,
        kStashFile,
        kPrint,
        kMkDir,
        kDelete,
        kEnumerate,
        kCompareFileTimes,
        kTerminate,
        kCacheResource,
        kPollKeyboard,
        kPollJoypad,
        kStackTrace,
        kSendMessage,
        kCacheShader,
        kGetShaderIncludeChecksums,
        kCompileShaderGraph,
        kImportFont,
        kConvertPixelData,
        kCopyFile,
        kInvalidOpcode
    }

    public enum HolmesPacketsV63
    {
        kVersion,
        kSysExec,
        kGetStat,
        kGetServerFileStats,
        kUpdateServerFileStat,
        kOpenFileForWrite,
        kWriteFile,
        kCloseFile,
        kStashFile,
        kPrint,
        kMkDir,
        kDelete,
        kIterate,
        kCompareFileTimes,
        kTerminate,
        kCacheResource,
        kPollKeyboard,
        kPollJoypad,
        kStackTrace,
        kSendMessage,
        kCacheShader,
        kGetShaderIncludeChecksums,
        kCompileShaderGraph,
        kImportFont,
        kLoadAndProcessTextureCubeImages,
        kLoadAndProcessTextureArray2DImages,
        kConvertPixelData,
        kCopyFile,
        kGenerateCharClipResource,
        kGenericAsyncTask,
        kInvalidOpcode = 30
    }
}
