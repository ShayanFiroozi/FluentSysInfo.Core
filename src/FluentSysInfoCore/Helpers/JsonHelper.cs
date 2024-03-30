/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using System.Text;

namespace FluentSysInfo.Core.Helpers
{

    internal sealed class JsonHelper
    {

        internal string ConvertPowerShellResultToJSON(string PowerShellResult)
        {
            try
            {
                StringBuilder JsonResultBuilder = new StringBuilder();

                // Add the first Json format '{' character
                _ = JsonResultBuilder.Append('{').Append('\n');



                // Process each normalized line
                foreach (string NormalizedLine in ParseAndNormalizeThePowerShellResult(PowerShellResult))
                {

                    if (!string.IsNullOrEmpty(NormalizedLine))
                    {

                        // Ignore the lines without ':' character ! ( may be it's an unwanted description , bad result or useless property !!)
                        if (!NormalizedLine.Contains(':')) continue;

                        // Split just first occurance of ':' character
                        string[] NormalizedLineSections = NormalizedLine.Split(new char[] { ':' }, 2);

                        JsonResultBuilder.Append($" \"{NormalizedLineSections[0].Trim()}\": \"{NormalizedLineSections[1].Trim()}\"")
                                  .Append(',').Append('\n');

                    }
                    else // Close the last Json section and open a new one !!

                    {
                        // Remove the trailing ',' character from the last JSON section
                        _ = JsonResultBuilder.Remove(JsonResultBuilder.Length - 2, 1);


                        // Close the the last Json bracket
                        _ = JsonResultBuilder.Append('}').Append('\n');

                        // Open the new bracket
                        _ = JsonResultBuilder.Append('{').Append('\n');
                    }


                }


                // Remove the last trailing ',' character.
                _ = JsonResultBuilder.Remove(JsonResultBuilder.Length - 2, 1);


                // Add the last '}' Json bracket ;)
                _ = JsonResultBuilder.Append('}');


                return JsonResultBuilder.ToString();


            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal string ConvertDateTimeResultToJsonFormat(string DateTimeResult, int NumberOfProperties)
        {
            StringBuilder result = new StringBuilder();

            try
            {

                // Add the first Json format '{' character
                _ = result.Append('{').Append('\n');

                string[] DateTimeItem = DateTimeResult.Split(new char[] { ',' }, NumberOfProperties);


                result.Append($" \"Date Time\": \"{DateTimeItem[0]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Date Time UTC\": \"{DateTimeItem[1]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Date\": \"{DateTimeItem[2]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Time\": \"{DateTimeItem[3]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Long Date\": \"{DateTimeItem[4]}\"")
                      .Append(',').Append('\n');



                result.Append($" \"Day Of Week\": \"{DateTimeItem[5]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Full Date Time\": \"{DateTimeItem[6]}\"")
                      .Append('\n');


                // Add the last '}' Json bracket ;)
                _ = result.Append('}');


                return result.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        private string[] ParseAndNormalizeThePowerShellResult(string PowerShellRawResult)
        {

            StringBuilder result = new StringBuilder();

            try
            {
                // Split each line
                string[] lines = PowerShellRawResult.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                // Process each line
                foreach (string line in lines)
                {
                    try
                    {
                        // Handle the empty lines !
                        if (line == string.Empty && result.Length != 0)
                        {
                            result.Append(Environment.NewLine);
                            continue;
                        }


                        // Ignore the lines without ':' character ! ( may be it's an unwanted description , bad result or useless property !!)
                        if (!line.Contains(':')) continue;

                        // Split just first occurance of ':' character
                        string[] lineSections = line.Split(new char[] { ':' }, 2);

                        // Trim the line sections
                        lineSections[0] = lineSections[0].Trim();
                        lineSections[1] = lineSections[1].Trim();

                        // Ignore empty line sections !
                        if (string.IsNullOrWhiteSpace(lineSections[0]) || string.IsNullOrWhiteSpace(lineSections[1])) continue;

                        // Ignore some unwanted CIM/Win32 classes properties
                        if (IsUnWantedCIMClass(lineSections[0])) continue;


                        if (result.Length == 0)
                        {
                            result.Append($"{lineSections[0]}:{lineSections[1]}");
                        }
                        else
                        {
                            result.Append($"{Environment.NewLine}{lineSections[0]}:{lineSections[1]}");
                        }


                    }

                    catch (Exception) { /*Ignore the lopp internal possible exception ...*/ }

                }

                return result.ToString().TrimEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            }
            catch (Exception ex)
            {
                // Pass the exception message to the caller function
                return new string[] { "An Error Occured : ", ex.Message };
            }

        }

        private bool IsUnWantedCIMClass(string ClassName)
        {
            return ClassName == "CreationClassName"
                             || ClassName == "SystemCreationClassName"
                             || ClassName == "CimClass"
                             || ClassName == "CimInstanceProperties"
                             || ClassName == "CimSystemProperties"
                             || ClassName == "CSCreationClassName";
        }

    }


}
