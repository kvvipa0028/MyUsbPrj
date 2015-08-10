/*
* MATLAB Compiler: 4.14 (R2010b)
* Date: Thu Aug 06 14:40:03 2015
* Arguments: "-B" "macro_default" "-W" "dotnet:JLmatlab,JLmatlab,0.0,private" "-T"
* "link:lib" "-d" "F:\Project\Ham\USBStudy\MyUsbPrj\JLusb\Matlab\Prj\JLmatlab\src" "-w"
* "enable:specified_file_mismatch" "-w" "enable:repeated_file" "-w"
* "enable:switch_ignored" "-w" "enable:missing_lib_sentinel" "-w" "enable:demo_license"
* "-v" "class{JLmatlab:F:\Project\Ham\USBStudy\MyUsbPrj\JLusb\Matlab\histgram.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace JLmatlabNative
{
  /// <summary>
  /// The JLmatlab class provides a CLS compliant, Object (native) interface to the
  /// M-functions contained in the files:
  /// <newpara></newpara>
  /// F:\Project\Ham\USBStudy\MyUsbPrj\JLusb\Matlab\histgram.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class JLmatlab : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static JLmatlab()
    {
      if (MWMCR.MCRAppInitialized)
      {
        Assembly assembly= Assembly.GetExecutingAssembly();

        string ctfFilePath= assembly.Location;

        int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

        ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

        string ctfFileName = "JLmatlab.ctf";

        Stream embeddedCtfStream = null;

        String[] resourceStrings = assembly.GetManifestResourceNames();

        foreach (String name in resourceStrings)
        {
          if (name.Contains(ctfFileName))
          {
            embeddedCtfStream = assembly.GetManifestResourceStream(name);
            break;
          }
        }
        mcr= new MWMCR("",
                       ctfFilePath, embeddedCtfStream, true);
      }
      else
      {
        throw new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the JLmatlab class.
    /// </summary>
    public JLmatlab()
    {
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~JLmatlab()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the histgram M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// HISTGRAM Summary of this function goes here
    /// Detailed explanation goes here
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histgram()
    {
      return mcr.EvaluateFunction("histgram", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the histgram M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// HISTGRAM Summary of this function goes here
    /// Detailed explanation goes here
    /// </remarks>
    /// <param name="InImage">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object histgram(Object InImage)
    {
      return mcr.EvaluateFunction("histgram", InImage);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the histgram M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// HISTGRAM Summary of this function goes here
    /// Detailed explanation goes here
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histgram(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "histgram", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the histgram M-function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// HISTGRAM Summary of this function goes here
    /// Detailed explanation goes here
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="InImage">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] histgram(int numArgsOut, Object InImage)
    {
      return mcr.EvaluateFunction(numArgsOut, "histgram", InImage);
    }


    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
