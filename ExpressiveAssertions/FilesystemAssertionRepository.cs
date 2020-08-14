using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using ExpressiveExpressionTrees;
using System.Runtime.CompilerServices;

namespace ExpressiveAssertions {
  public static class FilesystemAssertionRepository
  {
    public static Expression<Func<T>> ActualToDisk<T>(this IAssertionTool tool, T content, Func<T,byte[]> toDisk = null, int stackDepth = 3) {
      return ActualToDisk(tool, ()=>content, toDisk, stackDepth);
    }
    public static Expression<Func<T>> ActualToDisk<T>(this IAssertionTool tool, Expression<Func<T>> content, Func<T,byte[]> toDisk = null, int stackDepth = 2) {
      string filename = GenerateTestFilename(tool, stackDepth);
      filename = string.Format("{3}{0}.{1}{2}", filename, GetFilesystemAssertionCount(tool), GetFilesystemAssertionActualSuffix(tool), GetFilesystemAssertionFilenamePrefix(tool));
      filename = Path.Combine(GetFilesystemAssertionRepositoryPath(tool), filename);
      EnsureDirectory(filename);

      if (toDisk == null) {
        toDisk = d=>Encoding.UTF8.GetBytes(Convert.ToString(d));
      }

      var xgr = new ExpressionGenerator();
      var content2 = xgr.FromFunc(
          content,
          c=>WriteActualToDisk<T>(filename, c, toDisk, tool)
      );

      return content2;
    }
    public static Expression<Func<T>> ExpectationFromDisk<T>(this IAssertionTool tool, Func<byte[], T> fromDisk = null, int stackDepth = 2) {
      string filename = GenerateTestFilename(tool, stackDepth);
      filename = string.Format("{3}{0}.{1}{2}", filename, AdvanceFilesystemAssertionCount(tool), GetFilesystemAssertionExpectedSuffix(tool), GetFilesystemAssertionFilenamePrefix(tool));
      filename = Path.Combine(GetFilesystemAssertionRepositoryPath(tool), filename);
      EnsureDirectory(filename);

      if (fromDisk == null) {
        fromDisk = d=>(T)Convert.ChangeType(Encoding.UTF8.GetString(d), typeof(T));
      }
      return ()=>AccessExpectation<T>(filename, fromDisk, tool);
    }
    public static T AccessExpectation<T>(string filename, Func<byte[], T> fromDisk, IAssertionTool tool) {
     if (!System.IO.File.Exists(filename)) {
        throw new IOException("FilesystemAssertionRepository.AccessExpection(\"" + filename + "\") - file not found");
     } 
      var bytes = System.IO.File.ReadAllBytes(filename);
      return fromDisk(bytes);
    }

    public static byte[] FilterBytes(byte[] bytes, byte[][] filters) {
      List<byte> filtered = new List<byte>(bytes.Length);
      for (var cbi = 0; cbi < bytes.Length; cbi++) {
          var doContinue = false;
          foreach (var filt in filters) {
            var isMatch = false;
            for (var fbi = 0; fbi < filt.Length; fbi++) {
              isMatch = true;
              if (cbi + fbi > bytes.Length) { isMatch = false; break; }
              if (filt[fbi] != bytes[fbi+cbi]) { isMatch = false; break; }
            }
            if (isMatch) { 
              cbi += filt.Length-1; 
              doContinue = true;
              break; 
            }
          }
          if (doContinue) { continue; }
          filtered.Add(bytes[cbi]);
      }
      return filtered.ToArray();
    }
    public static T WriteActualToDisk<T>(string filename, T content, Func<T,byte[]> toDisk, IAssertionTool tool) {
      var bytes = toDisk(content);
      var filters = GetFilesystemAssertionActualFilters(tool);
      
      System.IO.File.WriteAllBytes(filename, toDisk(content));
      return content;
    }

    public static void EnsureDirectory(string filename) {
      var path = System.IO.Path.GetDirectoryName(filename);
      if (string.IsNullOrEmpty(path))  {
        return;
      }
      if (!System.IO.Directory.Exists(path)) {
        EnsureDirectory(path);
        System.IO.Directory.CreateDirectory(path);
      }      
    }

