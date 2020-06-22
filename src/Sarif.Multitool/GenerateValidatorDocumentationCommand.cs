// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis.Sarif.Driver;

namespace Microsoft.CodeAnalysis.Sarif.Multitool
{
    internal class GenerateValidatorDocumentationCommand : CommandBase
    {
        private readonly IFileSystem _fileSystem;

        public GenerateValidatorDocumentationCommand(IFileSystem fileSystem = null)
        {
            _fileSystem = fileSystem ?? new FileSystem();
        }

        internal int Run(GenerateValidatorDocumentationOptions options)
        {
            try
            {
                if (!DriverUtilities.ReportWhetherOutputFileCanBeCreated(options.OutputFilePath, options.Force, _fileSystem))
                {
                    return FAILURE;
                }

                Console.WriteLine($"Writing validation rule documentation to '{options.OutputFilePath}'...");
                string documentTemplate = GetResourceText("Microsoft.CodeAnalysis.Sarif.Multitool.DocumentTemplates.SarifValidationRules.md");
                _fileSystem.WriteAllText(options.OutputFilePath, documentTemplate);
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return FAILURE;
            }

            return SUCCESS;
        }

        private string GetResourceText(string resourceName)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' does not exist.", nameof(resourceName));
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
