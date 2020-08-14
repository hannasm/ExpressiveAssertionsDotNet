using System;
using System.Text;

namespace ExpressiveAssertions.Rendering
{
  public class AnnotatedFormattable : IFormattable {
    readonly object _data;
    readonly string _prefix;
    readonly string _suffix;
    readonly IFormattable _formattable;
    readonly string _defaultFormat;
    public AnnotatedFormattable(object data) : this (data, null) {}
    public AnnotatedFormattable(object data, string defaultFormat) : this (data, defaultFormat, null, null) {}
    public AnnotatedFormattable(object data, string defaultFormat, string prefix, string suffix)
    {
      _data = data;
      _prefix = prefix ?? string.Empty;
      _suffix = suffix ?? string.Empty;
      _formattable = data as IFormattable;
      _defaultFormat = defaultFormat;
    }

    public override string ToString() 
    {
      return ToString(null, null);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
      if (format == null) { format = _defaultFormat; }

      var result = new StringBuilder();
      result.Append(_prefix);
      result.Append(_formattable?.ToString(format, formatProvider) ?? _data?.ToString() ?? string.Empty);
      result.Append(_suffix);
      return result.ToString();
    }
  }
}