    static ConditionalWeakTable<IAssertionTool, Dictionary<string,object>> _context = new ConditionalWeakTable<IAssertionTool, Dictionary<string, object>>();
    static bool TryGetContext<T>(IAssertionTool tool, string key, out T val) {
      var dict = _context.GetOrCreateValue(tool);
      var res = dict.TryGetValue(key, out var obj);
      if (res) { val = (T)obj; }
      else {val = default(T);}
      return res;
    }
    static void SetContext<T>(IAssertionTool tool, string key, T val) {
      var dict = _context.GetOrCreateValue(tool);
      dict[key] = val;
    }

    const string PATH_CTX = "filesystem_assertion_path";
    const string ASSERT_COUNT_CTX = "filesystem_assertion_count";
    const string EXPECTED_SUFFIX_CTX = "filesystem_assertion_expected_suffix";
    const string ACTUAL_SUFFIX_CTX = "filesystem_assertion_actual_suffix";
    const string FILENAME_PREFIX = "filesystem_assertion_filename_prefix";
    const string ACTUAL_FILTERS = "filesystem_assertion_actual_filter";
    public static void AddFilesystemAssertionActualFilter(IAssertionTool tool, string filter) {
      AddFilesystemAssertionActualFilter(tool, filter, Encoding.UTF8);
    }
    public static void AddFilesystemAssertionActualFilter(IAssertionTool tool, string filter, Encoding encoding) {
      AddFilesystemAssertionActualFilter(tool, encoding.GetBytes(filter));
    }
    public static void AddFilesystemAssertionActualFilter(IAssertionTool tool, byte[] filter) {
      var current = GetFilesystemAssertionActualFilters(tool);
      Array.Resize(ref current, current.Length + 1);
      current[current.Length - 1] = filter;
      SetFilesystemAssertionActualFilters(tool, current);
    }
    public static void SetFilesystemAssertionActualFilters(IAssertionTool tool, byte[][] filters)
    {
      SetContext(tool, ACTUAL_FILTERS, filters);
    }
    public static byte[][] GetFilesystemAssertionActualFilters(IAssertionTool tool)
    {
      if (!TryGetContext<byte[][]>(tool, ACTUAL_FILTERS, out var filters)) {
        return new byte[0][];
      }
      return filters;
    }
    public static void SetFilesystemAssertionFilenamePrefix(IAssertionTool tool, string prefix) {
        SetContext(tool, FILENAME_PREFIX,  prefix);
    }
    public static string GetFilesystemAssertionFilenamePrefix(IAssertionTool tool) {
      if (!TryGetContext<string>(tool, FILENAME_PREFIX, out var prefix)){ return string.Empty; }
      return prefix;
    }
    public static void SetFilesystemAssertionExpectedSuffix(IAssertionTool tool, string suffix) {
      SetContext(tool, EXPECTED_SUFFIX_CTX,  suffix);
    }
    public static string GetFilesystemAssertionExpectedSuffix(IAssertionTool tool) {
      if (!TryGetContext<string>(tool, EXPECTED_SUFFIX_CTX, out var suffix)){ return ".expected"; }
      return suffix;
    }
    public static void SetFilesystemAssertionActualSuffix(IAssertionTool tool, string suffix) {
      SetContext(tool, ACTUAL_SUFFIX_CTX,  suffix);
    }
    public static string GetFilesystemAssertionActualSuffix(IAssertionTool tool) {
      if (!TryGetContext<string>(tool, ACTUAL_SUFFIX_CTX, out var suffix)){ return ".actual"; }
      return suffix;
    }
    public static void SetFilesystemAssertionRepositoryPath(IAssertionTool tool, string path) {
      SetContext(tool, PATH_CTX,  path);
    }
    public static string GetFilesystemAssertionRepositoryPath(IAssertionTool tool) {
      if (!TryGetContext<string>(tool, PATH_CTX, out var path)){ return string.Empty; }
      return path;
    }

    public static int GetFilesystemAssertionCount(IAssertionTool tool) {
      if (!TryGetContext<int>(tool, ASSERT_COUNT_CTX, out var count)){ return 0; }
      return count;
    }
    public static int AdvanceFilesystemAssertionCount(IAssertionTool tool) {
      int count = GetFilesystemAssertionCount(tool);
      count += 1;
      SetContext(tool, ASSERT_COUNT_CTX, count);

      return count;
    }

    public static void ConfigureFilesystemAssertionAutoAccept(IAssertionTool tool) {
      SetFilesystemAssertionActualSuffix(tool, GetFilesystemAssertionExpectedSuffix(tool));
    }

