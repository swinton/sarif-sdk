// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
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
                _fileSystem.WriteAllText(options.OutputFilePath, "Hello, validation rule documentation!");
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return FAILURE;
            }

            return SUCCESS;
        }
    }
}
