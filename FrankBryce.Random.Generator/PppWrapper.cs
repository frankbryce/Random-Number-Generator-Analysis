using System.Text.RegularExpressions;

namespace FrankBryce.Random.Generator
{
    public class PppWrapper
    {
        public char[] GetRandomCharArray()
        {
            // spawn process
            // from "http://stackoverflow.com/questions/1469764/run-command-prompt-commands"
            // with a few modifications
            var process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "ppp/ppp.exe";
            startInfo.Arguments = "\"\"";
            process.StartInfo = startInfo;
            process.Start();

            // read output
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return output.Trim().ToCharArray();
        }
    }
}