    const string ASSERT_FILENAME_MAXLEN = "filesystem_assertion_filename_max_len";
    public static int GetFilesystemFilenameMaxLength(IAssertionTool tool) {
      if (!TryGetContext<int>(tool, ASSERT_FILENAME_MAXLEN, out var maxlen)){ return 80; }
      return maxlen;
    }
    public static void SetFilesystemFilenameMaxLength(IAssertionTool tool, int len) {
      SetContext(tool, ASSERT_FILENAME_MAXLEN, len);
    }
    const string ASSERT_FILENAME_REMOVE_PREFIX = "filesystem_assertion_filename_remove_prefix";
    public static string GetFilesystemFilenameRemovePrefix(IAssertionTool tool) {
      if (!TryGetContext<string>(tool, ASSERT_FILENAME_REMOVE_PREFIX, out var prefix)){ return string.Empty; }
      return prefix;
    }
    public static void SetFilesystemFilenameRemovePrefix(IAssertionTool tool, string prefix) {
      SetContext(tool, ASSERT_FILENAME_REMOVE_PREFIX, prefix);
    }

    public static string GenerateTestFilename(IAssertionTool tool, int stackDepth = 1) {
        var frame = new StackFrame(stackDepth, false);
        var mi = frame.GetMethod();
        var name = mi.Name;

        // For local methods and anonymous types, the C# compiler creates a name that includes the enclosing method name
        // a type like Action ex = ()=>true;
        // <GenerateTestFilename>b_0001
        // so we want to just pull the enclosing method name (enclosed in < and >) and not worry about any of the compiler 
        // generated stuff that can change unpredictably during development
        if (name.StartsWith("<")) {
          int idx = 1;
          while (name.IndexOf('<', idx) == idx) {
            idx++;
          }
          name = name.Substring(1, name.IndexOf('>')-1);
        }

        var declaringType = frame.GetMethod().DeclaringType;
        if (Attribute.IsDefined(declaringType, typeof(CompilerGeneratedAttribute))) {
          var type2 = declaringType.DeclaringType;
          declaringType = type2 ?? declaringType;
        }
        var fullName =  declaringType.FullName + "." + name;
        var sanitized = SanitizeFilename(tool, fullName);
        return sanitized;
    }
    public static string SanitizeFilename(IAssertionTool tool, string filename) {
      var len = filename.Length;
      var start = 0;
      var removePrefix = GetFilesystemFilenameRemovePrefix(tool);
      if (filename.StartsWith(removePrefix)) {
        start += removePrefix.Length;
        len -= removePrefix.Length;
      }
      var maxLength = GetFilesystemFilenameMaxLength(tool);
      if (len > maxLength) {
        start += len - maxLength;
        len = maxLength;
      }
      var result = new StringBuilder();
      int depth = 0;
      var invalidChars = new HashSet<char>(System.IO.Path.GetInvalidFileNameChars());
      bool hasUnderscore = false;
      bool hasDot = false;
      for (int i = start; i < filename.Length; i++) {
        var c = filename[i];
        switch (c) {
          case '[': case '<': case '{': case '(':
            if (result.Length > 0) {
              if (!hasUnderscore) {
                hasUnderscore = true;
                hasDot = false;
                result.Append('_');
              }
              depth++;
            }
            break;
          case ']': case '>': case '}': case ')':
            if (result.Length > 0 && depth > 0) {
              if (!hasUnderscore) {
                hasUnderscore = true;
                hasDot = false;
                result.Append('_');
              }
              depth--;
            }
            break;
          case '.': case ' ': case '-': case '_':  case '+':
            if (result.Length > 0 && !hasUnderscore) {
              hasUnderscore = true;
              hasDot = false;
              result.Append('_');
            }
            break;
          case ',': case '/': case '\\': case '?':
          case '%': case '*': case ':': case '|':
          case '"': case '\'': case '`': case ';': 
          case '=': case '&': case '#': case '^':
          case '~': case '!': case '$':
          case '@':
              if (!hasDot) {
                hasUnderscore = false;
                hasDot = true;
                result.Append('.');
              }
              break;

          default:
            if (invalidChars.Contains(c)) {
              goto case '@';
            } else {
              hasDot = false;
              hasUnderscore = false;
              result.Append(c);
            }
            break;
        }
      }
      return result.ToString();
    }
  }
}
